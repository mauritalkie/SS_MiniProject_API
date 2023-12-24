namespace Social_Service_API.DTOs
{
	public record GetTipoAhorroDto(
		int id,
		string nombre,
		string clave
	);

	public record CreateTipoAhorroDto(
		string nombre,
		string clave
	);

	public record UpdateTipoAhorroDto(
		int id,
		string nombre,
		string clave
	);
}
