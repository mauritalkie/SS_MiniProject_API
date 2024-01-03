using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface IEstructuraAhorroService
	{
		Task<ActionResult<List<GetEstructuraAhorroDto>>> GetEstructuraAhorro();
		Task<ActionResult> CreateEstructuraAhorro(CreateEstructuraAhorroDto createEstructuraAhorroDto);
		Task<ActionResult> UpdateEstructuraAhorro(UpdateEstructuraAhorroDto updateEstructuraAhorroDto);
		Task<ActionResult> DeleteEstructuraAhorro(int id);
		Task<ActionResult<GetEstructuraAhorroDto>> GetEstructuraAhorroById(int id);
	}
}
