using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
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
			List<TipoAhorro> objects = await _dataContext.TipoAhorro.ToListAsync();
			List<GetTipoAhorroDto> dtos = objects.Select(obj => TipoAhorroMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreateTipoAhorro(CreateTipoAhorroDto createTipoAhorroDto)
		{
			TipoAhorro tipoAhorro = TipoAhorroMapper.AsObject(createTipoAhorroDto);

			_dataContext.TipoAhorro.Add(tipoAhorro);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateTipoAhorro(UpdateTipoAhorroDto updateTipoAhorro)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(updateTipoAhorro.id);
			if (dbTipoAhorro == null) return BadRequest("El tipo de ahorro no fue encontrado");

			dbTipoAhorro.nombre = updateTipoAhorro.nombre;
			dbTipoAhorro.clave = updateTipoAhorro.clave;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteTipoAhorro(int id)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(id);
			if (dbTipoAhorro == null) return BadRequest("El tipo de ahorro no fue encontrado");

			_dataContext.TipoAhorro.Remove(dbTipoAhorro);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetTipoAhorroDto>> GetTipoAhorroById(int id)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(id);
			if (dbTipoAhorro == null) return BadRequest("El tipo de ahorro no fue encontrado");

			return Ok(TipoAhorroMapper.AsDto(dbTipoAhorro));
		}
	}
}
