using Microsoft.EntityFrameworkCore;
using Social_Service_API.Models;

namespace Social_Service_API.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<TipoUsuario> TipoUsuario => Set<TipoUsuario>();
		public DbSet<Acceso> Acceso => Set<Acceso>();
		public DbSet<Perfil> Perfil => Set<Perfil>();
		public DbSet<TipoAhorro> TipoAhorro => Set<TipoAhorro>();
		public DbSet<Usuario> Usuario => Set<Usuario>();
		public DbSet<PerfilAcceso> PerfilAcceso => Set<PerfilAcceso>();
		public DbSet<PerfilUsuario> PerfilUsuario => Set<PerfilUsuario>();
		public DbSet<Cliente> Cliente => Set<Cliente>();
		public DbSet<ClienteEstructura> ClienteEstructura => Set<ClienteEstructura>();
		public DbSet<TipoAhorroCliente> TipoAhorroCliente => Set<TipoAhorroCliente>();
		public DbSet<EstructuraAhorro> EstructuraAhorro => Set<EstructuraAhorro>();
	}
}
