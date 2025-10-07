﻿using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{
    public class Sale : BaseEntity<int>
    {

        public Sale() : base(0)
        {
        }
        public Sale(int id, DateTime saleDate, decimal saleTotal, User salesman, Customer customer) : base(id) {
            SaleDate = saleDate;
            SaleTotal = saleTotal;
            Salesman = salesman;
            Customer = customer;
            SaleItens = new List<SaleItem>();

        }

        public DateTime SaleDate { get; set; }
        public decimal SaleTotal { get; set; }
        public User Salesman { get; set; }
        public Customer Customer { get; set; }
        public List<SaleItem> SaleItens { get; set; } = new List<SaleItem>();

    }
    public class SaleItem : BaseEntity<int>
    {
        public SaleItem() : base(0)
        {
        }
        public SaleItem(int id, Sale sale, Product product, decimal quantity, decimal unitPrice, decimal totalPrice) : base(id)
        {
            Sale = sale;
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }
        public Product Product { get; set; }
        public Sale Sale { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
