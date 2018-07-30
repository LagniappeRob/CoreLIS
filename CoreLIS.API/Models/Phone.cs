namespace CoreLIS.API.Models
{
    public class Phone : BaseModel
    {
        public int PhoneTypeId { get; set; }
        public string Number { get; set; }
        public string Note { get; set; }
    }
}