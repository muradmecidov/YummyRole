using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
