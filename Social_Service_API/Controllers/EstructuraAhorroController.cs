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
	public class EstructuraAhorroController : ControllerBase
	{
		private readonly IEstructuraAhorroService _estructuraAhorroService;

		public EstructuraAhorroController(IEstructuraAhorroService estructuraAhorroService)
		{
			_estructuraAhorroService = estructuraAhorroService;
		}

		[HttpGet]
		public async Task<ActionResult<List<GetEstructuraAhorroDto>>> GetEstructuraAhorro()
		{
			return await _estructuraAhorroService.GetEstructuraAhorro();
		}

		[HttpPost]
		public async Task<ActionResult> CreateEstructuraAhorro(CreateEstructuraAhorroDto createEstructuraAhorroDto)
		{
			return await _estructuraAhorroService.CreateEstructuraAhorro(createEstructuraAhorroDto);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateEstructuraAhorro(UpdateEstructuraAhorroDto updateEstructuraAhorroDto)
		{
			return await _estructuraAhorroService.UpdateEstructuraAhorro(updateEstructuraAhorroDto);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteEstructuraAhorro(int id)
		{
			return await _estructuraAhorroService.DeleteEstructuraAhorro(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetEstructuraAhorroDto>> GetEstructuraAhorroById(int id)
		{
			return await _estructuraAhorroService.GetEstructuraAhorroById(id);
		}
	}
}
