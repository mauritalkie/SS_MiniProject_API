using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class TipoUsuarioService : ITipoUsuarioService
	{
		private readonly DataContext _dataContext;

		public TipoUsuarioService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreateTipoUsuario(CreateTipoUsuarioDto createTipoUsuarioDto)
		{
			TipoUsuario tipoUsuario = TipoUsuarioMapper.AsObject(createTipoUsuarioDto);

			_dataContext.TipoUsuario.Add(tipoUsuario);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeleteTipoUsuario(int id)
		{
			var dbTipoUsuario = await _dataContext.TipoUsuario.FindAsync(id);
			if (dbTipoUsuario == null) return new JsonResult("El tipo de usuario no fue encontrado");

			_dataContext.TipoUsuario.Remove(dbTipoUsuario);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetTipoUsuarioDto>>> GetTipoUsuario()
		{
			List<TipoUsuario> objects = await _dataContext.TipoUsuario.ToListAsync();
			List<GetTipoUsuarioDto> dtos = objects.Select(obj => TipoUsuarioMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetTipoUsuarioDto>> GetTipoUsuarioById(int id)
		{
			var dbTipoUsuario = await _dataContext.TipoUsuario.FindAsync(id);
			if (dbTipoUsuario == null) return new JsonResult("El tipo de usuario no fue encontrado");

			return TipoUsuarioMapper.AsDto(dbTipoUsuario);
		}

		public async Task<ActionResult> UpdateTipoUsuario(UpdateTipoUsuarioDto updateTipoUsuarioDto)
		{
			var dbTipoUsuario = await _dataContext.TipoUsuario.FindAsync(updateTipoUsuarioDto.id);
			if (dbTipoUsuario == null) return new JsonResult("El tipo de usuario no fue encontrado");

			dbTipoUsuario.nombre = updateTipoUsuarioDto.nombre;
			dbTipoUsuario.clave = updateTipoUsuarioDto.clave;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
