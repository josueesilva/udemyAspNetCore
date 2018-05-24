using System;
using System.Collections.Generic;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Domain.Sales
{
    public class Sale : Entity
    {
        public string ClientName { get; private set; }
        public DateTime CreateOn { get; private set; }
        public decimal Total { get; private set; }
        public SaleItem Item { get; private set; }

        public Sale(string clientName, Product product, int quantity)
        {
            DomainException.When(string.IsNullOrEmpty(clientName), "Client name is required");
            Item = new SaleItem(product, quantity);
            CreateOn = DateTime.Now;
            ClientName = clientName;

        }
        
    }
}