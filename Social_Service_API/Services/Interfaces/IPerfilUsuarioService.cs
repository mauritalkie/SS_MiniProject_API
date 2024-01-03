using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface IPerfilUsuarioService
	{
		Task<ActionResult<List<GetPerfilUsuarioDto>>> GetPerfilUsuario();
		Task<ActionResult> CreatePerfilUsuario(CreatePerfilUsuarioDto createPerfilUsuarioDto);
		Task<ActionResult> UpdatePerfilUsuario(UpdatePerfilUsuarioDto updatePerfilUsuarioDto);
		Task<ActionResult> DeletePerfilUsuario(int id);
		Task<ActionResult<GetPerfilUsuarioDto>> GetPerfilUsuarioById(int id);
	}
}
