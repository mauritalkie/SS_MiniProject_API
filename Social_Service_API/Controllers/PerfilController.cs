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
	public class PerfilController : ControllerBase
	{
		private readonly IPerfilService _perfilService;

		public PerfilController(IPerfilService perfilService)
		{
			_perfilService = perfilService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetPerfilDto>>> GetPerfil()
		{
			return await _perfilService.GetPerfil();
		}

		[HttpPost]
		public async Task<ActionResult> CreatePerfil(CreatePerfilDto createPerfilDto)
		{
			return await _perfilService.CreatePerfil(createPerfilDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdatePerfil(UpdatePerfilDto updatePerfilDto)
		{
			return await _perfilService.UpdatePerfil(updatePerfilDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePerfil(int id)
		{
			return await _perfilService.DeletePerfil(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetPerfilDto>> GetPerfilById(int id)
		{
			return await _perfilService.GetPerfilById(id);
		}
	}
}
