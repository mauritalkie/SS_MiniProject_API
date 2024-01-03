using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface IPerfilAccesoService
	{
		Task<ActionResult<List<GetPerfilAccesoDto>>> GetPerfilAcceso();
		Task<ActionResult> CreatePerfilAcceso(CreatePerfilAccesoDto createPerfilAccesoDto);
		Task<ActionResult> UpdatePerfilAcceso(UpdatePerfilAccesoDto updatePerfilAccesoDto);
		Task<ActionResult> DeletePerfilAcceso(int id);
		Task<ActionResult<GetPerfilAccesoDto>> GetPerfilAccesoById(int id);
	}
}
