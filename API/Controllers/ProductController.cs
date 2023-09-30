using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> ProductRepo;
        private readonly IGenericRepository<ProductBrand> ProductBrandRepo;
        private readonly IGenericRepository<ProductType> ProductTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> ProductRepo,
        IGenericRepository<ProductBrand> ProductBrandRepo, IGenericRepository<ProductType> ProductTypeRepo,IMapper mapper)
        {
            this.ProductTypeRepo = ProductTypeRepo;
            this.ProductBrandRepo = ProductBrandRepo;
            this.ProductRepo = ProductRepo;
            this._mapper = mapper;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturn>>> GetProduct()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await ProductRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturn>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturn>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await ProductRepo.GetEntityWithSpec(spec);
            
            return _mapper.Map<Product, ProductToReturn>(product);
            
        }

         [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await ProductBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
            return Ok(await ProductTypeRepo.ListAllAsync());
        }

    }
}