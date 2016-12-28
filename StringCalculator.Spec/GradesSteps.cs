using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace StringCalculator.Spec
{
    [Binding]
    public class GradesSteps
    {
        private GradeManager gradeManager;
        private string accountNumber;
        private Mock<IGradeRepository> _gradeRepositoryMock = new Mock<IGradeRepository>();
        private double average;

        [Given(@"That the student with '(.*)' account number")]
        public void GivenThatTheStudentWithAccountNumber(string p0)
        {
            accountNumber = p0;
        }
        
        [Given(@"These are the following grades")]
        public void GivenTheseAreTheFollowingGrades(Table table)
        {
           var grades = table.CreateSet<Grade>();
            _gradeRepositoryMock.Setup(x => x.GetGrades(accountNumber)).Returns(grades);
        }
        
        [When(@"I calculate the average grade")]
        public void WhenICalculateTheAverageGrade()
        {
            gradeManager = new GradeManager(_gradeRepositoryMock.Object);
            average = gradeManager.CalculateAverage(accountNumber);
        }
        
        [Then(@"the average grade should be (.*) on the screen")]
        public void ThenTheAverageGradeShouldBeOnTheScreen(double p0)
        {
            Assert.AreEqual(p0,average);
        }
    }
}
