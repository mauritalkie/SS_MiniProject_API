using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class PerfilAccesoService : IPerfilAccesoService
	{
		private readonly DataContext _dataContext;

		public PerfilAccesoService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreatePerfilAcceso(CreatePerfilAccesoDto createPerfilAccesoDto)
		{
			PerfilAcceso perfilAcceso = PerfilAccesoMapper.AsObject(createPerfilAccesoDto);

			_dataContext.PerfilAcceso.Add(perfilAcceso);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeletePerfilAcceso(int id)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(id);
			if (dbPerfilAcceso == null) return new JsonResult("El perfil de acceso no fue encontrado");

			_dataContext.PerfilAcceso.Remove(dbPerfilAcceso);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetPerfilAccesoDto>>> GetPerfilAcceso()
		{
			List<PerfilAcceso> objects = await _dataContext.PerfilAcceso.ToListAsync();
			List<GetPerfilAccesoDto> dtos = objects.Select(obj => PerfilAccesoMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetPerfilAccesoDto>> GetPerfilAccesoById(int id)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(id);
			if (dbPerfilAcceso == null) return new JsonResult("El perfil de acceso no fue encontrado");

			return PerfilAccesoMapper.AsDto(dbPerfilAcceso);
		}

		public async Task<ActionResult> UpdatePerfilAcceso(UpdatePerfilAccesoDto updatePerfilAccesoDto)
		{
			var dbPerfilAcceso = await _dataContext.PerfilAcceso.FindAsync(updatePerfilAccesoDto.id);
			if (dbPerfilAcceso == null) return new JsonResult("El perfil de acceso no fue encontrado");

			dbPerfilAcceso.id_acceso = updatePerfilAccesoDto.id_acceso;
			dbPerfilAcceso.id_perfil = updatePerfilAccesoDto.id_perfil;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
