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
	public class PerfilController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public PerfilController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<Perfil>>> GetPerfil()
		{
			List<Perfil> objects = await _dataContext.Perfil.ToListAsync();
			List<GetPerfilDto> dtos = objects.Select(obj => PerfilMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreatePerfil(CreatePerfilDto createPerfilDto)
		{
			Perfil perfil = PerfilMapper.AsObject(createPerfilDto);

			_dataContext.Perfil.Add(perfil);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdatePerfil(UpdatePerfilDto updatePerfilDto)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(updatePerfilDto.id);
			if (dbPerfil == null) return BadRequest("El perfil no fue encontrado");

			dbPerfil.nombre = updatePerfilDto.nombre;
			dbPerfil.clave = updatePerfilDto.clave;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePerfil(int id)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(id);
			if (dbPerfil == null) return BadRequest("El perfil no fue encontrado");

			_dataContext.Perfil.Remove(dbPerfil);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetPerfilDto>> GetPerfilById(int id)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(id);
			if (dbPerfil == null) return BadRequest("El perfil no fue encontrado");

			return Ok(PerfilMapper.AsDto(dbPerfil));
		}
	}
}
