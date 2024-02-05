using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PresentationLayer3.Controllers
{
    public class OfferProccessController : Controller
    {
        private readonly IRecycAbleMaterialService _recycAbleMaterialService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOfferService _offerService;
        public OfferProccessController(IRecycAbleMaterialService recycAbleMaterialService, UserManager<AppUser> userManager, IOfferService offerService)
        {
            _recycAbleMaterialService = recycAbleMaterialService;
            _userManager = userManager;
            _offerService = offerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var material = _recycAbleMaterialService.TGetByID(id);
           
            var recevierUser = material.AppUserID;
            var senderUser = User.Identity.Name;

            var senderUserId = await _userManager.FindByNameAsync(senderUser);

            Offer offer = new Offer()
            {
                RecyableMaterialId = id,
                SenderUserId = senderUserId.Id,
                ReceiverUserId = recevierUser,
                offersPrice =  " ",
                isAccepted = "Beklemede",
                ProcessDate = DateTime.Now,

            };
            return View(offer);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Offer offer)
        {
            //var senderUserId = await _userManager.FindByNameAsync(User.Identity.Name);

            try
            {
                
                if(offer.SenderUserId != offer.ReceiverUserId)
                {
                    offer.isAccepted = "Beklemede";
                    offer.ProcessDate = DateTime.UtcNow;
                    offer.IdeliverStatus = "TeslimEdilmedi";
                    offer.IreciveStatus = "TeslimEdilmedi";
                    ViewBag.x = "basarili";

                    _offerService.TInsert(offer);
                }
                else
                {
                    TempData["ErrorMessage"] = "Type1";
                }
               
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
            }
           
            return View();
            

        }
        //tekliflerim , gelen teklifler

        [HttpGet]
        public async Task<IActionResult> GetİncomingOffers()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //  var incomingOffers = _recycAbleMaterialService.TGetMaterialWithUserId(user.Id);
            var incomingOffers = _offerService.TGetİncomingOffersWithUserId(user.Id);
            incomingOffers =  incomingOffers.Where(x => x.isAccepted.Trim() == "Beklemede").ToList();
            return View(incomingOffers);
        }

        public async Task<IActionResult> GetAcceptedOffers()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var incomingOffers = _offerService.TGetİncomingOffersWithUserId(user.Id);
            incomingOffers = incomingOffers.Where(x => x.isAccepted.Trim() == "KabulEdildi").ToList();
            return View(incomingOffers);
        }

        public async Task<IActionResult> GetDontAcceptedOffers()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var incomingOffers = _offerService.TGetİncomingOffersWithUserId(user.Id);
            incomingOffers = incomingOffers.Where(x => x.isAccepted.Trim() == "KabulEdilmedi").ToList();
            return View(incomingOffers);
        }

        public async Task<IActionResult> GetSendedOffer()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            var sendedOffers = _offerService.TGetSendedOffers(user.Id);
            return View(sendedOffers);
        }

        public async Task<IActionResult> AcceptTheOffer(int id)
        {
            var offer =_offerService.TGetByID(id);
            offer.isAccepted = "KabulEdildi";
            _offerService.TUpdate(offer);
            return RedirectToAction("GetİncomingOffers", "OfferProccess");
        }
        public IActionResult DontAcceptTheOffer(int id)
        {
            var offer = _offerService.TGetByID(id);
            offer.isAccepted = "KabulEdilmedi";
            _offerService.TUpdate(offer);
            return RedirectToAction("GetİncominOffers", "OfferProccess");
        }

        public void DeleteOffer(int id)
        {
            var offer = _offerService.TGetByID(id);
            _offerService.TDelete(offer);
           // return RedirectToAction("GetSendedOffer", "OfferProccess");
        }

        public IActionResult DeliverSuccess(int id)
        {
            var offer = _offerService.TGetByID(id);
            offer.IdeliverStatus = "TeslimEdildi";
            _offerService.TUpdate(offer);

            if(offer.IreciveStatus =="TeslimEdildi")
            {
                var material = _recycAbleMaterialService.TGetByID((int)offer.RecyableMaterialId);
                material.isStatus = true;
                _recycAbleMaterialService.TUpdate(material);
            }

            return RedirectToAction("MaterialsTeslimEdilen", "RecycAbleMaterial");
        }

        public IActionResult ReceiveSuccess(int id)
        {
            var offer = _offerService.TGetByID(id);
            offer.IreciveStatus = "TeslimEdildi";
            _offerService.TUpdate(offer);
            if (offer.IdeliverStatus=="TeslimEdildi")
            {
                var material = _recycAbleMaterialService.TGetByID((int)offer.RecyableMaterialId);
                material.isStatus = true;
                _recycAbleMaterialService.TUpdate(material);
                DeleteOffer(id);
            }

            return RedirectToAction("MaterialsTeslimEdilen", "RecycAbleMaterial");
        }
    }
}
