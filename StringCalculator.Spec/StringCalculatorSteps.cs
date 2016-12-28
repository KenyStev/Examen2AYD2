using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace StringCalculator.Spec
{
    [Binding]
    public class StringCalculatorSteps
    {
        private readonly Calculator _calculator = new Calculator();
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _calculator.Add(p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Sum();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
           Assert.AreEqual(p0, _result);
        }

        [Given(@"I have entered")]
        public void GivenIHaveEntered(Table table)
        {
            foreach (var row in table.Rows)
            {
                _calculator.Add(Convert.ToInt32(row["numbers"]));
            }
        }

    }
}
