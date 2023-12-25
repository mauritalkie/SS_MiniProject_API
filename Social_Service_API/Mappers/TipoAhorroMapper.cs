using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class TipoAhorroMapper
	{
		public static GetTipoAhorroDto AsDto(TipoAhorro obj)
		{
			return new GetTipoAhorroDto(
				obj.id,
				obj.nombre,
				obj.clave
			);
		}

		public static TipoAhorro AsObject(CreateTipoAhorroDto dto)
		{
			return new TipoAhorro
			{
				nombre = dto.nombre,
				clave = dto.clave
			};
		}
	}
}
