using System;
using System.Collections.Generic;
using System.Linq;

namespace PatternsHomework.Prototype
{
    public class Order : IDeepCloneable<Order>
    {
        public List<Product> Products { get; set; } = new();
        public decimal ShippingCost { get; set; }
        public List<Discount> Discounts { get; set; } = new();
        public string PaymentMethod { get; set; }

        public decimal TotalItemsCost() => Products.Sum(p => p.Price * p.Quantity);
        public decimal TotalDiscount() => Discounts.Sum(d => d.Amount);
        public decimal Total() => Math.Max(0, TotalItemsCost() + ShippingCost - TotalDiscount());

        public Order CloneDeep()
        {
            var newOrder = new Order
            {
                ShippingCost = ShippingCost,
                PaymentMethod = PaymentMethod
            };
            newOrder.Products.AddRange(Products.ConvertAll(p => p.CloneDeep()));
            newOrder.Discounts.AddRange(Discounts.ConvertAll(d => d.CloneDeep()));
            return newOrder;
        }

        public override string ToString()
        {
            var items = Products.Count == 0 ? "(no products)" : string.Join("\n", Products);
            var discounts = Discounts.Count == 0 ? "(no discounts)" : string.Join(", ", Discounts);
            return $"Products:\n{items}\nShipping: {ShippingCost:C}\nDiscounts: {discounts}\nPayment: {PaymentMethod}\nTOTAL: {Total():C}";
        }
    }
}
