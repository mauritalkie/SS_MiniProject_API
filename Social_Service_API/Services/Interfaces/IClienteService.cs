using Microsoft.AspNetCore.Mvc;
using Social_Service_API.DTOs;

namespace Social_Service_API.Services.Interfaces
{
	public interface IClienteService
	{
		Task<ActionResult<List<GetClienteDto>>> GetCliente();
		Task<ActionResult> CreateCliente(CreateClienteDto createClienteDto);
		Task<ActionResult> UpdateCliente(UpdateClienteDto updateClienteDto);
		Task<ActionResult> DeleteCliente(int id);
		Task<ActionResult<GetOneClienteDto>> GetClienteById(int id);
	}
}
