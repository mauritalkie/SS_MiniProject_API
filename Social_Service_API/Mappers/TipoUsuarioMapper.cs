using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class TipoUsuarioMapper
	{
		public static GetTipoUsuarioDto AsDto(TipoUsuario obj)
		{
			return new GetTipoUsuarioDto(
				obj.id,
				obj.nombre,
				obj.clave
			);
		}

		public static TipoUsuario AsObject(CreateTipoUsuarioDto dto)
		{
			return new TipoUsuario
			{
				nombre = dto.nombre,
				clave = dto.clave
			};
		}
	}
}
