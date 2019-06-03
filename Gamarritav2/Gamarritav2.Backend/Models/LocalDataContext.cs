namespace Gamarritav2.Backend.Models
{
    using Gamarritav2.Domain.Models;

    public class LocalDataContext: DataContext
    {
        public System.Data.Entity.DbSet<Gamarritav2.Common.Models.Product> Products { get; set; }
    }
}