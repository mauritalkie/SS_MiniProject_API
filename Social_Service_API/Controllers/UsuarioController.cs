using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
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
		public async Task<ActionResult<List<Usuario>>> GetUsuario()
		{
			return Ok(await _dataContext.Usuario.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<Usuario>>> CreateUsuario(Usuario usuario)
		{
			_dataContext.Usuario.Add(usuario);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Usuario.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<Usuario>>> UpdateUsuario(Usuario usuario)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(usuario.id);
			if (dbUsuario == null) return BadRequest("El usuario no fue encontrado");

			dbUsuario.nombre = usuario.nombre;
			dbUsuario.apellido_paterno = usuario.apellido_paterno;
			dbUsuario.apellido_materno = usuario.apellido_materno;
			dbUsuario.correo = usuario.correo;
			dbUsuario.telefono = usuario.telefono;
			dbUsuario.usuario = usuario.usuario;
			dbUsuario.contrasenia = usuario.contrasenia;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Usuario.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Usuario>>> DeleteUsuario(int id)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(id);
			if (dbUsuario == null) return BadRequest("El usuario no fue encontrado");

			_dataContext.Usuario.Remove(dbUsuario);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Usuario.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<Usuario>>> GetUsuarioById(int id)
		{
			var dbUsuario = await _dataContext.Usuario.FindAsync(id);
			if (dbUsuario == null) return BadRequest("El usuario no fue encontrado");

			return Ok(dbUsuario);
		}
	}
}
