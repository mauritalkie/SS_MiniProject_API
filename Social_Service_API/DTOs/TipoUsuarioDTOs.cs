namespace Social_Service_API.DTOs
{
	public record GetTipoUsuarioDto(
		int id,
		string nombre,
		string clave
	);

	public record CreateTipoUsuarioDto(
		string nombre,
		string clave
	);

	public record UpdateTipoUsuarioDto(
		int id,
		string nombre,
		string clave
	);
}
