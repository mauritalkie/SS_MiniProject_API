using Social_Service_API.DTOs;
using Social_Service_API.Models;

namespace Social_Service_API.Mappers
{
	public class EstructuraAhorroMapper
	{
		public static GetEstructuraAhorroDto AsDto(EstructuraAhorro obj)
		{
			return new GetEstructuraAhorroDto(
				obj.id,
				obj.id_tipo_ahorro_cliente,
				obj.id_cliente_estructura
			);
		}

		public static EstructuraAhorro AsObject(CreateEstructuraAhorroDto dto)
		{
			return new EstructuraAhorro
			{
				id_tipo_ahorro_cliente = dto.id_tipo_ahorro_cliente,
				id_cliente_estructura = dto.id_cliente_estructura
			};
		}
	}
}
