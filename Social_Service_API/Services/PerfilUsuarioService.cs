using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class PerfilUsuarioService : IPerfilUsuarioService
	{
		private readonly DataContext _dataContext;

		public PerfilUsuarioService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreatePerfilUsuario(CreatePerfilUsuarioDto createPerfilUsuarioDto)
		{
			PerfilUsuario perfilUsuario = PerfilUsuarioMapper.AsObject(createPerfilUsuarioDto);

			_dataContext.PerfilUsuario.Add(perfilUsuario);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeletePerfilUsuario(int id)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(id);
			if (dbPerfilUsuario == null) return new JsonResult("El perfil de usuario no fue encontrado");

			_dataContext.PerfilUsuario.Remove(dbPerfilUsuario);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetPerfilUsuarioDto>>> GetPerfilUsuario()
		{
			List<PerfilUsuario> objects = await _dataContext.PerfilUsuario.ToListAsync();
			List<GetPerfilUsuarioDto> dtos = objects.Select(obj => PerfilUsuarioMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetPerfilUsuarioDto>> GetPerfilUsuarioById(int id)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(id);
			if (dbPerfilUsuario == null) return new JsonResult("El perfil de usuario no fue encontrado");

			return PerfilUsuarioMapper.AsDto(dbPerfilUsuario);
		}

		public async Task<ActionResult> UpdatePerfilUsuario(UpdatePerfilUsuarioDto updatePerfilUsuarioDto)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(updatePerfilUsuarioDto.id);
			if (dbPerfilUsuario == null) return new JsonResult("El perfil de usuario no fue encontrado");

			dbPerfilUsuario.id_usuario = updatePerfilUsuarioDto.id_usuario;
			dbPerfilUsuario.id_perfil = updatePerfilUsuarioDto.id_perfil;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
