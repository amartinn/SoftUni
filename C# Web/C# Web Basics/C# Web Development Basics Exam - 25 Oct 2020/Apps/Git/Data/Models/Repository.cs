namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Repository
    {
        public Repository()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required,MinLength(3),MaxLength(10)]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public User Owner { get; set; }
        public string OwnerId { get; set; }
        public ICollection<Commit> Commits { get; set; }
    }
}