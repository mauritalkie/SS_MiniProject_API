using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class PerfilUsuarioMapper
	{
		public static GetPerfilUsuarioDto AsDto(PerfilUsuario obj)
		{
			return new GetPerfilUsuarioDto(
				obj.id,
				obj.id_usuario,
				obj.id_perfil
			);
		}

		public static PerfilUsuario AsObject(CreatePerfilUsuarioDto dto)
		{
			return new PerfilUsuario
			{
				id_usuario = dto.id_usuario,
				id_perfil = dto.id_perfil
			};
		}
	}
}
