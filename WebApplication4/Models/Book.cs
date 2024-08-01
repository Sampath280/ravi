namespace WebApplication4.Models
{
    using System.ComponentModel.DataAnnotations;

    namespace BookStoreAPI.Models
    {
        public class Book
        {
            [Key]
            public int BookId { get; set; }

            [Required]
            [MaxLength(200)]
            public string? Title { get; set; }

            [Required]
            [MaxLength(100)]
            public string? Author { get; set; }

            public decimal Price { get; set; }

            public int Year { get; set; }
        }
    }

}
