using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class ClienteService : IClienteService
	{
		public Task<ActionResult> CreateCliente(CreateClienteDto createClienteDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeleteCliente(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetClienteDto>>> GetCliente()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetOneClienteDto>> GetClienteById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateCliente(UpdateClienteDto updateClienteDto)
		{
			throw new NotImplementedException();
		}
	}
}
