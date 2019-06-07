namespace Gamarritav2.Backend.Models
{
    using Common.Models;
    using System.Web;

    public class ProductView: Product
    {
        public HttpPostedFileBase imageFile { get; set; }

    }
}