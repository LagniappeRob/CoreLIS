namespace CoreLIS.API.Models
{
    public class Contact : BaseModel
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }

        public int ClientId { get; set; }
    }
}