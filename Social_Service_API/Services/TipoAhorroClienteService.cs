using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class TipoAhorroClienteService : ITipoAhorroClienteService
	{
		private readonly DataContext _dataContext;

		public TipoAhorroClienteService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreateTipoAhorroCliente(CreateTipoAhorroClienteDto createTipoAhorroClienteDto)
		{
			TipoAhorroCliente TipoAhorroCliente = TipoAhorroClienteMapper.AsObject(createTipoAhorroClienteDto);

			_dataContext.TipoAhorroCliente.Add(TipoAhorroCliente);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeleteTipoAhorroCliente(int id)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(id);
			if (dbTipoAhorroCliente == null) return new JsonResult("El tipo de ahorro de cliente no fue encontrado");

			_dataContext.TipoAhorroCliente.Remove(dbTipoAhorroCliente);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetTipoAhorroClienteDto>>> GetTipoAhorroCliente()
		{
			List<TipoAhorroCliente> objects = await _dataContext.TipoAhorroCliente.ToListAsync();
			List<GetTipoAhorroClienteDto> dtos = objects.Select(obj => TipoAhorroClienteMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetTipoAhorroClienteDto>> GetTipoAhorroClienteById(int id)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(id);
			if (dbTipoAhorroCliente == null) return new JsonResult("El tipo de ahorro de cliente no fue encontrado");

			return TipoAhorroClienteMapper.AsDto(dbTipoAhorroCliente);
		}

		public async Task<ActionResult> UpdateTipoAhorroCliente(UpdateTipoAhorroClienteDto updateTipoAhorroClienteDto)
		{
			var dbTipoAhorroCliente = await _dataContext.TipoAhorroCliente.FindAsync(updateTipoAhorroClienteDto.id);
			if (dbTipoAhorroCliente == null) return new JsonResult("El tipo de ahorro de cliente no fue encontrado");

			dbTipoAhorroCliente.alias = updateTipoAhorroClienteDto.alias;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
