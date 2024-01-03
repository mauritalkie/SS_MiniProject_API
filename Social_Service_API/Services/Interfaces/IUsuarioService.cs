using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface IUsuarioService
	{
		Task<ActionResult<List<GetUsuarioDto>>> GetUsuario();
		Task<ActionResult> CreateUsuario(CreateUsuarioDto createUsuarioDto);
		Task<ActionResult> UpdateUsuario(UpdateUsuarioDto updateUsuarioDto);
		Task<ActionResult> DeleteUsuario(int id);
		Task<ActionResult<GetOneUsuarioDto>> GetUsuarioById(int id);
	}
}
