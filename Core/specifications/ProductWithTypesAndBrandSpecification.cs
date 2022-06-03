using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.entities;

namespace Core.specifications
{
    public class ProductWithTypesAndBrandSpecification : Specification<Product>
    {

        public ProductWithTypesAndBrandSpecification()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        public ProductWithTypesAndBrandSpecification(int id)
         : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}