namespace VaporStore.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportUserDTO
    {

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Username { get; set; }
        [DataType("varchar")]
        [Required]
        [RegularExpression("^[A-z]{1}[a-z]+ [A-z]{1}[a-z]+$")]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Range(3, 103)]
        [Required]
        public int Age { get; set; }
        public virtual ICollection<ImportCardDTO> Cards { get; set; }
    }
}
