namespace Social_Service_API.DTOs
{
	public record GetClienteEstructuraDto(
		int id,
		string nombre,
		int id_cliente
	);

	public record CreateClienteEstructuraDto(
		string nombre,
		int id_cliente
	);

	public record UpdateClienteEstructuraDto(
		int id,
		string nombre
	);
}
