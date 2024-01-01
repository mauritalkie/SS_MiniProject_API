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
	public class PerfilUsuarioController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public PerfilUsuarioController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<PerfilUsuario>>> GetPerfilUsuario()
		{
			List<PerfilUsuario> objects = await _dataContext.PerfilUsuario.ToListAsync();
			List<GetPerfilUsuarioDto> dtos = objects.Select(obj => PerfilUsuarioMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreatePerfilUsuario(CreatePerfilUsuarioDto createPerfilUsuarioDto)
		{
			PerfilUsuario perfilUsuario = PerfilUsuarioMapper.AsObject(createPerfilUsuarioDto);

			_dataContext.PerfilUsuario.Add(perfilUsuario);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdatePerfilUsuario(UpdatePerfilUsuarioDto updatePerfilUsuarioDto)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(updatePerfilUsuarioDto.id);
			if (dbPerfilUsuario == null) return BadRequest("El perfil de usuario no fue encontrado");

			dbPerfilUsuario.id_usuario = updatePerfilUsuarioDto.id_usuario;
			dbPerfilUsuario.id_perfil = updatePerfilUsuarioDto.id_perfil;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePerfilUsuario(int id)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(id);
			if (dbPerfilUsuario == null) return BadRequest("El perfil de usuario no fue encontrado");

			_dataContext.PerfilUsuario.Remove(dbPerfilUsuario);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetPerfilUsuarioDto>> GetPerfilUsuarioById(int id)
		{
			var dbPerfilUsuario = await _dataContext.PerfilUsuario.FindAsync(id);
			if (dbPerfilUsuario == null) return BadRequest("El perfil de usuario no fue encontrado");

			return Ok(PerfilUsuarioMapper.AsDto(dbPerfilUsuario));
		}
	}
}
