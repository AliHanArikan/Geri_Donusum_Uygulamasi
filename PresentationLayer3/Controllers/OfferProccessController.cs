﻿using BusinessLayer.Abstract;
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
            try
            {
                var material = _recycAbleMaterialService.TGetByID(offer.RecyableMaterialId);

                //var recevierUser = material.AppUserID;

                //offer.ReceiverUserId = recevierUser;
                offer.isAccepted = "Beklemede";
                offer.ProcessDate = DateTime.Now;

                _offerService.TInsert(offer);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
            }
           
            return View();
            

        }
        //tekliflerim , gelen teklifler

        [HttpGet]
        public IActionResult GetİncomingOffers()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var incomingOffers = _recycAbleMaterialService.TGetMaterialWithUserId(user.Id);
            return View(incomingOffers);
        }
    }
}
