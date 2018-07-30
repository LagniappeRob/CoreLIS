namespace CoreLIS.API.Models
{
    public class Client : BaseModel
    { 
        public string Name { get; set; }
        public Contact PrimaryContact { get; set; }

    }
}