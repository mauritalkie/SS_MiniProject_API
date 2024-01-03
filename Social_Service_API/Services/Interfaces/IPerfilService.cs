using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface IPerfilService
	{
		Task<ActionResult<List<GetPerfilDto>>> GetPerfil();
		Task<ActionResult> CreatePerfil(CreatePerfilDto createPerfilDto);
		Task<ActionResult> UpdatePerfil(UpdatePerfilDto updatePerfilDto);
		Task<ActionResult> DeletePerfil(int id);
		Task<ActionResult<GetPerfilDto>> GetPerfilById(int id);
	}
}
