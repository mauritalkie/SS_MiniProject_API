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
	public class TipoAhorroClienteController : ControllerBase
	{
		private readonly ITipoAhorroClienteService _tipoAhorroClienteService;

		public TipoAhorroClienteController(ITipoAhorroClienteService tipoAhorroClienteService)
		{
			_tipoAhorroClienteService = tipoAhorroClienteService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetTipoAhorroClienteDto>>> GetTipoAhorroCliente()
		{
			return await _tipoAhorroClienteService.GetTipoAhorroCliente();
		}

		[HttpPost]
		public async Task<ActionResult> CreateTipoAhorroCliente(CreateTipoAhorroClienteDto createTipoAhorroClienteDto)
		{
			return await _tipoAhorroClienteService.CreateTipoAhorroCliente(createTipoAhorroClienteDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateTipoAhorroCliente(UpdateTipoAhorroClienteDto updateTipoAhorroClienteDto)
		{
			return await _tipoAhorroClienteService.UpdateTipoAhorroCliente(updateTipoAhorroClienteDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteTipoAhorroCliente(int id)
		{
			return await _tipoAhorroClienteService.DeleteTipoAhorroCliente(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetTipoAhorroClienteDto>> GetTipoAhorroClienteById(int id)
		{
			return await _tipoAhorroClienteService.GetTipoAhorroClienteById(id);
		}
	}
}
