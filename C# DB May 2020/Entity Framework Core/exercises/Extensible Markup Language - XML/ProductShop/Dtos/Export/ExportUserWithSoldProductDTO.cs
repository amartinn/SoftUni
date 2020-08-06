namespace ProductShop.Dtos.Export
{

    using System.Xml.Serialization;

    [XmlType("User")]
   public class ExportUserWithSoldProductDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ExportSoldProductDTO[] SoldProducts { get; set; }
    }
}
