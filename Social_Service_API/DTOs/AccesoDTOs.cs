namespace Social_Service_API.DTOs
{
	public record GetAccesoDto(
		int id,
		string clave,
		string nombre
	);

	public record CreateAccesoDto(
		string clave,
		string nombre
	);

	public record UpdateAccesoDto(
		int id,
		string clave,
		string nombre
	);
}
