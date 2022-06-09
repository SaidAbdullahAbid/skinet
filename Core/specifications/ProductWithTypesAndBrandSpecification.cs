using Core.entities;

namespace Core.specifications
{
    public class ProductWithTypesAndBrandSpecification : Specification<Product>
    {

        public ProductWithTypesAndBrandSpecification(ProductSpecPrams productPrams)
        : base((x) =>
        (string.IsNullOrEmpty(productPrams.Search) || x.Name.ToLower().Contains(productPrams.Search)) &&
        (!productPrams.BrandId.HasValue || x.ProductBrandId == productPrams.BrandId) &&
        (!productPrams.TypeId.HasValue || x.ProductTypeId == productPrams.TypeId)
        )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(productPrams.PageSize * (productPrams.PageIndex - 1), productPrams.PageSize);
            if (productPrams.Sort is not null)
            {
                productPrams.Sort = productPrams.Sort.ToLower();
                switch (productPrams.Sort)
                {
                    case "pricedesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    case "priceasc":
                        AddOrderBy(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductWithTypesAndBrandSpecification(int id)
         : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}