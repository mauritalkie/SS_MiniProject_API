using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class UsuarioService : IUsuarioService
	{
		public Task<ActionResult> CreateUsuario(CreateUsuarioDto createUsuarioDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> DeleteUsuario(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<GetUsuarioDto>>> GetUsuario()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<GetOneUsuarioDto>> GetUsuarioById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateUsuario(UpdateUsuarioDto updateUsuarioDto)
		{
			throw new NotImplementedException();
		}
	}
}
