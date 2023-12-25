using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class ClienteEstructuraMapper
	{
		public static GetClienteEstructuraDto AsDto(ClienteEstructura obj)
		{
			return new GetClienteEstructuraDto(
				obj.id,
				obj.nombre,
				obj.id_cliente
			);
		}

		public static ClienteEstructura AsObject(CreateClienteEstructuraDto dto)
		{
			return new ClienteEstructura
			{
				nombre = dto.nombre,
				id_cliente = dto.id_cliente
			};
		}
	}
}
