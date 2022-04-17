namespace MerchantAPI.Model
{
   
    
        public class Merchant
        {
            public int Id { get; set; }
            public string merchantCode { get; set; }
            public string merchantName { get; set; }
            public string fullName { get; set; }
            //From here upwards, show the collumns in the table
            public string telephone { get; set; } //string because its not a number used in calculations, it doesn't have number value
            public string address { get; set; }
            public string city { get; set; }
            public string email { get; set; }
            public string website { get; set; }
            public string accountNumber { get; set; } //Same reason as telephone + here can appear -

         



        }
}


