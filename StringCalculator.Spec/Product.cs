namespace StringCalculator.Spec
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                return ((Product) obj).Code == Code
                       && ((Product) obj).Name == Name
                       && ((Product) obj).Description == Description;
            }
            return false;
        }
    }
}