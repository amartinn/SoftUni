namespace BookShop.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Range(0.01d,(double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [Range(50,5000)]
        public int Pages { get; set; }
        [Required]
        public DateTime PublishedOn  { get; set; }
        public ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
