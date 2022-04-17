using MerchantAPI.Model;
using MerchantAPI.Model.Response;

namespace MerchantAPI.Repository
{
    public interface IMerchantRepository
    {
        public MerchantResponse GetMerchants(int page, string? merchantCode);
        public void CreateMerchant(Merchant merchant);     
        public StoreResponse GetStores(int page, string? storeCode, string? merchantCode);
        //public StoreResponse GetStores(int page, string? storeCode); Previous method i used for fetching store
        public bool UpdateStoreCode(string storeCode,Store store);
        bool DeleteStoreCode(string storeCode);
        public Store GetStoreCode(string storeCode);
        public void CreateStoreForMerchantCode(string merchantCode,Store store);
        public Merchant GetMerchantCode(string merchantCode);
        public bool UpdateMerchantCode(string merchantCode, Merchant merchant);
        bool DeleteMerchantCode(string merchantCode);


    }
}
