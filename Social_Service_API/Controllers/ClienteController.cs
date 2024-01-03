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
	public class ClienteController : ControllerBase
	{
		private readonly IClienteService _clienteService;

		public ClienteController(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetClienteDto>>> GetCliente()
		{
			return await _clienteService.GetCliente();
		}

		[HttpPost]
		public async Task<ActionResult> CreateCliente(CreateClienteDto createClienteDto)
		{
			return await _clienteService.CreateCliente(createClienteDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateCliente(UpdateClienteDto updateClienteDto)
		{
			return await _clienteService.UpdateCliente(updateClienteDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCliente(int id)
		{
			return await _clienteService.DeleteCliente(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetOneClienteDto>> GetClienteById(int id)
		{
			return await _clienteService.GetClienteById(id);
		}
	}
}
