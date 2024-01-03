using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class ClienteEstructuraService : IClienteEstructuraService
	{
		private readonly DataContext _dataContext;

		public ClienteEstructuraService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreateClienteEstructura(CreateClienteEstructuraDto createClienteEstructuraDto)
		{
			ClienteEstructura clienteEstructura = ClienteEstructuraMapper.AsObject(createClienteEstructuraDto);

			_dataContext.ClienteEstructura.Add(clienteEstructura);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeleteClienteEstructura(int id)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(id);
			if (dbClienteEstructura == null) return new JsonResult("La estructura del cliente no fue encontrada");

			_dataContext.ClienteEstructura.Remove(dbClienteEstructura);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetClienteEstructuraDto>>> GetClienteEstructura()
		{
			List<ClienteEstructura> objects = await _dataContext.ClienteEstructura.ToListAsync();
			List<GetClienteEstructuraDto> dtos = objects.Select(obj => ClienteEstructuraMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetClienteEstructuraDto>> GetClienteEstructuraById(int id)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(id);
			if (dbClienteEstructura == null) return new JsonResult("La estructura del cliente no fue encontrada");

			return ClienteEstructuraMapper.AsDto(dbClienteEstructura);
		}

		public async Task<ActionResult> UpdateClienteEstructura(UpdateClienteEstructuraDto updateClienteEstructuraDto)
		{
			var dbClienteEstructura = await _dataContext.ClienteEstructura.FindAsync(updateClienteEstructuraDto.id);
			if (dbClienteEstructura == null) return new JsonResult("La estructura del cliente no fue encontrada");

			dbClienteEstructura.nombre = updateClienteEstructuraDto.nombre;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
