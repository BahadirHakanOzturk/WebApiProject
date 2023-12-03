using AutoMapper;
using WebApiProject.Application.Features.Products.ProductCreate;
using WebApiProject.Application.Features.Products.ViewModels;
using WebApiProject.Domain;

namespace WebApiProject.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductCreateCommand>().ReverseMap();
        CreateMap<Product, ProductVM>().ReverseMap();
    }
}
