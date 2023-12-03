using AutoMapper;
using DtoLayer.Dtos.NormalUserEditDtos;
using DtoLayer.Dtos.RecycableMaterialDtos;
using EntityLayer.Concrete;

namespace PresentationLayer3.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<NormalUserEditDto,AppUser>().ReverseMap();

            CreateMap<RecycableMaterial, RecycableMaterialAddDto>().ReverseMap();

                
        }
    }
}
