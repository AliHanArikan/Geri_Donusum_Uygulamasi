using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Offer
    {
        public int offerId {  get; set; }
    
        public int RecyableMaterialId { get; set; }

        public RecycableMaterial RecycableMaterial { get; set; }

        public int? SenderUserId { get; set; }

        public int? ReceiverUserId { get; set; }
        public AppUser SenderUser {  get; set; }
        public AppUser ReceiverUser { get; set; }
        public string offersPrice { get; set; }

        public string isAccepted { get; set; }
        public DateTime ProcessDate { get; set; }

        //public decimal Amount { get; set; }
        //public DateTime ProcessDate { get; set; }
        //public int? SenderID { get; set; }
        //public int? ReceiverID { get; set; }
        //public CustomerAccount SenderCustomer { get; set; }
        //public CustomerAccount ReceiverCustomer { get; set; }
    }
}
