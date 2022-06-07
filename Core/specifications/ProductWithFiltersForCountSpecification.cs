using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;

namespace Core.specifications
{
    public class ProductWithFiltersForCountSpecification : Specification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecPrams productPrams)
        : base((x) =>
         (string.IsNullOrEmpty(productPrams.Search) || x.Name.ToLower().Contains(productPrams.Search)) &&
        (!productPrams.BrandId.HasValue || x.ProductBrandId == productPrams.BrandId) &&
        (!productPrams.TypeId.HasValue || x.ProductTypeId == productPrams.TypeId)
        )
        {
        }
    }
}