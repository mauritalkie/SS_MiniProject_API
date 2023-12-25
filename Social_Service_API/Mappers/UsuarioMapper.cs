using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class UsuarioMapper
	{
		public static GetUsuarioDto AsDto(Usuario obj)
		{
			return new GetUsuarioDto(
				obj.id,
				obj.nombre,
				obj.apellido_paterno,
				obj.apellido_materno,
				obj.id_tipo_usuario
			);
		}

		public static Usuario AsObject(CreateUsuarioDto dto)
		{
			return new Usuario
			{
				nombre = dto.nombre,
				apellido_paterno = dto.apellido_paterno,
				apellido_materno = dto.apellido_materno,
				correo = dto.correo,
				telefono = dto.telefono,
				id_tipo_usuario = dto.id_tipo_usuario,
				usuario = dto.usuario,
				contrasenia = dto.contrasenia
			};
		}

		public static GetOneUsuarioDto AsOneDto(Usuario obj)
		{
			return new GetOneUsuarioDto(
				obj.id,
				obj.nombre,
				obj.apellido_paterno,
				obj.apellido_materno,
				obj.correo,
				obj.telefono,
				obj.usuario
			);
		}
	}
}
