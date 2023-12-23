using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccesoController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public AccesoController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<Acceso>>> GetAcceso()
		{
			return Ok(await _dataContext.Acceso.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<Acceso>>> CreateAcceso(Acceso acceso)
		{
			_dataContext.Acceso.Add(acceso);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Acceso.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<Acceso>>> UpdateAcceso(Acceso acceso)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(acceso.id);
			if (dbAcceso == null) return BadRequest("El acceso no fue encontrado");

			dbAcceso.nombre = acceso.nombre;
			dbAcceso.clave = acceso.clave;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Acceso.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Acceso>>> DeleteAcceso(int id)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(id);
			if (dbAcceso == null) return BadRequest("El acceso no fue encontrado");

			_dataContext.Acceso.Remove(dbAcceso);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Acceso.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<Acceso>>> GetAccesoById(int id)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(id);
			if (dbAcceso == null) return BadRequest("El acceso no fue encontrado");

			return Ok(dbAcceso);
		}
	}
}
