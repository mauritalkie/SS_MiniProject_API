using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class PerfilService : IPerfilService
	{
		private readonly DataContext _dataContext;

		public PerfilService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreatePerfil(CreatePerfilDto createPerfilDto)
		{
			Perfil perfil = PerfilMapper.AsObject(createPerfilDto);

			_dataContext.Perfil.Add(perfil);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeletePerfil(int id)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(id);
			if (dbPerfil == null) return new JsonResult("El perfil no fue encontrado");

			_dataContext.Perfil.Remove(dbPerfil);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetPerfilDto>>> GetPerfil()
		{
			List<Perfil> objects = await _dataContext.Perfil.ToListAsync();
			List<GetPerfilDto> dtos = objects.Select(obj => PerfilMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetPerfilDto>> GetPerfilById(int id)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(id);
			if (dbPerfil == null) return new JsonResult("El perfil no fue encontrado");

			return PerfilMapper.AsDto(dbPerfil);
		}

		public async Task<ActionResult> UpdatePerfil(UpdatePerfilDto updatePerfilDto)
		{
			var dbPerfil = await _dataContext.Perfil.FindAsync(updatePerfilDto.id);
			if (dbPerfil == null) return new JsonResult("El perfil no fue encontrado");

			dbPerfil.nombre = updatePerfilDto.nombre;
			dbPerfil.clave = updatePerfilDto.clave;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
