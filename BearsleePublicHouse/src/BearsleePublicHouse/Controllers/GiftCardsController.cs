using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BearsleePublicHouse.Models;
using System.Text.RegularExpressions;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BearsleePublicHouse.Controllers
{
    public class GiftCardsController : Controller
    {

        private readonly GiftCardContext _context;

        public GiftCardsController(GiftCardContext context)
        {
            _context = context;
        }


        // GET: /GiftCards/
        public IActionResult Index()
        {


            /*
             
            _context.Add(new Website{

                Name = "Test WebSite",
                URL = "http;//www.testwebsite.com"

            });

            _context.SaveChanges();
            

            

            var testWebsite = _context.Website.Where(w => w.WebsiteId == 2).FirstOrDefault();
            if(testWebsite != null)
            {
                //testWebsite.Name = "Test Website Updated";


                _context.Website.Remove(testWebsite);

                _context.SaveChanges();

            }

            


            var websites = _context.Website.ToList();
            foreach (var website in websites)
            {
                Console.WriteLine("Website Id: " + website.Name);
            }

            */



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(GiftCard giftCard)
        {

            if (giftCard.Amount == null)
            {
                ModelState.AddModelError("Amount", "Enter an valid amount.");

            }

            if (ModelState.IsValid)
            {

                giftCard.UniqueIdentifier = Guid.NewGuid().ToString();


                _context.Add(new GiftCardCart
                {

                    WebsiteID = 1,
                    Status = 0,
                    Amount = giftCard.Amount.Value,
                    DateCreated = DateTime.Now,
                    UniqueIdentifier = giftCard.UniqueIdentifier

                });

                _context.SaveChanges();



                return View("Checkout", giftCard);
            }





            return View("Index", giftCard);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Preview(GiftCard giftCard, string toDo)
        {
            if (giftCard.Shipping.FirstName == null)
            {
                ModelState.AddModelError("Shipping.FirstName", "Enter a shipping first name.");
            }

            if (giftCard.Shipping.LastName == null)
            {
                ModelState.AddModelError("Shipping.LastName", "Enter a shipping last name.");
            }

            if (giftCard.Shipping.Address == null)
            {
                ModelState.AddModelError("Shipping.Address", "Enter a shipping address.");
            }

            if (giftCard.Shipping.City == null)
            {
                ModelState.AddModelError("Shipping.City", "Enter a shipping city.");
            }

            if (giftCard.Shipping.State == "0")
            {
                ModelState.AddModelError("Shipping.State", "Enter a shipping state.");
            }

            if (giftCard.Shipping.Postal == null)
            {
                ModelState.AddModelError("Shipping.Postal", "Enter a shipping postal code.");
            }



            if (giftCard.Billing.FirstName == null)
            {
                ModelState.AddModelError("Billing.FirstName", "Enter a Billing first name.");
            }

            if (giftCard.Billing.LastName == null)
            {
                ModelState.AddModelError("Billing.LastName", "Enter a Billing last name.");
            }

            if (giftCard.Billing.Address == null)
            {
                ModelState.AddModelError("Billing.Address", "Enter a Billing address.");
            }

            if (giftCard.Billing.City == null)
            {
                ModelState.AddModelError("Billing.City", "Enter a Billing city.");
            }

            if (giftCard.Billing.State == "0")
            {
                ModelState.AddModelError("Billing.State", "Enter a Billing state.");
            }

            if (giftCard.Billing.Postal == null)
            {
                ModelState.AddModelError("Billing.Postal", "Enter a Billing postal code.");
            }
            if (giftCard.Billing.Phone == null)
            {
                ModelState.AddModelError("Billing.Phone", "Enter a Billing phone.");
            }

            Regex emailRegEx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (giftCard.Billing.Email == null)
            {
                ModelState.AddModelError("Billing.Email", "Enter an email address.");
            }
            else if (!emailRegEx.Match(giftCard.Billing.Email).Success)
            {
                ModelState.AddModelError("Billing.Email", "Enter a valid email address.");
            }



            if (giftCard.Information.ShippingType == 0)
            {
                ModelState.AddModelError("Information.ShippingType", "Enter a shipping type.");

            }
            else if (giftCard.Information.ShippingType == 3)
            {
                giftCard.Information.ShippingCost = 8;
                giftCard.Information.ShippingDisplay = "USPS 2-3 Days";
                giftCard.Total = giftCard.Amount + giftCard.Information.ShippingCost;
            }
            else if (giftCard.Information.ShippingType == 2)
            {
                giftCard.Information.ShippingCost = 0;
                giftCard.Information.ShippingDisplay = "USPS Parcel";
                giftCard.Total = giftCard.Amount + giftCard.Information.ShippingCost;
            }
            else if (giftCard.Information.ShippingType == 1)
            {
                giftCard.Information.ShippingCost = 0;
                giftCard.Information.ShippingDisplay = "Pickup";
                giftCard.Total = giftCard.Amount + giftCard.Information.ShippingCost;
            }


            if (giftCard.Information.SpecialInstructions == null)
            {
                giftCard.Information.SpecialInstructions = "N/A";
            }

            if (giftCard.Information.GiftMsg == null)
            {
                giftCard.Information.GiftMsg = "N/A";
            }


            if (toDo == "Back")
            {
                //adding giftCard to this makes the url a mess. This would however post back their original input.
                return RedirectToAction("Index");

            }
            else if (toDo == "Continue")
            {
                if (ModelState.IsValid)
                {


                    var mygiftcardcart = _context.GiftCardCart.Where(Uniq => Uniq.UniqueIdentifier == giftCard.UniqueIdentifier).FirstOrDefault();
                    if (mygiftcardcart != null)
                    {
                        //testWebsite.Name = "Test Website Updated";

                        mygiftcardcart.ShippingCost = giftCard.Information.ShippingCost;
                        mygiftcardcart.ShippingType = giftCard.Information.ShippingType;

                        mygiftcardcart.ShippingFirstName = giftCard.Shipping.FirstName;
                        mygiftcardcart.ShippingLastName = giftCard.Shipping.LastName;

                        if (giftCard.Shipping.Apt != null)
                        {
                            mygiftcardcart.ShippingAddress1 = giftCard.Shipping.Address + " " + giftCard.Shipping.Apt;
                        }
                        else
                        {
                            mygiftcardcart.ShippingAddress1 = giftCard.Shipping.Address;
                        }

                        mygiftcardcart.ShippingCity = giftCard.Shipping.City;
                        mygiftcardcart.ShippingState = giftCard.Shipping.State;
                        mygiftcardcart.ShippingPostalCode = giftCard.Shipping.Postal;
                        mygiftcardcart.ShippingPhone = giftCard.Shipping.Phone;
                        mygiftcardcart.ShippingEmail = giftCard.Shipping.Email;

                        mygiftcardcart.BillingFirstName = giftCard.Billing.FirstName;
                        mygiftcardcart.BillingLastName = giftCard.Billing.LastName;


                        if (giftCard.Billing.Apt != null)
                        {
                            mygiftcardcart.BillingAddress1 = giftCard.Billing.Address + " " + giftCard.Billing.Apt;
                        }
                        else
                        {
                            mygiftcardcart.BillingAddress1 = giftCard.Billing.Address;
                        }

                        //mygiftcardcart.BillingAddress1 = giftCard.Billing.Address;

                        mygiftcardcart.BillingCity = giftCard.Billing.City;
                        mygiftcardcart.BillingState = giftCard.Billing.State;
                        mygiftcardcart.BillingPostalCode = giftCard.Billing.Postal;
                        mygiftcardcart.BillingPhone = giftCard.Billing.Phone;
                        mygiftcardcart.BillingEmail = giftCard.Billing.Email;

                        mygiftcardcart.Message = giftCard.Information.GiftMsg;
                        mygiftcardcart.SpecialInstructions = giftCard.Information.SpecialInstructions;

                        mygiftcardcart.OrderTotal = giftCard.Total.Value;


                        //_context.GiftCardCart.Remove(mygiftcardcart);

                        _context.SaveChanges();

                    }


                    return View("Preview", giftCard);
                }

                return View("Checkout", giftCard);
                //return RedirectToAction("Checkout", giftCard);
            }

            return View("Index");



        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Receipt(GiftCard giftCard, string toDo)
        {


            if (giftCard.Information.SpecialInstructions == null)
            {
                giftCard.Information.SpecialInstructions = "N/A";
            }

            if (giftCard.Information.GiftMsg == null)
            {
                giftCard.Information.GiftMsg = "N/A";
            }



            if (giftCard.Card.CardType == "0")
            {
                ModelState.AddModelError("Card.CardType", "Enter an card type.");
            }

            Regex cardValid = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$");
            if (giftCard.Card.CardNumber == null || giftCard.Card.CardNumber == 0)
            {
                ModelState.AddModelError("Card.CardNumber", "Enter an card number.");
            }
            else if (!cardValid.Match(giftCard.Card.CardNumber.Value.ToString()).Success)
            {
                ModelState.AddModelError("Card.CardNumber", "Enter a valid card number.");
            }


            if (giftCard.Card.CardMonth == 0)
            {
                ModelState.AddModelError("Card.CardMonth", "Enter a expiration month.");
            }

            if (giftCard.Card.CardYear == 0)
            {
                ModelState.AddModelError("Card.CardYear", "Enter a expiration year.");
            }

            if (giftCard.Card.CardYear == DateTime.Now.Year && giftCard.Card.CardMonth < DateTime.Now.Month)
            {
                ModelState.AddModelError("Card.CardMonth", "Your card has expired.");
            }




            //delete any one hour old. would be bad to put it here say if someone took 1 hour to buy their giftcard.

            DateTime hourago = DateTime.Now.AddHours(-1);
            var oldstatus = _context.GiftCardCart.Where(Dates => Dates.DateCreated < hourago).ToList();
            if (oldstatus != null)
            {
                foreach (var oldcart in oldstatus)
                {
                    oldcart.Status = 2;
                    oldcart.UniqueIdentifier = null;
                }
            }



            if (toDo == "Back")
            {
                //couldn't get this to work.
                //return RedirectToAction("Checkout");
                //return View("Checkout", giftCard);
                return RedirectToAction("Index");

            }
            else if (toDo == "Purchase")
            {

                if (ModelState.IsValid)
                {


                    var mygiftcardcart = _context.GiftCardCart.Where(Uniq => Uniq.UniqueIdentifier == giftCard.UniqueIdentifier).FirstOrDefault();
                    if (mygiftcardcart != null)
                    {
                        //testWebsite.Name = "Test Website Updated";

                        mygiftcardcart.Status = 1;
                        mygiftcardcart.CreditCardType = giftCard.Card.CardType;
                        mygiftcardcart.UniqueIdentifier = null;


                        //_context.GiftCardCart.Remove(mygiftcardcart);

                        _context.SaveChanges();

                    }



                    Random random = new Random();
                    int confirm1 = random.Next(10000, 99999);
                    int confirm2 = random.Next(10000, 99999);
                    giftCard.ConfirmationCode = confirm1.ToString() + "-" + confirm2.ToString();

                    return View("Receipt", giftCard);
                }

                return View("Preview", giftCard);

            }

            return View("Index");



        }




        // GET: /GiftCards/Checkout
        /*
        public IActionResult Checkout()
        {
            return View();
        }
        


        // GET: /GiftCards/Preview
        public IActionResult Preview()
        {
            return View();
        }

        // GET: /GiftCards/Preview
        public IActionResult Receipt()
        {
            return View();
        }
        */
    }
}
