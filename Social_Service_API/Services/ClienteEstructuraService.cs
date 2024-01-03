using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class ClienteEstructuraService : IClienteEstructuraService
	{
		public Task<ActionResult> CreateClienteEstructura(CreateClienteEstructuraDto createClienteEstructuraDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeleteClienteEstructura(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetClienteEstructuraDto>>> GetClienteEstructura()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetClienteEstructuraDto>> GetClienteEstructuraById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateClienteEstructura(UpdateClienteEstructuraDto updateClienteEstructuraDto)
		{
			throw new NotImplementedException();
		}
	}
}
