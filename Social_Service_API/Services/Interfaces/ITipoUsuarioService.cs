using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface ITipoUsuarioService
	{
		Task<ActionResult<List<GetTipoUsuarioDto>>> GetTipoUsuario();
		Task<ActionResult> CreateTipoUsuario(CreateTipoUsuarioDto createTipoUsuarioDto);
		Task<ActionResult> UpdateTipoUsuario(UpdateTipoUsuarioDto updateTipoUsuarioDto);
		Task<ActionResult> DeleteTipoUsuario(int id);
		Task<ActionResult<GetTipoUsuarioDto>> GetTipoUsuarioById(int id);
		public string UrMom();
	}
}
