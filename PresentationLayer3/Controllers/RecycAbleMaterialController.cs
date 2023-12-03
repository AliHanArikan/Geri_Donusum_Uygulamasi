using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using DtoLayer.Dtos;
using DtoLayer.Dtos.RecycableMaterialDtos;
using EntityLayer.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace PresentationLayer3.Controllers
{
    public class RecycAbleMaterialController : Controller
    {
        private readonly IRecycAbleMaterialService _recycAbleMaterialService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public RecycAbleMaterialController(IRecycAbleMaterialService recycAbleMaterialService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _recycAbleMaterialService = recycAbleMaterialService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _recycAbleMaterialService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddMaterial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterial(RecycableMaterialDto recycableMaterialDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //RecycableMaterial recycableMaterial = _mapper.Map<RecycableMaterial>(recycableMaterialDto);
            RecycableMaterial recycableMaterial = new RecycableMaterial();
            recycableMaterial.RecycableMaterialType = recycableMaterialDto.RecycableMaterialType;
            recycableMaterial.LocationCity = recycableMaterialDto.LocationCity;
            recycableMaterial.LocationDistrict = recycableMaterialDto.LocationDistrict;
            recycableMaterial.LocationFullAdress = recycableMaterialDto.LocationFullAdress;
            recycableMaterial.imageUrl = recycableMaterialDto.imageUrl;
            recycableMaterial.materialAmount = recycableMaterialDto.materialAmount;
            //recycableMaterial.AppUser = _userManager.FindByNameAsync(User.Identity.Name);

            recycableMaterial.AppUserID = user.Id;
            recycableMaterial.isStatus = true;
            recycableMaterial.ProcessDate = DateTime.Now;
            

            _recycAbleMaterialService.TInsert(recycableMaterial);

            return RedirectToAction("Index", "RecycAbleMaterial");
        }
    }
}
