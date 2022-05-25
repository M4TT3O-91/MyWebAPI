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
        [PosNumber(ErrorMessage = "need a positive number")]
        public decimal Price { get; set; }
        [Required]
        [PosNumber(ErrorMessage = "need a positive number")]
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
