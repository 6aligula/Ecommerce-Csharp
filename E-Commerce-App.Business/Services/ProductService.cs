﻿using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace E_Commerce_App.Business.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository) { }

        public int GetCountByCategory(string category)
        {
            return _unitOfWork.ProductRepository.GetCountByCategory(category);
        }

        public async Task<List<Product>> GetHomePageProducts(int page, int pageSize)
        {
            return await _unitOfWork.ProductRepository.GetHomePageProducts(page, pageSize);
        }

        public async Task<List<Product>> GetProductsByCategory(string name, int page, int pageSize)
        {
            return await _unitOfWork.ProductRepository.GetProductsByCategory(name, page, pageSize);
        }

        public async Task<Product> GetProductWithAllColumns(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.ProductRepository.GetProductWithAllColumns(predicate);
        }

        public async Task<Product> GetProductWithCategoriesById(string productId)
        {
            return await _unitOfWork.ProductRepository.GetProductWithCategoriesById(productId);
        }

        public async Task<List<Product>> GetSearchResult(string query, int page, int pageSize)
        {
            return await _unitOfWork.ProductRepository.GetSearchResult(query, page, pageSize);
        }
        public int GetProductCount()
        {
            return _unitOfWork.ProductRepository.GetProductCount();
        }

        public int GetProductCountBySearch(string query)
        {
            return _unitOfWork.ProductRepository.GetProductCountBySearch(query);
        }

        public void RemoveProduct(Product product)
        {
            _unitOfWork.ProductRepository.RemoveProduct(product);
            _unitOfWork.Commit();
        }
        public async Task<Product> GetProductByIdAsync(string id)
        {
            // Usa el repositorio para obtener el producto por su Id de tipo string
            return await _unitOfWork.ProductRepository.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateAsync(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.CommitAsync();
        }
    }
}
