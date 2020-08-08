namespace VaporStore.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ImportGameDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0d, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [DataType("date")]
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public string Genre { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
