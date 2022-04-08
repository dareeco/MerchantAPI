namespace MerchantAPI.Model
{
   
    
        public class Merchant
        {
            public int Id { get; set; }
            public string merchantCode { get; set; }
            public string merchantName { get; set; }
            public string fullName { get; set; }
            //Nagore za prikazhvanje vo tabela, nadolu dodatni podatoci
            public string telephone { get; set; } //string oti ne e broj sho se koristi vo presmetki nema brojna vrednost
            public string address { get; set; }
            public string city { get; set; }
            public string email { get; set; }
            public string website { get; set; }
            public string accountNumber { get; set; } //od ista prichina ko telefonot string

         



        }
}


