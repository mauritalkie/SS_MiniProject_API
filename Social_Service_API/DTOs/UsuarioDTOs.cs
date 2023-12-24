namespace Social_Service_API.DTOs
{
	public record GetUsuarioDto(
		int id,
		string nombre,
		string apellido_paterno,
		string apellido_materno,
		int id_tipo_usuario
	);

	public record CreateUsuarioDto(
		string nombre,
		string apellido_paterno,
		string apellido_materno,
		string correo,
		string telefono,
		int id_tipo_usuario,
		string usuario,
		string contrasenia
	);

	public record UpdateUsuarioDto(
		int id,
		string nombre,
		string apellido_paterno,
		string apellido_materno,
		string correo,
		string telefono,
		string usuario,
		string contrasenia
	);

	public record GetOneUsuarioDto(
		int id,
		string nombre,
		string apellido_paterno,
		string apellido_materno,
		string correo,
		string telefono,
		string usuario
	);
}
