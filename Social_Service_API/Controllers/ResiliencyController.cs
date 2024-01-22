using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.CircuitBreaker;
using Polly.Timeout;
using System.Threading;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResiliencyController : ControllerBase
	{
		private readonly HttpClient _httpClient;
		private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;

		public ResiliencyController()
		{
			_httpClient = new HttpClient();

			_circuitBreakerPolicy = Policy.Handle<HttpRequestException>().CircuitBreakerAsync(3, TimeSpan.FromSeconds(30), onBreak, onReset, onHalfOpen);
		}

		// Retry example

		[HttpGet("GetTipoUsuario")]
		public async Task<ActionResult> GetDataRetry()
		{
			var retryPolicy = Policy.Handle<HttpRequestException>()
				.WaitAndRetryAsync(3, retryAttemp => TimeSpan.FromSeconds(Math.Pow(2, retryAttemp)));

			try
			{
				var result = await retryPolicy.ExecuteAsync(() => GetExternalData("http://localhost:5212/api/TipoUsuario"));
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		private async Task<string> GetExternalData(string url)
		{
			// await Task.Delay(TimeSpan.FromSeconds(10));
			var response = _httpClient.GetAsync(url);
			return await response.Result.Content.ReadAsStringAsync();
		}

		// Timeout example

		[HttpGet("GetAcceso")]
		public async Task<ActionResult> GetDataTimeout()
		{
			var timeoutPolicy = Policy.TimeoutAsync(TimeSpan.FromSeconds(1), Polly.Timeout.TimeoutStrategy.Pessimistic);

			try
			{
				var result = await timeoutPolicy.ExecuteAsync(ct => 
				GetExternalData("http://localhost:5212/api/TipoUsuario"), CancellationToken.None);

				return Ok(result);
			}
			catch (TimeoutRejectedException ex)
			{
				return StatusCode(504, "Operation timed out: " + ex.Message);
			}
			catch(Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		// circuit breaker example
		[HttpGet("GetPerfil")]
		public async Task<ActionResult> GetDataCircuitBreaker()
		{
			try
			{
				var result = await _circuitBreakerPolicy.ExecuteAsync(() => GetExternalData("http://localhost:5212/api/Resiliency/GetPerfil"));
				return Ok(result);
			}
			catch (BrokenCircuitException ex)
			{
				return StatusCode(503, "Circuit is open " + ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		private void onBreak(Exception ex, TimeSpan timeSpan)
		{
			Console.WriteLine($"Circuit is open for {timeSpan.TotalSeconds} seconds.");
		}

		private void onReset()
		{
			Console.WriteLine("Circuit is closed.");
		}

		private void onHalfOpen()
		{
			Console.WriteLine("Circuit is half-open.");
		}
	}
}
