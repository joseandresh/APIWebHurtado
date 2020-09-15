namespace APIWebHurtado.Models
{
	using System.Data.Entity;

	public class DataContext : DbContext
	{
		public DataContext() : base("DefaultConnection")
		{

		}

		public System.Data.Entity.DbSet<APIWebHurtado.Models.Hurtado> Hurtadoes { get; set; }
	}
}