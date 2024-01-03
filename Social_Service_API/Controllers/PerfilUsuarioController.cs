using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.DTOs;
using Social_Service_API.Mappers;
using Social_Service_API.Models;
using Social_Service_API.Services.Interfaces;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PerfilUsuarioController : ControllerBase
	{
		private readonly IPerfilUsuarioService _perfilUsuarioService;

		public PerfilUsuarioController(IPerfilUsuarioService perfilUsuarioService)
		{
			_perfilUsuarioService = perfilUsuarioService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetPerfilUsuarioDto>>> GetPerfilUsuario()
		{
			return await _perfilUsuarioService.GetPerfilUsuario();
		}

		[HttpPost]
		public async Task<ActionResult> CreatePerfilUsuario(CreatePerfilUsuarioDto createPerfilUsuarioDto)
		{
			return await _perfilUsuarioService.CreatePerfilUsuario(createPerfilUsuarioDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdatePerfilUsuario(UpdatePerfilUsuarioDto updatePerfilUsuarioDto)
		{
			return await _perfilUsuarioService.UpdatePerfilUsuario(updatePerfilUsuarioDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePerfilUsuario(int id)
		{
			return await _perfilUsuarioService.DeletePerfilUsuario(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetPerfilUsuarioDto>> GetPerfilUsuarioById(int id)
		{
			return await _perfilUsuarioService.GetPerfilUsuarioById(id);
		}
	}
}
