using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // form domain to Dto
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(pDto => pDto.ProductBrand, opt => opt.MapFrom(p => p.ProductBrand.Name))
            .ForMember(pDto => pDto.ProductType, opt => opt.MapFrom(p => p.ProductType.Name))
            .ForMember(pDto => pDto.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());
        }
    }
}