namespace Social_Service_API.DTOs
{
	public record GetPerfilAccesoDto(
		int id,
		int id_acceso,
		int id_perfil
	);

	public record CreatePerfilAccesoDto(
		int id_acceso,
		int id_perfil
	);

	public record UpdatePerfilAccesoDto(
		int id,
		int id_acceso,
		int id_perfil
	);
}
