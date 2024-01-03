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
	public class PerfilAccesoController : ControllerBase
	{
		private readonly IPerfilAccesoService _perfilAccesoService;

		public PerfilAccesoController(IPerfilAccesoService perfilAccesoService)
		{
			_perfilAccesoService = perfilAccesoService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetPerfilAccesoDto>>> GetPerfilAcceso()
		{
			return await _perfilAccesoService.GetPerfilAcceso();
		}

		[HttpPost]
		public async Task<ActionResult> CreatePerfilAcceso(CreatePerfilAccesoDto createPerfilAccesoDto)
		{
			return await _perfilAccesoService.CreatePerfilAcceso(createPerfilAccesoDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdatePerfilAcceso(UpdatePerfilAccesoDto updatePerfilAccesoDto)
		{
			return await _perfilAccesoService.UpdatePerfilAcceso(updatePerfilAccesoDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePerfilAcceso(int id)
		{
			return await _perfilAccesoService.DeletePerfilAcceso(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetPerfilAccesoDto>> GetPerfilAccesoById(int id)
		{
			return await _perfilAccesoService.GetPerfilAccesoById(id);
		}
	}
}
