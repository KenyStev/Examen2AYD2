namespace StringCalculator.Spec
{
    internal class Employe
    {
        public int Code { set; get; }
        public string Name { set; get; }

        public override bool Equals(object obj)
        {
            if (obj is Employe)
            {
                return ((Employe) obj).Code == Code
                       && ((Employe) obj).Name == Name;
            }
            return false;
        }
    }
}