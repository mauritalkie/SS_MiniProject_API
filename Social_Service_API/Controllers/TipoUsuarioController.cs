using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Service_API.Data;
using Social_Service_API.Models;

namespace Social_Service_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoUsuarioController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public TipoUsuarioController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<TipoUsuario>>> getTipoUsuario()
		{
			return Ok(await _dataContext.TipoUsuario.ToListAsync());
		}
	}
}
