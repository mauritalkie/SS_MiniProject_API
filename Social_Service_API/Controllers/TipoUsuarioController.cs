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
	public class TipoUsuarioController : ControllerBase
	{
		private readonly ITipoUsuarioService _tipoUsuarioService;

		public TipoUsuarioController(DataContext dataContext, ITipoUsuarioService tipoUsuarioService)
		{
			_tipoUsuarioService = tipoUsuarioService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetTipoUsuarioDto>>> GetTipoUsuario()
		{
			return await _tipoUsuarioService.GetTipoUsuario();
		}

		[HttpPost]
		public async Task<ActionResult> CreateTipoUsuario(CreateTipoUsuarioDto createTipoUsuarioDto)
		{
			return await _tipoUsuarioService.CreateTipoUsuario(createTipoUsuarioDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateTipoUsuario(UpdateTipoUsuarioDto updateTipoUsuarioDto)
		{
			return await _tipoUsuarioService.UpdateTipoUsuario(updateTipoUsuarioDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteTipoUsuario(int id)
		{
			return await _tipoUsuarioService.DeleteTipoUsuario(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetTipoUsuarioDto>> GetTipoUsuarioById(int id)
		{
			return await _tipoUsuarioService.GetTipoUsuarioById(id);
		}
	}
}
