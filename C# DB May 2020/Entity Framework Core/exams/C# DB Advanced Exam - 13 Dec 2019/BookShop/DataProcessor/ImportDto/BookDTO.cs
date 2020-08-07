namespace BookShop.DataProcessor.ImportDto
{
    using Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;


    [XmlType("Book")]
    public class BookDTO
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }
        [XmlElement("Price")]
        [Required]
        [Range(0.01d, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [XmlElement("Pages")]
        [Required]
        [Range(50, 5000)]
        public int Pages { get; set; }
        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}
