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
	public class AccesoController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public AccesoController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetAccesoDto>>> GetAcceso()
		{
			List<Acceso> objects = await _dataContext.Acceso.ToListAsync();
			List<GetAccesoDto> dtos = objects.Select(obj => AccesoMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreateAcceso(CreateAccesoDto createAccesoDto)
		{
			Acceso acceso = AccesoMapper.AsObject(createAccesoDto);

			_dataContext.Acceso.Add(acceso);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateAcceso(UpdateAccesoDto updateAccesoDto)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(updateAccesoDto.id);
			if (dbAcceso == null) return BadRequest("El acceso no fue encontrado");

			dbAcceso.nombre = updateAccesoDto.nombre;
			dbAcceso.clave = updateAccesoDto.clave;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAcceso(int id)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(id);
			if (dbAcceso == null) return BadRequest("El acceso no fue encontrado");

			_dataContext.Acceso.Remove(dbAcceso);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Acceso.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetAccesoDto>> GetAccesoById(int id)
		{
			var dbAcceso = await _dataContext.Acceso.FindAsync(id);
			if (dbAcceso == null) return BadRequest("El acceso no fue encontrado");

			return Ok(AccesoMapper.AsDto(dbAcceso));
		}
	}
}
