using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstructuraAhorroController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public EstructuraAhorroController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<EstructuraAhorro>>> GetEstructuraAhorro()
		{
			return Ok(await _dataContext.EstructuraAhorro.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<EstructuraAhorro>>> CreateEstructuraAhorro(EstructuraAhorro estructuraAhorro)
		{
			_dataContext.EstructuraAhorro.Add(estructuraAhorro);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.EstructuraAhorro.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<EstructuraAhorro>>> UpdateEstructuraAhorro(EstructuraAhorro estructuraAhorro)
		{
			var dbEstructuraAhorro = await _dataContext.EstructuraAhorro.FindAsync(estructuraAhorro.id);
			if (dbEstructuraAhorro == null) return BadRequest("La estructura de ahorro no fue encontrada");

			dbEstructuraAhorro.id_tipo_ahorro_cliente = estructuraAhorro.id_tipo_ahorro_cliente;
			dbEstructuraAhorro.id_cliente_estructura = estructuraAhorro.id_cliente_estructura;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.EstructuraAhorro.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<EstructuraAhorro>>> DeleteEstructuraAhorro(int id)
		{
			var dbEstructuraAhorro = await _dataContext.EstructuraAhorro.FindAsync(id);
			if (dbEstructuraAhorro == null) return BadRequest("La estructura de ahorro no fue encontrada");

			_dataContext.EstructuraAhorro.Remove(dbEstructuraAhorro);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.EstructuraAhorro.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<EstructuraAhorro>>> GetEstructuraAhorroById(int id)
		{
			var dbEstructuraAhorro = await _dataContext.EstructuraAhorro.FindAsync(id);
			if (dbEstructuraAhorro == null) return BadRequest("La estructura de ahorro no fue encontrada");

			return Ok(dbEstructuraAhorro);
		}
	}
}
