namespace VaporStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Cards = new HashSet<Card>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(20,MinimumLength =3)]
        [Required]
        public string Username { get; set; }
        [DataType("varchar")]
        [Required]
        [RegularExpression("^[A-z]{1}[a-z]+ [A-z]{1}[a-z]+$")]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Range(3,103)]
        [Required]
        public int Age { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

    }
}
