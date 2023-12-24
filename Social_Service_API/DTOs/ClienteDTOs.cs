namespace Social_Service_API.DTOs
{
	public record GetClienteDto(
		int id,
		string nombre
	);

	public record CreateClienteDto(
		string numero,
		string nombre,
		string rfc,
		string direccion,
		string correo
	);

	public record UpdateClienteDto(
		int id,
		string numero,
		string nombre,
		string rfc,
		string direccion,
		string correo
	);

	public record GetOneClienteDto(
		int id,
		string numero,
		string nombre,
		string rfc,
		string direccion,
		string correo
	);
}
