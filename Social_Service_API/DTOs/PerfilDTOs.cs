namespace Social_Service_API.DTOs
{
	public record GetPerfilDto(
		int id,
		string nombre,
		string clave
	);

	public record CreatePerfilDto(
		string nombre,
		string clave
	);

	public record UpdatePerfilDto(
		int id,
		string nombre,
		string clave
	);
}
