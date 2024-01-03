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
	public class TipoAhorroController : ControllerBase
	{
		private readonly ITipoAhorroService _tipoAhorroService;

		public TipoAhorroController(ITipoAhorroService tipoAhorroService)
		{
			_tipoAhorroService = tipoAhorroService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetTipoAhorroDto>>> GetTipoAhorro()
		{
			return await _tipoAhorroService.GetTipoAhorro();
		}

		[HttpPost]
		public async Task<ActionResult> CreateTipoAhorro(CreateTipoAhorroDto createTipoAhorroDto)
		{
			return await _tipoAhorroService.CreateTipoAhorro(createTipoAhorroDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateTipoAhorro(UpdateTipoAhorroDto updateTipoAhorroDto)
		{
			return await _tipoAhorroService.UpdateTipoAhorro(updateTipoAhorroDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteTipoAhorro(int id)
		{
			return await _tipoAhorroService.DeleteTipoAhorro(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetTipoAhorroDto>> GetTipoAhorroById(int id)
		{
			return await _tipoAhorroService.GetTipoAhorroById(id);
		}
	}
}
