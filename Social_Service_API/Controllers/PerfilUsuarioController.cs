using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PerfilUsuarioController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public PerfilUsuarioController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<PerfilUsuario>>> GetPerfilUsuario()
		{
			return Ok(await _dataContext.PerfilUsuario.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<PerfilUsuario>>> CreatePerfilUsuario(PerfilUsuario perfilUsuario)
		{
			_dataContext.PerfilUsuario.Add(perfilUsuario);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.PerfilUsuario.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<PerfilUsuario>>> UpdatePerfilUsuario(PerfilUsuario perfilUsuario)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(perfilUsuario.id);
			if (dbPerfilUsuario == null) return BadRequest("El perfil de usuario no fue encontrado");

			dbPerfilUsuario.id_usuario = perfilUsuario.id_usuario;
			dbPerfilUsuario.id_perfil = perfilUsuario.id_perfil;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.PerfilUsuario.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<PerfilUsuario>>> DeletePerfilUsuario(int id)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(id);
			if (dbPerfilUsuario == null) return BadRequest("El perfil de usuario no fue encontrado");

			_dataContext.PerfilUsuario.Remove(dbPerfilUsuario);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.PerfilUsuario.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<PerfilUsuario>>> GetPerfilUsuarioById(int id)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(id);
			if (dbPerfilUsuario == null) return BadRequest("El perfil de usuario no fue encontrado");

			return Ok(dbPerfilUsuario);
		}
	}
}
