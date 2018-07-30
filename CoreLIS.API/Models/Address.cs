namespace CoreLIS.API.Models
{
    public class Address :BaseModel
    {
        public int AddressTypeId { get; set; }  
        public string AttentionOrDepartment { get; set; }
        public string StreetAddress { get; set; }   
        public string City { get; set; }    
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string InternalNote { get; set; }
        public GeoLocation Location { get; set; }
    }
}