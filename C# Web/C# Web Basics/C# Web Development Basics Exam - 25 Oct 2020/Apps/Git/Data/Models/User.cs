namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }
        [Key]
        public string Id { get; set; }
        [Required,MinLength(5),MaxLength(20)]
        public string Username { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Repository> Repositories { get; set; }
        public ICollection<Commit> Commits { get; set; }
    }
}
