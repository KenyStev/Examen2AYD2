using System.Runtime.InteropServices;

namespace StringCalculator.Spec
{
    public class Transition
    {
        public int ProductCode { get; set; }
        public int Qty { get; set; }
        public string TransactionType { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Transition)
            {
                return ((Transition)obj).ProductCode == ProductCode
                && ((Transition)obj).Qty == Qty
                && ((Transition)obj).TransactionType == TransactionType;
            }
            return false;
        }
    }
}