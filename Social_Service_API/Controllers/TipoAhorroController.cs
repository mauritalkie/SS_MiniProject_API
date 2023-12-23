using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoAhorroController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public TipoAhorroController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<TipoAhorro>>> GetTipoAhorro()
		{
			return Ok(await _dataContext.TipoAhorro.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<TipoAhorro>>> CreateTipoAhorro(TipoAhorro tipoAhorro)
		{
			_dataContext.TipoAhorro.Add(tipoAhorro);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoAhorro.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<TipoAhorro>>> UpdateTipoAhorro(TipoAhorro tipoAhorro)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(tipoAhorro.id);
			if (dbTipoAhorro == null) return BadRequest("El tipo de ahorro no fue encontrado");

			dbTipoAhorro.nombre = tipoAhorro.nombre;
			dbTipoAhorro.clave = tipoAhorro.clave;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoAhorro.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<TipoAhorro>>> DeleteTipoAhorro(int id)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(id);
			if (dbTipoAhorro == null) return BadRequest("El tipo de ahorro no fue encontrado");

			_dataContext.TipoAhorro.Remove(dbTipoAhorro);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoAhorro.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<TipoAhorro>>> GetTipoAhorroById(int id)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(id);
			if (dbTipoAhorro == null) return BadRequest("El tipo de ahorro no fue encontrado");

			return Ok(dbTipoAhorro);
		}
	}
}
