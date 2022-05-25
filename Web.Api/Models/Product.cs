using System.ComponentModel.DataAnnotations;

namespace Web.Api.Models
{
    public class Product
    {
        [PosNumberNoZero(ErrorMessage ="ID must be equal or greater than 1")]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [PosNumber(ErrorMessage = "Price must be a positive number or zero")]
        public decimal Price { get; set; }
        [Required]
        [PosNumber(ErrorMessage = "Price must be a positive number or zero")]
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
