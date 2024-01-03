using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class TipoAhorroService : ITipoAhorroService
	{
		private readonly DataContext _dataContext;

		public TipoAhorroService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreateTipoAhorro(CreateTipoAhorroDto createTipoAhorroDto)
		{
			TipoAhorro tipoAhorro = TipoAhorroMapper.AsObject(createTipoAhorroDto);

			_dataContext.TipoAhorro.Add(tipoAhorro);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeleteTipoAhorro(int id)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(id);
			if (dbTipoAhorro == null) return new JsonResult("El tipo de ahorro no fue encontrado");

			_dataContext.TipoAhorro.Remove(dbTipoAhorro);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetTipoAhorroDto>>> GetTipoAhorro()
		{
			List<TipoAhorro> objects = await _dataContext.TipoAhorro.ToListAsync();
			List<GetTipoAhorroDto> dtos = objects.Select(obj => TipoAhorroMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetTipoAhorroDto>> GetTipoAhorroById(int id)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(id);
			if (dbTipoAhorro == null) return new JsonResult("El tipo de ahorro no fue encontrado");

			return TipoAhorroMapper.AsDto(dbTipoAhorro);
		}

		public async Task<ActionResult> UpdateTipoAhorro(UpdateTipoAhorroDto updateTipoAhorroDto)
		{
			var dbTipoAhorro = await _dataContext.TipoAhorro.FindAsync(updateTipoAhorroDto.id);
			if (dbTipoAhorro == null) return new JsonResult("El tipo de ahorro no fue encontrado");

			dbTipoAhorro.nombre = updateTipoAhorroDto.nombre;
			dbTipoAhorro.clave = updateTipoAhorroDto.clave;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
