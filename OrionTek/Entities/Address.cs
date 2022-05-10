namespace OrionTek.Entities
{
    public class Address : BaseModel
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
    }
}
