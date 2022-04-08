namespace MerchantAPI.Model.Response
{
    public class StoreResponse
    {
        public List<Store> Stores { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}
