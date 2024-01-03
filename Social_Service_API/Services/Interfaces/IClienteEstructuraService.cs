using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface IClienteEstructuraService
	{
		Task<ActionResult<List<GetClienteEstructuraDto>>> GetClienteEstructura();
		Task<ActionResult> CreateClienteEstructura(CreateClienteEstructuraDto createClienteEstructuraDto);
		Task<ActionResult> UpdateClienteEstructura(UpdateClienteEstructuraDto updateClienteEstructuraDto);
		Task<ActionResult> DeleteClienteEstructura(int id);
		Task<ActionResult<GetClienteEstructuraDto>> GetClienteEstructuraById(int id);
	}
}
