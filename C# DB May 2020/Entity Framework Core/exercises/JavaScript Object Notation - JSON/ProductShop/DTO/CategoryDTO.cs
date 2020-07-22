namespace ProductShop.DTO
{
    using Newtonsoft.Json;

    class CategoryDTO
    {
        [JsonProperty("category")]
        public string CategoryName { get; set; }
        public int ProductsCount { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
