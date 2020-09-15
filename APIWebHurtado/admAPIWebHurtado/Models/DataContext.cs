namespace admAPIWebHurtado.Models
{
	using System.Data.Entity;

	public class DataContext : DbContext
	{
		public DataContext() : base("DefaultConnection")
		{

		}

		public System.Data.Entity.DbSet<admAPIWebHurtado.Models.Hurtado> Hurtadoes { get; set; }
	}
}