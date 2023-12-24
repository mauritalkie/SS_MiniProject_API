namespace Social_Service_API.DTOs
{
	public record GetTipoAhorroClienteDto(
		int id,
		string alias,
		int id_cliente
	);

	public record CreateTipoAhorroClienteDto(
		string alias,
		int id_cliente
	);

	public record UpdateTipoAhorroClienteDto(
		int id,
		string alias
	);
}
