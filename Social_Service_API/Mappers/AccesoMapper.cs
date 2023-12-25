using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class AccesoMapper
	{
		public static GetAccesoDto AsDto(Acceso obj)
		{
			return new GetAccesoDto(
				obj.id,
				obj.clave,
				obj.nombre
			);
		}

		public static Acceso AsObject(CreateAccesoDto dto)
		{
			return new Acceso
			{
				clave = dto.clave,
				nombre = dto.nombre
			};
		}
	}
}
