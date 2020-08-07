using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorWithBooksDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}")]
        public string Phone { get; set; }
        public ICollection<AuthorBookDTO> Books { get; set; }
    }
}
