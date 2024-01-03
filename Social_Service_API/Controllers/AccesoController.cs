using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccesoController : ControllerBase
	{
		private readonly IAccesoService _accesoService;

		public AccesoController(IAccesoService accesoService)
		{
			_accesoService = accesoService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetAccesoDto>>> GetAcceso()
		{
			return await _accesoService.GetAcceso();
		}

		[HttpPost]
		public async Task<ActionResult> CreateAcceso(CreateAccesoDto createAccesoDto)
		{
			return await _accesoService.CreateAcceso(createAccesoDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateAcceso(UpdateAccesoDto updateAccesoDto)
		{
			return await _accesoService.UpdateAcceso(updateAccesoDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAcceso(int id)
		{
			return await _accesoService.DeleteAcceso(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetAccesoDto>> GetAccesoById(int id)
		{
			return await _accesoService.GetAccesoById(id);
		}
	}
}
