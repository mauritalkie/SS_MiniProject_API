using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class PerfilMapper
	{
		public static GetPerfilDto AsDto(Perfil obj)
		{
			return new GetPerfilDto(
				obj.id,
				obj.clave,
				obj.nombre
			);
		}

		public static Perfil AsObject(CreatePerfilDto dto)
		{
			return new Perfil
			{
				nombre = dto.nombre,
				clave = dto.clave
			};
		}
	}
}
