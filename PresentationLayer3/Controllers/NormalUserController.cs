using AutoMapper;
using DtoLayer.Dtos.NormalUserEditDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.Controllers
{
    public class NormalUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public NormalUserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //NormalUserEditDto normalUserEditDto = new NormalUserEditDto();
            //normalUserEditDto.name = values.Name;
            //normalUserEditDto.surname = values.Surname;
            //normalUserEditDto.phonenumber = values.PhoneNumber;
            //normalUserEditDto.mail = values.Email;
            //normalUserEditDto.district = values.District;
            //normalUserEditDto.city = values.District;
            //normalUserEditDto.imageurl = values.ImageUrl;

            NormalUserEditDto normalUserEditDto = _mapper.Map<NormalUserEditDto>(values);

            return View(normalUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(NormalUserEditDto normalUserEditDto)
        {
           if(normalUserEditDto.password == normalUserEditDto.confirmpassword)
           {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    user.PhoneNumber = normalUserEditDto.phonenumber;
                    user.Surname = normalUserEditDto.surname;
                    user.City = normalUserEditDto.city;
                    user.District = normalUserEditDto.district;
                    user.Name = normalUserEditDto.name;
                    user.ImageUrl = "test";
                    user.Email = normalUserEditDto.mail;
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, normalUserEditDto.password);
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
      
           }
            return View();
        }
    }
}
