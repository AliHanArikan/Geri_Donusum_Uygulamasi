using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.AppUserValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using NLog;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nLog.config"));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<IRecycAbleMaterialDal, EfRecycableMaterialDal>();
builder.Services.AddScoped<IRecycAbleMaterialService, RecycAbleMaterialManager>();

builder.Services.AddScoped<IOfferDal, EfOfferDal>();
builder.Services.AddScoped<IOfferService, OfferManager>();

builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();

builder.Services.AddScoped<IValidator<AppUserRegisterDto>, AppUserRegisterValidator>();




builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // burayý bize ekledik

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
