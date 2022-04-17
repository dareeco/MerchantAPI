using MerchantAPI.Model;
using MerchantAPI.Model.Response;
using MerchantAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MerchantAPI.Controllers
{
    [Route("api/merchants")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMerchantRepository _merchantRepository;

        public MerchantsController(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }
        [HttpGet]
        public ActionResult<MerchantResponse> GetMerchants([FromQuery] int? page, string? merchantCode)
        {
            if (!page.HasValue || page == 0)
            {
                page = 1;
            }

            return _merchantRepository.GetMerchants(page.Value, merchantCode);
        }

        [HttpPost]
        public ActionResult CreateMerchant([FromBody] Merchant merchant)
        {
            _merchantRepository.CreateMerchant(merchant); //Merchant is created by the method in the repositorium
            return Ok();
        }
       

        [HttpGet("{merchantCode}")]
        public ActionResult GetMerchantByCode([FromRoute] string merchantCode)
        {
            var merchant = _merchantRepository.GetMerchantCode(merchantCode);
            if (merchant == null)
            {
                return NotFound(); //Merchant with that merchantCode doesn't exist
            }

            return Ok(merchant);
        }

        [HttpPut("{merchantCode}")]
        public ActionResult UpdateMerchant([FromRoute] string merchantCode, [FromBody] Merchant merchant)
        {
            var result = _merchantRepository.UpdateMerchantCode(merchantCode, merchant);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{merchantCode}")]
        public ActionResult DeleteMerchant([FromRoute] string merchantCode)
        {
            var result = _merchantRepository.DeleteMerchantCode(merchantCode);

            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("{merchantCode}/stores")]
        public ActionResult<StoreResponse> GetStores([FromRoute] string merchantCode,[FromQuery] int? page, string? storeCode)
        {
            var merchant = _merchantRepository.GetMerchantCode(merchantCode);
            if (merchant == null)
            {
                return NotFound(); //Merchant with that merchantCode doesn't exist
            }
            if (!page.HasValue || page == 0)
            {
                page = 1;
            }

            return _merchantRepository.GetStores(page.Value, storeCode, merchantCode);
            //return _merchantRepository.GetStores(page.Value, storeCode); I also need merchantCode, to find stores for given merchant
        }

        [HttpPost("{merchantCode}/stores")]
        public ActionResult CreateStoreForMerchant([FromRoute] string merchantCode, [FromBody] Store store)
        {
            var merchant = _merchantRepository.GetMerchantCode(merchantCode);
            if (merchant == null)
            {
                return NotFound(); //Merchant with that merchantCode doesn't exist
            }
            _merchantRepository.CreateStoreForMerchantCode(merchantCode, store); //If merchant exist, create store for him
            return Ok();
        }

        [HttpGet("{merchantCode}/stores/{storeCode}")]
        public ActionResult GetStoreById([FromRoute] string merchantCode,[FromRoute] string storeCode )
        {
            var merchant=_merchantRepository.GetMerchantCode(merchantCode);
            if(merchant == null)
            {
                return NotFound();
            } //If i don't check if there is a merchant with that merchantCode, with invalid merchantCode you can access stores- like he exists
            
            var store = _merchantRepository.GetStoreCode(storeCode);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }
        [HttpPut("{merchantCode}/stores/{storeCode}")]
        public ActionResult UpdateStore([FromRoute] string merchantCode,[FromRoute] string storeCode, [FromBody] Store store)
        {
            var merchantExists = _merchantRepository.GetMerchantCode(merchantCode);
            if (merchantExists == null)
            {
                return NotFound();
            }
            var result = _merchantRepository.UpdateStoreCode(storeCode, store);
            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{merchantCode}/stores/{storeCode}")]
        public ActionResult DeleteStore([FromRoute] string merchantCode,[FromRoute] string storeCode)
        {
            var merchant=_merchantRepository.GetMerchantCode(merchantCode);
            if (merchant == null)
            {
                return NotFound();
            }
            var result = _merchantRepository.DeleteStoreCode(storeCode);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
    
}

