using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class EstructuraAhorroService : IEstructuraAhorroService
	{
		public Task<ActionResult> CreateEstructuraAhorro(CreateEstructuraAhorroDto createEstructuraAhorroDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeleteEstructuraAhorro(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetEstructuraAhorroDto>>> GetEstructuraAhorro()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetEstructuraAhorroDto>> GetEstructuraAhorroById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateEstructuraAhorro(UpdateEstructuraAhorroDto updateEstructuraAhorroDto)
		{
			throw new NotImplementedException();
		}
	}
}
