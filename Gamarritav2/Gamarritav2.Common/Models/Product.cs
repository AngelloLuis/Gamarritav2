namespace Gamarritav2.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Required]
        public string description { get; set; }

        public Decimal price { get; set; }

        public bool isAvailable { get; set; }

        public DateTime publishOn { get; set; }
    }
}
