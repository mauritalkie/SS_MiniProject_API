using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class PerfilAccesoMapper
	{
		public static GetPerfilAccesoDto AsDto(PerfilAcceso obj)
		{
			return new GetPerfilAccesoDto(
				obj.id,
				obj.id_acceso,
				obj.id_perfil
			);
		}

		public static PerfilAcceso AsObject(CreatePerfilAccesoDto dto)
		{
			return new PerfilAcceso
			{
				id_acceso = dto.id_acceso,
				id_perfil = dto.id_perfil
			};
		}
	}
}
