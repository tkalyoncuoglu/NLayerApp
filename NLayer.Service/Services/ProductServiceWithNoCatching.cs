using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductServiceWithNoCatching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceWithNoCatching(IGenericRepository<Product> genericRepository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(genericRepository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productsDto =  _mapper.Map<List<ProductWithCategoryDTO>>(products);

            return CustomResponseDTO<List<ProductWithCategoryDTO>>.Success(200,productsDto);

        }
    }
}
