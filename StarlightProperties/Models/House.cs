using System.ComponentModel.DataAnnotations;

namespace StarlightProperties.Models
{
    public class House
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Property Name")]
        [DataType(DataType.Text)]
        public string? PropertyName { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Owner Name")]
        [DataType(DataType.Text)]
        public string? OwnerName { get; set; }

        [Required]
        [Display(Name = "Owner Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public int OwnerContact { get; set; }

        [Required]
        [Display(Name = "Property Value")]
        [DataType(DataType.Currency)]
        public int PropertyValue { get; set; }

        [Required]
        [Display(Name = "Property Size")]
        [DataType(DataType.Text)]
        public int PropertySize { get; set; }

        [Required]
        [Display(Name = "Number of Rooms")]
        [DataType(DataType.Text)]
        public int NumberRoom { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Location")]
        [DataType(DataType.Text)]
        public string? Location { get; set; }

    }
}
