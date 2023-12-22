using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoUsuarioController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public TipoUsuarioController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<TipoUsuario>>> GetTipoUsuario()
		{
			return Ok(await _dataContext.TipoUsuario.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<TipoUsuario>>> CreateTipoUsuario(TipoUsuario tipoUsuario)
		{
			_dataContext.TipoUsuario.Add(tipoUsuario);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoUsuario.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<TipoUsuario>>> UpdateTipoUsuario(TipoUsuario tipoUsuario)
		{
			var dbTipoUsuario = await _dataContext.TipoUsuario.FindAsync(tipoUsuario.id);
			if (dbTipoUsuario == null) return BadRequest("El usuario no fue encontrado");

			dbTipoUsuario.nombre = tipoUsuario.nombre;
			dbTipoUsuario.clave = tipoUsuario.clave;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoUsuario.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<TipoUsuario>>> DeleteTipoUsuario(int id)
		{
			var dbTipoUsuario = await _dataContext.TipoUsuario.FindAsync(id);
			if (dbTipoUsuario == null) return BadRequest("El usuario no fue encontrado");

			_dataContext.TipoUsuario.Remove(dbTipoUsuario);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.TipoUsuario.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<TipoUsuario>>> GetTipoUsuarioById(int id)
		{
			var dbTipoUsuario = await _dataContext.TipoUsuario.FindAsync(id);
			if (dbTipoUsuario == null) return BadRequest("El usuario no fue encontrado");

			return Ok(dbTipoUsuario);
		}
	}
}
