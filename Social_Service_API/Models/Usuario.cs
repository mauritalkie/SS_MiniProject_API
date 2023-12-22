namespace Social_Service_API.Models
{
	public class Usuario
	{
		public int id { get; set; }
		public string nombre { get; set; }
		public string apellido_paterno { get; set; }
		public string apellido_materno { get; set; }
		public string correo { get; set; }
		public string telefono { get; set; }
		public int id_tipo_usuario { get; set; }
		public string usuario { get; set; }
		public string contrasenia { get; set; }
	}
}
