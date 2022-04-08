using MerchantAPI.Model;
using MerchantAPI.Model.Response;

namespace MerchantAPI.Repository
{
    public interface IMerchantRepository
    {
        public MerchantResponse GetMerchants(int page, string? merchantCode);
        public Merchant GetMerchant(int id);
        public void CreateMerchant(Merchant merchant);
        public bool UpdateMerchant(int id, Merchant merchant);
        bool DeleteMerchant(int id);
        public void CreateStoreForMerchant(int id, Store store); //so id checkni dali postoi toj merchant 

        public bool UpdateStore(int id, Store store);
         bool deleteStore(int id);
        public Store GetStore(int id);

         public StoreResponse GetStores(int page, string? storeCode, string? merchantCode);
        //public StoreResponse GetStores(int page, string? storeCode);
        public bool UpdateStoreCode(string storeCode,Store store);
        bool DeleteStoreCode(string storeCode);
        public Store GetStoreCode(string storeCode);
        public void CreateStoreForMerchantCode(string merchantCode,Store store);


        public Merchant GetMerchantCode(string merchantCode);
        
        public bool UpdateMerchantCode(string merchantCode, Merchant merchant);
        bool DeleteMerchantCode(string merchantCode);


    }
}
