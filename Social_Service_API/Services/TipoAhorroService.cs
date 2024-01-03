using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class TipoAhorroService : ITipoAhorroService
	{
		public Task<ActionResult> CreateTipoAhorro(CreateTipoAhorroDto createTipoAhorroDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeleteTipoAhorro(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetTipoAhorroDto>>> GetTipoAhorro()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetTipoAhorroDto>> GetTipoAhorroById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateTipoAhorro(UpdateTipoAhorroDto updateTipoAhorroDto)
		{
			throw new NotImplementedException();
		}
	}
}
