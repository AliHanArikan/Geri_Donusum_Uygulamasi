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
            values = values.Where(x => x.isStatus == false).ToList();
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
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
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
            recycableMaterial.isStatus = false;
            recycableMaterial.ProcessDate = DateTime.Now;
            

            _recycAbleMaterialService.TInsert(recycableMaterial);

            return RedirectToAction("Index", "RecycAbleMaterial");
        }

        [HttpGet("RecycAbleMaterial/GetMaterialWithCityName/{cities}")]
        public IActionResult GetMaterialWithCityName(string cities)
        {
            var values = _recycAbleMaterialService.TGetMaterialWithCityName(cities.Trim());
            return View(values);
        }

        public async Task<IActionResult> GetMaterialWithUserIdAsync(int userId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _recycAbleMaterialService.TGetMaterialWithUserId(user.Id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialWithUserIdForDeletetwo()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _recycAbleMaterialService.TGetMaterialWithUserId(user.Id);
            return View(values);
        }

        
        public IActionResult  DeleteMaterial(int id)
        {
            var material = _recycAbleMaterialService.TGetByID(id);
            _recycAbleMaterialService.TDelete(material);
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialWithUserIdForUpdate()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _recycAbleMaterialService.TGetMaterialWithUserId(user.Id).ToList();

            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateMaterial(int id)
        {
            var material = _recycAbleMaterialService.TGetByID(id);
            ViewBag.Id = id;
            return View(material);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMaterialAsync(RecycableMaterial material)
        {
            try
            {
                //var user = await _userManager.FindByNameAsync(User.Identity.Name);
                //material.AppUserID = user.Id;

                _recycAbleMaterialService.TUpdate(material);
                return RedirectToAction("Index", "RecycAbleMaterial");
            }catch (Exception)
            {
                return RedirectToAction("Index", "RecycAbleMaterial");
                
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> MaterialsTeslimEdilen()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            var values = _recycAbleMaterialService.TGetMaterialWithUserIdDelivered(user.Id).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult MaterialDetail(int id)
        {
            var materail = _recycAbleMaterialService.TGetByID(id);
            return View(materail);
        }
    }
}
