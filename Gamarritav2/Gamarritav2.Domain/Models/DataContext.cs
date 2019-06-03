namespace Gamarritav2.Domain.Models
{
    using System.Data.Entity;

    public class DataContext: DbContext
    {
        public DataContext(): base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Gamarritav2.Common.Models.Product> Products { get; set; }
    }
}
