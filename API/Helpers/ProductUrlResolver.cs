using API.Dtos;
using AutoMapper;
using Core.entities;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.PictureUrl) ? _config["ApiUrl"] + source.PictureUrl : null;

        }
    }
}