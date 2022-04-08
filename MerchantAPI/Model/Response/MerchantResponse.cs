namespace MerchantAPI.Model.Response
{
    public class MerchantResponse
    {
     
        public List<Merchant> Merchants { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}
