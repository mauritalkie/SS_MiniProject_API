using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Services
{
	public class ClienteService : IClienteService
	{
		private readonly DataContext _dataContext;

		public ClienteService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ActionResult> CreateCliente(CreateClienteDto createClienteDto)
		{
			Cliente cliente = ClienteMapper.AsObject(createClienteDto);

			_dataContext.Cliente.Add(cliente);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult> DeleteCliente(int id)
		{
			var dbCliente = await _dataContext.Cliente.FindAsync(id);
			if (dbCliente == null) return new JsonResult("El cliente no fue encontrado");

			_dataContext.Cliente.Remove(dbCliente);
			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}

		public async Task<ActionResult<List<GetClienteDto>>> GetCliente()
		{
			List<Cliente> objects = await _dataContext.Cliente.ToListAsync();
			List<GetClienteDto> dtos = objects.Select(obj => ClienteMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<GetOneClienteDto>> GetClienteById(int id)
		{
			var dbCliente = await _dataContext.Cliente.FindAsync(id);
			if (dbCliente == null) return new JsonResult("El cliente no fue encontrado");

			return ClienteMapper.AsOneDto(dbCliente);
		}

		public async Task<ActionResult> UpdateCliente(UpdateClienteDto updateClienteDto)
		{
			var dbCliente = await _dataContext.Cliente.FindAsync(updateClienteDto.id);
			if (dbCliente == null) return new JsonResult("El cliente no fue encontrado");

			dbCliente.numero = updateClienteDto.numero;
			dbCliente.nombre = updateClienteDto.nombre;
			dbCliente.rfc = updateClienteDto.rfc;
			dbCliente.direccion = updateClienteDto.direccion;
			dbCliente.correo = updateClienteDto.correo;

			var response = await _dataContext.SaveChangesAsync();

			return new JsonResult(response);
		}
	}
}
