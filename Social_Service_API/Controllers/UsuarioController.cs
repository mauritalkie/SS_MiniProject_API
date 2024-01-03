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
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetUsuarioDto>>> GetUsuario()
		{
			return await _usuarioService.GetUsuario();
		}

		[HttpPost]
		public async Task<ActionResult> CreateUsuario(CreateUsuarioDto createUsuarioDto)
		{
			return await _usuarioService.CreateUsuario(createUsuarioDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateUsuario(UpdateUsuarioDto updateUsuarioDto)
		{
			return await _usuarioService.UpdateUsuario(updateUsuarioDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteUsuario(int id)
		{
			return await _usuarioService.DeleteUsuario(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetOneUsuarioDto>> GetUsuarioById(int id)
		{
			return await _usuarioService.GetUsuarioById(id);
		}
	}
}
