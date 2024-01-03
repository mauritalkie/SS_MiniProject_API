using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class PerfilService : IPerfilService
	{
		public Task<ActionResult> CreatePerfil(CreatePerfilDto createPerfilDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeletePerfil(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetPerfilDto>>> GetPerfil()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetPerfilDto>> GetPerfilById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdatePerfil(UpdatePerfilDto updatePerfilDto)
		{
			throw new NotImplementedException();
		}
	}
}
