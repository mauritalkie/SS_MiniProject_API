using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class AccesoService : IAccesoService
	{
		public Task<ActionResult> CreateAcceso(CreateAccesoDto createAccesoDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeleteAcceso(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetAccesoDto>>> GetAcceso()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetAccesoDto>> GetAccesoById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateAcceso(UpdateAccesoDto updateAccesoDto)
		{
			throw new NotImplementedException();
		}
	}
}
