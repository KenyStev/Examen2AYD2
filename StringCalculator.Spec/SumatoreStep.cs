using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace StringCalculator.Spec
{
    [Binding]
    public sealed class SumatoreStep
    {
        int []nums = new int[2];
        int cont= 0;
        int result;
        Sumatore sumer = new Sumatore();

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number1)
        {
            nums[cont++] = number1;
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            this.result = sumer.add(nums[0], nums[1]);
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(this.result,result);
        }
    }
}
