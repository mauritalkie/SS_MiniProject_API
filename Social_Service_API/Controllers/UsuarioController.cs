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
	public class UsuarioController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public UsuarioController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetUsuarioDto>>> GetUsuario()
		{
			List<Usuario> objects = await _dataContext.Usuario.ToListAsync();
			List<GetUsuarioDto> dtos = objects.Select(obj => UsuarioMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreateUsuario(CreateUsuarioDto createUsuarioDto)
		{
			Usuario usuario = UsuarioMapper.AsObject(createUsuarioDto);

			_dataContext.Usuario.Add(usuario);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateUsuario(UpdateUsuarioDto updateUsuarioDto)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(updateUsuarioDto.id);
			if (dbUsuario == null) return BadRequest("El usuario no fue encontrado");

			dbUsuario.nombre = updateUsuarioDto.nombre;
			dbUsuario.apellido_paterno = updateUsuarioDto.apellido_paterno;
			dbUsuario.apellido_materno = updateUsuarioDto.apellido_materno;
			dbUsuario.correo = updateUsuarioDto.correo;
			dbUsuario.telefono = updateUsuarioDto.telefono;
			dbUsuario.usuario = updateUsuarioDto.usuario;
			dbUsuario.contrasenia = updateUsuarioDto.contrasenia;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteUsuario(int id)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(id);
			if (dbUsuario == null) return BadRequest("El usuario no fue encontrado");

			_dataContext.Usuario.Remove(dbUsuario);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetOneUsuarioDto>> GetUsuarioById(int id)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(id);
			if (dbUsuario == null) return BadRequest("El usuario no fue encontrado");

			return Ok(UsuarioMapper.AsOneDto(dbUsuario));
		}
	}
}
