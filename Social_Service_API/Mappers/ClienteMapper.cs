using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class ClienteMapper
	{
		public static GetClienteDto AsDto(Cliente obj)
		{
			return new GetClienteDto(
				obj.id,
				obj.nombre
			);
		}

		public static Cliente AsObject(CreateClienteDto dto)
		{
			return new Cliente
			{
				numero = dto.numero,
				nombre = dto.nombre,
				rfc = dto.rfc,
				direccion = dto.direccion,
				correo = dto.correo
			};
		}

		public static GetOneClienteDto AsOneDto(Cliente obj)
		{
			return new GetOneClienteDto(
				obj.id,
				obj.numero,
				obj.nombre,
				obj.rfc,
				obj.direccion,
				obj.correo
			);
		}
	}
}
