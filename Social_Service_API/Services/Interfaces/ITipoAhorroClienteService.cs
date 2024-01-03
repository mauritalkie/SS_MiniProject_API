using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface ITipoAhorroClienteService
	{
		Task<ActionResult<List<GetTipoAhorroClienteDto>>> GetTipoAhorroCliente();
		Task<ActionResult> CreateTipoAhorroCliente(CreateTipoAhorroClienteDto createTipoAhorroClienteDto);
		Task<ActionResult> UpdateTipoAhorroCliente(UpdateTipoAhorroClienteDto updateTipoAhorroClienteDto);
		Task<ActionResult> DeleteTipoAhorroCliente(int id);
		Task<ActionResult<GetTipoAhorroClienteDto>> GetTipoAhorroClienteById(int id);
	}
}
