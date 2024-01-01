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
	public class TipoAhorroClienteController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public TipoAhorroClienteController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetTipoAhorroClienteDto>>> GetTipoAhorroCliente()
		{
			List<TipoAhorroCliente> objects = await _dataContext.TipoAhorroCliente.ToListAsync();
			List<GetTipoAhorroClienteDto> dtos = objects.Select(obj => TipoAhorroClienteMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreateTipoAhorroCliente(CreateTipoAhorroClienteDto createTipoAhorroClienteDto)
		{
			TipoAhorroCliente TipoAhorroCliente = TipoAhorroClienteMapper.AsObject(createTipoAhorroClienteDto);

			_dataContext.TipoAhorroCliente.Add(TipoAhorroCliente);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateTipoAhorroCliente(UpdateTipoAhorroClienteDto updateTipoAhorroClienteDto)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(updateTipoAhorroClienteDto.id);
			if (dbTipoAhorroCliente == null) return BadRequest("El tipo de ahorro de cliente no fue encontrado");

			dbTipoAhorroCliente.alias = updateTipoAhorroClienteDto.alias;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteTipoAhorroCliente(int id)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(id);
			if (dbTipoAhorroCliente == null) return BadRequest("El tipo de ahorro de cliente no fue encontrado");

			_dataContext.TipoAhorroCliente.Remove(dbTipoAhorroCliente);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetTipoAhorroClienteDto>> GetTipoAhorroClienteById(int id)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(id);
			if (dbTipoAhorroCliente == null) return BadRequest("El tipo de ahorro de cliente no fue encontrado");

			return Ok(TipoAhorroClienteMapper.AsDto(dbTipoAhorroCliente));
		}
	}
}
