using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PerfilController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public PerfilController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<Perfil>>> GetPerfil()
		{
			return Ok(await _dataContext.Perfil.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<Perfil>>> CreatePerfil(Perfil perfil)
		{
			_dataContext.Perfil.Add(perfil);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Perfil.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<Perfil>>> UpdatePerfil(Perfil perfil)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(perfil.id);
			if (dbPerfil == null) return BadRequest("El perfil no fue encontrado");

			dbPerfil.nombre = perfil.nombre;
			dbPerfil.clave = perfil.clave;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Perfil.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Perfil>>> DeletePerfil(int id)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(id);
			if (dbPerfil == null) return BadRequest("El perfil no fue encontrado");

			_dataContext.Perfil.Remove(dbPerfil);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Perfil.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<Perfil>>> GetPerfilById(int id)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(id);
			if (dbPerfil == null) return BadRequest("El perfil no fue encontrado");

			return Ok(dbPerfil);
		}
	}
}
