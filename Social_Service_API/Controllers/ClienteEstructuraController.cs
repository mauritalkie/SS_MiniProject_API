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
	public class ClienteEstructuraController : ControllerBase
	{
		private readonly IClienteEstructuraService _clienteEstructuraService;

		public ClienteEstructuraController(IClienteEstructuraService clienteEstructuraService)
		{
			_clienteEstructuraService = clienteEstructuraService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetClienteEstructuraDto>>> GetClienteEstructura()
		{
			return await _clienteEstructuraService.GetClienteEstructura();
		}

		[HttpPost]
		public async Task<ActionResult> CreateClienteEstructura(CreateClienteEstructuraDto createClienteEstructuraDto)
		{
			return await _clienteEstructuraService.CreateClienteEstructura(createClienteEstructuraDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateClienteEstructura(UpdateClienteEstructuraDto updateClienteEstructuraDto)
		{
			return await _clienteEstructuraService.UpdateClienteEstructura(updateClienteEstructuraDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteClienteEstructura(int id)
		{
			return await _clienteEstructuraService.DeleteClienteEstructura(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetClienteEstructuraDto>> GetClienteEstructuraById(int id)
		{
			return await _clienteEstructuraService.GetClienteEstructuraById(id);
		}
	}
}
