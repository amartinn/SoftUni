namespace ProductShop.DTO
{
    using System.Collections.Generic;
    public class UserWithSoldProductsDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SoldProductDTO> SoldProducts { get; set; }
    }
}
