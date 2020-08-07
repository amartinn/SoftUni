namespace BookShop.DataProcessor.ExportDto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class ExportAuthorBookDTO
    {
        [JsonProperty("AuthorName")]
        public string Name { get; set; }
        public ICollection<ExportBookDTO> Books { get; set; }
    }
}
