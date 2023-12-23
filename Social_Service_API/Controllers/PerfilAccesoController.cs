using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PerfilAccesoController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public PerfilAccesoController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<PerfilAcceso>>> GetPerfilAcceso()
		{
			return Ok(await _dataContext.PerfilAcceso.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<PerfilAcceso>>> CreatePerfilAcceso(PerfilAcceso perfilAcceso)
		{
			_dataContext.PerfilAcceso.Add(perfilAcceso);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.PerfilAcceso.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<PerfilAcceso>>> UpdatePerfilAcceso(PerfilAcceso perfilAcceso)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(perfilAcceso.id);
			if (dbPerfilAcceso == null) return BadRequest("El perfil de acceso no fue encontrado");

			dbPerfilAcceso.id_acceso = perfilAcceso.id_acceso;
			dbPerfilAcceso.id_perfil = perfilAcceso.id_perfil;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.PerfilAcceso.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<PerfilAcceso>>> DeletePerfilAcceso(int id)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(id);
			if (dbPerfilAcceso == null) return BadRequest("El perfil de acceso no fue encontrado");

			_dataContext.PerfilAcceso.Remove(dbPerfilAcceso);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.PerfilAcceso.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<PerfilAcceso>>> GetPerfilAccesoById(int id)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(id);
			if (dbPerfilAcceso == null) return BadRequest("El perfil de acceso no fue encontrado");

			return Ok(dbPerfilAcceso);
		}
	}
}
