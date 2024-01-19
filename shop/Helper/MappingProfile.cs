using AutoMapper;
using shop.Dto;
using shop.Models;

namespace shop.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(src => src.Poster, opt => opt.Ignore());
            
        }
    }
}
