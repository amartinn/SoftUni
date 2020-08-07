namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]   
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [DataType("nvarchar")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}")]
        public string Phone { get; set; }
        public ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
