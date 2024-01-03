using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly DataContext _dataContext;

		public UsuarioService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreateUsuario(CreateUsuarioDto createUsuarioDto)
		{
			Usuario usuario = UsuarioMapper.AsObject(createUsuarioDto);

			_dataContext.Usuario.Add(usuario);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeleteUsuario(int id)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(id);
			if (dbUsuario == null) return new JsonResult("El tipo de usuario no fue encontrado");

			_dataContext.Usuario.Remove(dbUsuario);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetUsuarioDto>>> GetUsuario()
		{
			List<Usuario> objects = await _dataContext.Usuario.ToListAsync();
			List<GetUsuarioDto> dtos = objects.Select(obj => UsuarioMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetOneUsuarioDto>> GetUsuarioById(int id)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(id);
			if (dbUsuario == null) return new JsonResult("El tipo de usuario no fue encontrado");

			return UsuarioMapper.AsOneDto(dbUsuario);
		}

		public async Task<ActionResult> UpdateUsuario(UpdateUsuarioDto updateUsuarioDto)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(updateUsuarioDto.id);
			if (dbUsuario == null) return new JsonResult("El tipo de usuario no fue encontrado");

			dbUsuario.nombre = updateUsuarioDto.nombre;
			dbUsuario.apellido_paterno = updateUsuarioDto.apellido_paterno;
			dbUsuario.apellido_materno = updateUsuarioDto.apellido_materno;
			dbUsuario.correo = updateUsuarioDto.correo;
			dbUsuario.telefono = updateUsuarioDto.telefono;
			dbUsuario.usuario = updateUsuarioDto.usuario;
			dbUsuario.contrasenia = updateUsuarioDto.contrasenia;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
