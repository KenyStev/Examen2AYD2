using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Spec
{
    internal class Calculator
    {
        readonly List<int> _numbers = new List<int>();       

        public void Add(int number)
        {
           _numbers.Add(number);
        }

        public int Sum()
        {
          return  _numbers.Sum();
        }
    }
}