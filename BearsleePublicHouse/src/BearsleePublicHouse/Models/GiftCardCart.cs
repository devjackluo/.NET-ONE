using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearsleePublicHouse.Models
{
    public class GiftCardCart
    {
        public int GiftCardCartID { get; set; }
        public int WebsiteID { get; set; }
        public int Status { get; set; }

        public string History { get; set; }
        public decimal Amount { get; set; }
        public decimal ShippingCost { get; set; }

        public int ShippingType { get; set; }
        public Boolean ShippingValidation { get; set; }

        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }

        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }

        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }

        public string ShippingPostalCode { get; set; }
        public string ShippingPhone { get; set; }

        public string ShippingEmail { get; set; }
        public string ShippingCountry { get; set; }

        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }

        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }

        public string BillingCity { get; set; }
        public string BillingState { get; set; }

        public string BillingPostalCode { get; set; }
        public string BillingPhone { get; set; }

        public string BillingEmail { get; set; }
        public string BillingCountry { get; set; }

        public string UniqueIdentifier { get; set; }
        public string AuthorizationCode { get; set; }
        public string TransactionID { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime PurchaseDate { get; set; }
        public string Message { get; set; }

        public string SpecialInstructions { get; set; }
        public decimal OrderTotal{ get; set; }

        public string CreditCardType { get; set; }

    }
}
