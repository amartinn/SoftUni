﻿using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class ExportPurchaseDTO
    {
        [XmlElement("Card")]
        public string Card { get; set; }
        [XmlElement("Cvc")]
        public string Cvc { get; set; }
        [XmlElement("Dat")]
        public string Date { get; set; }
        [XmlElement("Game")]
        public ExportGameDTO Game { get; set; }
    }
}