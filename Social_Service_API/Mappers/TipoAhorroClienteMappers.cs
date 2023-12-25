using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class TipoAhorroClienteMappers
	{
		public static GetTipoAhorroClienteDto AsDto(TipoAhorroCliente obj)
		{
			return new GetTipoAhorroClienteDto(
				obj.id,
				obj.alias,
				obj.id_cliente
			);
		}

		public static TipoAhorroCliente AsObject(CreateTipoAhorroClienteDto dto)
		{
			return new TipoAhorroCliente
			{
				alias = dto.alias,
				id_cliente = dto.id_cliente
			};
		}
	}
}
