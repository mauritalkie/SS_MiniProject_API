using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteEstructuraController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public ClienteEstructuraController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<ClienteEstructura>>> GetClienteEstructura()
		{
			return Ok(await _dataContext.ClienteEstructura.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<ClienteEstructura>>> CreateClienteEstructura(ClienteEstructura clienteEstructura)
		{
			_dataContext.ClienteEstructura.Add(clienteEstructura);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.ClienteEstructura.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<ClienteEstructura>>> UpdateClienteEstructura(ClienteEstructura clienteEstructura)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(clienteEstructura.id);
			if (dbClienteEstructura == null) return BadRequest("La estructura del cliente no fue encontrada");

			dbClienteEstructura.nombre = clienteEstructura.nombre;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.ClienteEstructura.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<ClienteEstructura>>> DeleteClienteEstructura(int id)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(id);
			if (dbClienteEstructura == null) return BadRequest("\"La estructura del cliente no fue encontrada");

			_dataContext.ClienteEstructura.Remove(dbClienteEstructura);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.ClienteEstructura.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<ClienteEstructura>>> GetClienteEstructuraById(int id)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(id);
			if (dbClienteEstructura == null) return BadRequest("\"La estructura del cliente no fue encontrada");

			return Ok(dbClienteEstructura);
		}
	}
}
