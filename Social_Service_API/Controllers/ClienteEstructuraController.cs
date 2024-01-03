using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteEstructuraController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public ClienteEstructuraController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetClienteEstructuraDto>>> GetClienteEstructura()
		{
			List<ClienteEstructura> objects = await _dataContext.ClienteEstructura.ToListAsync();
			List<GetClienteEstructuraDto> dtos = objects.Select(obj => ClienteEstructuraMapper.AsDto(obj)).ToList();
			return Ok(dtos);
		}

		[HttpPost]
		public async Task<ActionResult> CreateClienteEstructura(CreateClienteEstructuraDto createClienteEstructuraDto)
		{
			ClienteEstructura clienteEstructura = ClienteEstructuraMapper.AsObject(createClienteEstructuraDto);

			_dataContext.ClienteEstructura.Add(clienteEstructura);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateClienteEstructura(UpdateClienteEstructuraDto updateClienteEstructuraDto)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(updateClienteEstructuraDto.id);
			if (dbClienteEstructura == null) return BadRequest("La estructura del cliente no fue encontrada");

			dbClienteEstructura.nombre = updateClienteEstructuraDto.nombre;

			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteClienteEstructura(int id)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(id);
			if (dbClienteEstructura == null) return BadRequest("La estructura del cliente no fue encontrada");

			_dataContext.ClienteEstructura.Remove(dbClienteEstructura);
			var response = await _dataContext.SaveChangesAsync();

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<ClienteEstructura>>> GetClienteEstructuraById(int id)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(id);
			if (dbClienteEstructura == null) return BadRequest("La estructura del cliente no fue encontrada");

			return Ok(ClienteEstructuraMapper.AsDto(dbClienteEstructura));
		}
	}
}
