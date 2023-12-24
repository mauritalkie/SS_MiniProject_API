namespace Social_Service_API.DTOs
{
	public record GetPerfilUsuarioDto(
		int id,
		int id_usuario,
		int id_perfil
	);

	public record CreatePerfilUsuarioDto(
		int id_usuario,
		int id_perfil
	);

	public record UpdatePerfilUsuarioDto(
		int id,
		int id_usuario,
		int id_perfil
	);
}
