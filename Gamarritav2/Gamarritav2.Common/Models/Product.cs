namespace Gamarritav2.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        [Display(Name = "Image")]
        public string imagePath { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Decimal price { get; set; }

        [Display(Name = "Is Available")]
        public bool isAvailable { get; set; }

        [Display(Name ="Publish On")]
        [DataType(DataType.Date)]
        public DateTime publishOn { get; set; }

        public string imageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.imagePath))
                {
                    return "noproduct";
                }

                return $"https://gamarritav2backend20190530074714.azurewebsites.net/{this.imagePath.Substring(1)}";
            }
        }

        public override string ToString()
        {
            return this.description;
        }
    }
}
