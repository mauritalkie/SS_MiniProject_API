using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class AccesoService : IAccesoService
	{
		private readonly DataContext _dataContext;

		public AccesoService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreateAcceso(CreateAccesoDto createAccesoDto)
		{
			Acceso acceso = AccesoMapper.AsObject(createAccesoDto);

			_dataContext.Acceso.Add(acceso);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeleteAcceso(int id)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(id);
			if (dbAcceso == null) return new JsonResult("El acceso no fue encontrado");

			_dataContext.Acceso.Remove(dbAcceso);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetAccesoDto>>> GetAcceso()
		{
			List<Acceso> objects = await _dataContext.Acceso.ToListAsync();
			List<GetAccesoDto> dtos = objects.Select(obj => AccesoMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetAccesoDto>> GetAccesoById(int id)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(id);
			if (dbAcceso == null) return new JsonResult("El acceso no fue encontrado");

			return AccesoMapper.AsDto(dbAcceso);
		}

		public async Task<ActionResult> UpdateAcceso(UpdateAccesoDto updateAccesoDto)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(updateAccesoDto.id);
			if (dbAcceso == null) return new JsonResult("El acceso no fue encontrado");

			dbAcceso.nombre = updateAccesoDto.nombre;
			dbAcceso.clave = updateAccesoDto.clave;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
