namespace PatternsHomework.Prototype
{
    public class Product : IDeepCloneable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product CloneDeep()
        {
            return new Product { Name = Name, Price = Price, Quantity = Quantity };
        }

        public override string ToString() => $"{Name} x{Quantity} @ {Price:C}";
    }
}
