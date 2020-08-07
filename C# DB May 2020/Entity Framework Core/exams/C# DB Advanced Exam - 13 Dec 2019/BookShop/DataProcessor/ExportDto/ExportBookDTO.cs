namespace BookShop.DataProcessor.ExportDto
{
    using Newtonsoft.Json;
    public class ExportBookDTO
    {
        [JsonProperty("BookName")]
        public string Name { get; set; }
        [JsonProperty("BookPrice")]
        public string Price { get; set; }
    }
}