using System;
namespace service_users.DTO
{
	public class TransactionDTO
	{
        public int id { get; set; }
        public DateTime date { get; set; }
        public string paymentMethod { get; set; }
        public string status { get; set; }
        public string customerID { get; set; }
        public string description { get; set; }
    }
}

