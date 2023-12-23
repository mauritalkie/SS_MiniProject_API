using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoAhorroClienteController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public TipoAhorroClienteController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<TipoAhorroCliente>>> GetTipoAhorroCliente()
		{
			return Ok(await _dataContext.TipoAhorroCliente.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<TipoAhorroCliente>>> CreateTipoAhorroCliente(TipoAhorroCliente tipoAhorroCliente)
		{
			_dataContext.TipoAhorroCliente.Add(tipoAhorroCliente);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoAhorroCliente.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<TipoAhorroCliente>>> UpdateTipoAhorroCliente(TipoAhorroCliente tipoAhorroCliente)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(tipoAhorroCliente.id);
			if (dbTipoAhorroCliente == null) return BadRequest("El tipo de ahorro del cliente no fue encontrado");

			dbTipoAhorroCliente.alias = tipoAhorroCliente.alias;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoAhorroCliente.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<TipoAhorroCliente>>> DeleteTipoAhorroCliente(int id)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(id);
			if (dbTipoAhorroCliente == null) return BadRequest("El tipo de ahorro del cliente no fue encontrado");

			_dataContext.TipoAhorroCliente.Remove(dbTipoAhorroCliente);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoAhorroCliente.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<TipoAhorroCliente>>> GetTipoAhorroClienteById(int id)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(id);
			if (dbTipoAhorroCliente == null) return BadRequest("El tipo de ahorro del cliente no fue encontrado");

			return Ok(dbTipoAhorroCliente);
		}
	}
}
