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
	public class PerfilAccesoController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public PerfilAccesoController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<PerfilAcceso>>> GetPerfilAcceso()
		{
			List<PerfilAcceso> objects = await _dataContext.PerfilAcceso.ToListAsync();
			List<GetPerfilAccesoDto> dtos = objects.Select(obj => PerfilAccesoMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreatePerfilAcceso(CreatePerfilAccesoDto createPerfilAccesoDto)
		{
			PerfilAcceso perfilAcceso = PerfilAccesoMapper.AsObject(createPerfilAccesoDto);

			_dataContext.PerfilAcceso.Add(perfilAcceso);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdatePerfilAcceso(UpdatePerfilAccesoDto updatePerfilAccesoDto)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(updatePerfilAccesoDto.id);
			if (dbPerfilAcceso == null) return BadRequest("El perfil de acceso no fue encontrado");

			dbPerfilAcceso.id_acceso = updatePerfilAccesoDto.id_acceso;
			dbPerfilAcceso.id_perfil = updatePerfilAccesoDto.id_perfil;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePerfilAcceso(int id)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(id);
			if (dbPerfilAcceso == null) return BadRequest("El perfil de acceso no fue encontrado");

			_dataContext.PerfilAcceso.Remove(dbPerfilAcceso);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetPerfilAccesoDto>> GetPerfilAccesoById(int id)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(id);
			if (dbPerfilAcceso == null) return BadRequest("El perfil de acceso no fue encontrado");

			return Ok(PerfilAccesoMapper.AsDto(dbPerfilAcceso));
		}
	}
}
