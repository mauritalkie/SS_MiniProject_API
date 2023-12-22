using Microsoft.EntityFrameworkCore;
using Social_Service_API.Models;

namespace Social_Service_API.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<TipoUsuario> TipoUsuario => Set<TipoUsuario>(); 
	}
}
