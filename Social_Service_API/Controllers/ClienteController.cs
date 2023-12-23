using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public ClienteController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<Cliente>>> GetCliente()
		{
			return Ok(await _dataContext.Cliente.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<List<Cliente>>> CreateCliente(Cliente cliente)
		{
			_dataContext.Cliente.Add(cliente);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Cliente.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<Cliente>>> UpdateCliente(Cliente cliente)
		{
			var dbCliente = await _dataContext.Cliente.FindAsync(cliente.id);
			if (dbCliente == null) return BadRequest("El cliente no fue encontrado");

			dbCliente.numero = cliente.numero;
			dbCliente.nombre = cliente.nombre;
			dbCliente.rfc = cliente.rfc;
			dbCliente.direccion = cliente.direccion;
			dbCliente.correo = cliente.correo;

			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Cliente.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Cliente>>> DeleteCliente(int id)
		{
			var dbCliente = await _dataContext.Cliente.FindAsync(id);
			if (dbCliente == null) return BadRequest("El cliente no fue encontrado");

			_dataContext.Cliente.Remove(dbCliente);
			await _dataContext.SaveChangesAsync();

			return Ok(await _dataContext.Cliente.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<Cliente>>> GetClienteById(int id)
		{
			var dbCliente = await _dataContext.Cliente.FindAsync(id);
			if (dbCliente == null) return BadRequest("El cliente no fue encontrado");

			return Ok(dbCliente);
		}
	}
}
