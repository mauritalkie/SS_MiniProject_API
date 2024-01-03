using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface ITipoAhorroService
	{
		Task<ActionResult<List<GetTipoAhorroDto>>> GetTipoAhorro();
		Task<ActionResult> CreateTipoAhorro(CreateTipoAhorroDto createTipoAhorroDto);
		Task<ActionResult> UpdateTipoAhorro(UpdateTipoAhorroDto updateTipoAhorroDto);
		Task<ActionResult> DeleteTipoAhorro(int id);
		Task<ActionResult<GetTipoAhorroDto>> GetTipoAhorroById(int id);
	}
}
