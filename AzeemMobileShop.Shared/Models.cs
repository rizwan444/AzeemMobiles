using System;
using System.Collections.Generic;

namespace AzeemMobileShop.Shared.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }

    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? SKU { get; set; }
        public decimal BaseCost { get; set; }
        public decimal BaseRetail { get; set; }
        
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
    }

    public class ProductItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        
        public string? IMEI { get; set; }
        public string? Color { get; set; }
        public string? Condition { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal MinimumSalePrice { get; set; }
        
        // e.g. InStock, Sold, Reserved, InRepair
        public string Status { get; set; } = "InStock"; 
    }

    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? ContactNumber { get; set; }
        public string? City { get; set; }
        public decimal Balance { get; set; }
    }

    public class Sale : BaseEntity
    {
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PaidAmount { get; set; }
        
        public List<SaleItem> SaleItems { get; set; } = new();
    }

    public class SaleItem : BaseEntity
    {
        public Guid SaleId { get; set; }
        public Sale? Sale { get; set; }
        
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        
        public Guid? ProductItemId { get; set; } // Only if it's a serialized item like a phone
        public ProductItem? ProductItem { get; set; }
        
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
