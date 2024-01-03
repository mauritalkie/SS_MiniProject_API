using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class PerfilAccesoService : IPerfilAccesoService
	{
		public Task<ActionResult> CreatePerfilAcceso(CreatePerfilAccesoDto createPerfilAccesoDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeletePerfilAcceso(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetPerfilAccesoDto>>> GetPerfilAcceso()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetPerfilAccesoDto>> GetPerfilAccesoById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdatePerfilAcceso(UpdatePerfilAccesoDto updatePerfilAccesoDto)
		{
			throw new NotImplementedException();
		}
	}
}
