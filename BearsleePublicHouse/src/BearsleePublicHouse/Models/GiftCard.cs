using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearsleePublicHouse.Models
{
    public class ContactInformation
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Apt { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Postal { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }


    public class CardInfo
    {
        public string CardType { get; set; }
        public long? CardNumber { get; set; }
        public int CardMonth { get; set; }
        public int CardYear { get; set; }

    }

    public class GiftInfo
    {
        public int ShippingType { get; set; }

        public decimal ShippingCost { get; set; }

        public string ShippingDisplay { get; set; }

        public string GiftMsg { get; set; }

        public string SpecialInstructions { get; set; }

    }

    public class GiftCard
    {

        public string UniqueIdentifier { get; set; }

        //[Required]
        [Range(25, 500 , ErrorMessage = "You must enter an amount between $25 and $500.")]
        public decimal? Amount { get; set; }

        public decimal? Total { get; set; }

        public ContactInformation Shipping { get; set; }

        public ContactInformation Billing { get; set; }

        public GiftInfo Information { get; set; }

        public CardInfo Card { get; set; }

        public string ConfirmationCode { get; set; }

    }
}
