using System;
using System.Collections.Generic;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Domain.Sales
{
    public class SaleFactory
    {
        private readonly IRepository<Sale> _saleReporistory;
        private readonly IRepository<Product> _productRepository;

        public SaleFactory(IRepository<Sale> saleReporistory, IRepository<Product> productRepository)
        {
            _saleReporistory = saleReporistory;
            _productRepository = productRepository;
        }

        public void Create(string clientName, int ProductId, int quantity)
        {
            var product = _productRepository.GetById(ProductId);
            product.RemoveFromStock(quantity);

            var sale = new Sale(clientName, product, quantity);
            _saleReporistory.Save(sale);
        }
    }
}