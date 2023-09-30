using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecifications<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
             AddInclude(x => x.ProductType);
             AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x =>x.Id==id)
        {
              AddInclude(x => x.ProductType);
              AddInclude(x => x.ProductBrand);
        }
    }
}