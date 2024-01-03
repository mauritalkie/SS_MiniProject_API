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
	public class EstructuraAhorroController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public EstructuraAhorroController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetEstructuraAhorroDto>>> GetEstructuraAhorro()
		{
			List<EstructuraAhorro> objects = await _dataContext.EstructuraAhorro.ToListAsync();
			List<GetEstructuraAhorroDto> dtos = objects.Select(obj => EstructuraAhorroMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreateEstructuraAhorro(CreateEstructuraAhorroDto createEstructuraAhorroDto)
		{
			EstructuraAhorro estructuraAhorro = EstructuraAhorroMapper.AsObject(createEstructuraAhorroDto);

			_dataContext.EstructuraAhorro.Add(estructuraAhorro);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateEstructuraAhorro(UpdateEstructuraAhorroDto updateEstructuraAhorroDto)
		{
			var dbEstructuraAhorro = await _dataContext.EstructuraAhorro.FindAsync(updateEstructuraAhorroDto.id);
			if (dbEstructuraAhorro == null) return BadRequest("La estructura de ahorro no fue encontrada");

			dbEstructuraAhorro.id_tipo_ahorro_cliente = updateEstructuraAhorroDto.id_tipo_ahorro_cliente;
			dbEstructuraAhorro.id_cliente_estructura = updateEstructuraAhorroDto.id_cliente_estructura;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteEstructuraAhorro(int id)
		{
			var dbEstructuraAhorro = await _dataContext.EstructuraAhorro.FindAsync(id);
			if (dbEstructuraAhorro == null) return BadRequest("La estructura de ahorro no fue encontrada");

			_dataContext.EstructuraAhorro.Remove(dbEstructuraAhorro);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetEstructuraAhorroDto>> GetEstructuraAhorroById(int id)
		{
			var dbEstructuraAhorro = await _dataContext.EstructuraAhorro.FindAsync(id);
			if (dbEstructuraAhorro == null) return BadRequest("La estructura de ahorro no fue encontrada");

			return Ok(EstructuraAhorroMapper.AsDto(dbEstructuraAhorro));
		}
	}
}
