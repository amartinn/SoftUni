using System;
using System.ComponentModel.DataAnnotations;

namespace RescueRegister.Models
{
    public class Mountaineer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        public  string  LastSeenDate { get; set; }
    }
}
