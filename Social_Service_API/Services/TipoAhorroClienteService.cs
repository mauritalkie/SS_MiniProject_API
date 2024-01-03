using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class TipoAhorroClienteService : ITipoAhorroClienteService
	{
		public Task<ActionResult> CreateTipoAhorroCliente(CreateTipoAhorroClienteDto createTipoAhorroClienteDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeleteTipoAhorroCliente(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetTipoAhorroClienteDto>>> GetTipoAhorroCliente()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetTipoAhorroClienteDto>> GetTipoAhorroClienteById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateTipoAhorroCliente(UpdateTipoAhorroClienteDto updateTipoAhorroClienteDto)
		{
			throw new NotImplementedException();
		}
	}
}
