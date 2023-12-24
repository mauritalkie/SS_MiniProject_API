namespace Social_Service_API.DTOs
{
	public record GetEstructuraAhorroDto(
		int id,
		int id_tipo_ahorro_cliente,
		int id_cliente_estructura
	);

	public record CreateEstructuraAhorroDto(
		int id_tipo_ahorro_cliente,
		int id_cliente_estructura
	);

	public record UpdateEstructuraAhorroDto(
		int id,
		int id_tipo_ahorro_cliente,
		int id_cliente_estructura
	);
}
