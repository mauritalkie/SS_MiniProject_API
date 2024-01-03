using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface IAccesoService
	{
		Task<ActionResult<List<GetAccesoDto>>> GetAcceso();
		Task<ActionResult> CreateAcceso(CreateAccesoDto createAccesoDto);
		Task<ActionResult> UpdateAcceso(UpdateAccesoDto updateAccesoDto);
		Task<ActionResult> DeleteAcceso(int id);
		Task<ActionResult<GetAccesoDto>> GetAccesoById(int id);
	}
}
