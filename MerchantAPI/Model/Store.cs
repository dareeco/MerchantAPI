using System.ComponentModel.DataAnnotations.Schema;


namespace MerchantAPI.Model
{
    public class Store
    {
        public int Id { get; set; }
        public string storeCode { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public int merchantId { get; set; }   
        public string merchantCode { get; set; }   

        
    }
}
