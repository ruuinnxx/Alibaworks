namespace PatternsHomework.Prototype
{
    public class Discount : IDeepCloneable<Discount>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Discount CloneDeep()
        {
            return new Discount { Description = Description, Amount = Amount };
        }

        public override string ToString() => $"{Description} (-{Amount:C})";
    }
}
