using DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
                RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
                RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
                RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez");
                RuleFor(x => x.EMail).NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
                RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
                RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen isminiz 2 karakterden fazla yapın ");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Parolalarınız Eşleşmiyor");
            RuleFor(x => x.EMail).EmailAddress().WithMessage("Lütfen geçerli bir Mail Adresi Giriniz");
        
        }
    }
}
