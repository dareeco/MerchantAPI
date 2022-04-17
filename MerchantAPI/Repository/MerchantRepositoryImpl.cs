using MerchantAPI.Database;
using MerchantAPI.Model;
using MerchantAPI.Model.Response;

namespace MerchantAPI.Repository
{
    public class MerchantRepositoryImpl : IMerchantRepository
    {
        private readonly MerchantDbContext _merchantDbContext;
        public MerchantRepositoryImpl(MerchantDbContext merchantDbContext)
        {
            _merchantDbContext = merchantDbContext;
        }
        public void CreateMerchant(Merchant merchant)
        {
            _merchantDbContext.Merchants.Add(merchant);
            _merchantDbContext.SaveChanges();
        } 
        public MerchantResponse GetMerchants(int page, string? merchantCode)
        {
            var defaultPageSize = 10f;
            var merchants = _merchantDbContext.Merchants.ToList();

            var pageCount = Math.Ceiling(merchants.Count / defaultPageSize);

            if (!string.IsNullOrEmpty(merchantCode) && merchants.Count > 0)
            {
                merchants = merchants.Where(x => x.merchantCode == merchantCode).ToList();    //dali e okej ovaj del merchantCode == merchantCode
                pageCount = Math.Ceiling(merchants.Count / defaultPageSize);
            }
            var MerchantsPaged = merchants.Skip((page - 1) * (int)defaultPageSize).Take((int)defaultPageSize).ToList();
            MerchantResponse merchantResponse = new MerchantResponse
            {
                Merchants = MerchantsPaged,
                CurrentPage = page,
                Pages = (int)pageCount   //atributi se ovie ne ; na krajo tuku samo zapirki
            };
            return merchantResponse;
        }
        public StoreResponse GetStores(int page, string? storeCode, string? merchantCode)
        {
            var defaultPageSize = 10f;
           // var stores = _merchantDbContext.Stores.ToList();
            var filterNeeded = _merchantDbContext.Stores.ToList();
            var stores = new List<Store>();
            foreach (var store in filterNeeded)
            {
                if (store.merchantCode == merchantCode)
                {
                    stores.Add(store);
                }
            }

            var pageCount = Math.Ceiling(stores.Count / defaultPageSize);

            if (!string.IsNullOrEmpty(storeCode) && stores.Count > 0)
            {
                stores = stores.Where(x => x.storeCode == storeCode).ToList();    //proveri id da ne treba mesto storecode
                pageCount = Math.Ceiling(stores.Count / defaultPageSize);
            }
            var StoresPaged = stores.Skip((page - 1) * (int)defaultPageSize).Take((int)defaultPageSize).ToList();
            StoreResponse storeResponse = new StoreResponse
            {
                Stores = StoresPaged,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return storeResponse;
        }
        public bool UpdateStoreCode(string storeCode, Store store)
        {
            var storeFromDatabase = _merchantDbContext.Stores.Where(x => x.storeCode == storeCode).FirstOrDefault();
            if (storeFromDatabase == null)
            {
                return false;
            }
            storeFromDatabase.storeCode = store.storeCode;
            storeFromDatabase.phone = store.phone;
            storeFromDatabase.name = store.name;
            storeFromDatabase.address = store.address;
            storeFromDatabase.description = store.description;
            storeFromDatabase.city = store.city;
            storeFromDatabase.email = store.email;
            _merchantDbContext.SaveChanges();
            return true;
        }

        public bool DeleteStoreCode(string storeCode)
        {
            var storeFromDatabase = _merchantDbContext.Stores.FirstOrDefault(s => s.storeCode == storeCode);
            if (storeFromDatabase == null)
            {
                return false;
            }
            _merchantDbContext.Stores.Remove(storeFromDatabase);
            _merchantDbContext.SaveChanges();
            return true;
        }

        public Store GetStoreCode(string storeCode)
        {
            var store = _merchantDbContext.Stores.FirstOrDefault(s => s.storeCode == storeCode);
            return store;
        }

        public void CreateStoreForMerchantCode(string merchantCode, Store store)
        {
            var merchantFromDatabase = _merchantDbContext.Merchants.FirstOrDefault(x => x.merchantCode == merchantCode);
            // if(merchantFromDatabase == null)
            //{
            //    return FileNotFoundException prashaj dali mozhi vaka
            // }
            _merchantDbContext.Stores.Add(store);
            _merchantDbContext.SaveChanges();
        }
        public Merchant GetMerchantCode(string merchantCode)
        {
            
            var merchant = _merchantDbContext.Merchants.Where(x => x.merchantCode == merchantCode).FirstOrDefault();//da go najdi toj so id
            return merchant;
        }
        public bool DeleteMerchantCode(string merchantCode)
        {
            var merchantFromDatabase = _merchantDbContext.Merchants.FirstOrDefault(x => x.merchantCode == merchantCode);
            //Nov ponuden nachin od Visual Studio, treba da e isto. ako pagja meni so _merchantDbContext.Merchants.Where(x => x.Id ==id).FirstOrDefault()

            if (merchantFromDatabase == null)
            {
                return false;
            }
            _merchantDbContext.Merchants.Remove(merchantFromDatabase);
            _merchantDbContext.SaveChanges();
            return true;

        }

        public bool UpdateMerchantCode(string merchantCode, Merchant merchant)
        {
            var merchantFromDatabase = _merchantDbContext.Merchants.Where(x => x.merchantCode == merchantCode).FirstOrDefault();   //go bara so to id

            if (merchantFromDatabase == null)
            {
                return false; //ako ne postoi merchant so to id
            }

            merchantFromDatabase.merchantCode = merchant.merchantCode;
            merchantFromDatabase.merchantName = merchant.merchantName;
            merchantFromDatabase.fullName = merchant.fullName;
            merchantFromDatabase.email = merchant.email;
            merchantFromDatabase.website = merchant.website;
            merchantFromDatabase.telephone = merchant.telephone;
            merchantFromDatabase.address = merchant.address;
            merchantFromDatabase.city = merchant.city;
            merchantFromDatabase.accountNumber = merchant.accountNumber;//gi updejtira atributite so novite atribute


            _merchantDbContext.SaveChanges();
            return true;
        }
    }
}
