using AutoMapper;
using Glowria.Application.Commands.Category;
using Glowria.Domain.Entities;

namespace Glowria.Application.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryAddRequest, Category>().ReverseMap();
    }
}