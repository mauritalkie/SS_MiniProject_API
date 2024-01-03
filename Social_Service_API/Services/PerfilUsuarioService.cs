using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class PerfilUsuarioService : IPerfilUsuarioService
	{
		public Task<ActionResult> CreatePerfilUsuario(CreatePerfilUsuarioDto createPerfilUsuarioDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeletePerfilUsuario(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetPerfilUsuarioDto>>> GetPerfilUsuario()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetPerfilUsuarioDto>> GetPerfilUsuarioById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdatePerfilUsuario(UpdatePerfilUsuarioDto updatePerfilUsuarioDto)
		{
			throw new NotImplementedException();
		}
	}
}
