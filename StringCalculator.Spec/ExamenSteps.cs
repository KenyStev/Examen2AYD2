using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace StringCalculator.Spec
{
    [Binding]
    public class ExamenSteps
    {
        public TransitionManager transitionsManager;
        public IEnumerable<Product> NeedsBackorder;
        public Mock<IProductoRepository> _productRepositorieMock = new Mock<IProductoRepository>();
        public Mock<ITransitionRepository> _transitionsRepositorieMock = new Mock<ITransitionRepository>();
        public IEnumerable<Transition> filteredTrans;
        private Employe[] employees;
        private BinaryTree tree;
        private int[] stats;

        [Given(@"I have the follwing products")]
        public void GivenIHaveTheFollwingProducts(Table table)
        {
            var products = table.CreateSet<Product>();
            _productRepositorieMock.Setup(x => x.GetProducts()).Returns(products);
        }
        
        [Given(@"I have the following inventory transactions")]
        public void GivenIHaveTheFollowingInventoryTransactions(Table table)
        {
            var transitions = table.CreateSet<Transition>();
            _transitionsRepositorieMock.Setup(x => x.GetTransitions()).Returns(transitions);
        }
        
        [Given(@"I have the following employees")]
        public void GivenIHaveTheFollowingEmployees(Table table)
        {
            employees = table.CreateSet<Employe>().ToArray();
        }
        
        [Given(@"I have the following tree nodes")]
        public void GivenIHaveTheFollowingTreeNodes(Table table)
        {
            var nodes = table.CreateSet<Node>();
            tree = new BinaryTree();
            foreach (var node in nodes)
            {
                tree.add(new NodeT() {Value = node.Value});
            }
        }
        
        [When(@"we check which products needs backorder")]
        public void WhenWeCheckWhichProductsNeedsBackorder()
        {
            transitionsManager = new TransitionManager(_transitionsRepositorieMock.Object);
            NeedsBackorder = transitionsManager.ProductsToBackOrder(_productRepositorieMock.Object);
        }

        [When(@"we QUICKSORT by name")]
        public void WhenWeQUICKSORTByName()
        {
            Sorting.QuickSort(employees);
        }
        
        [When(@"filter by transacion type '(.*)'")]
        public void WhenFilterByTransacionType(string p0)
        {
            transitionsManager = new TransitionManager(_transitionsRepositorieMock.Object);
            filteredTrans = transitionsManager.filterBy(p0);
        }
        
        [When(@"get tree stats is called")]
        public void WhenGetTreeStatsIsCalled()
        {
            stats = tree.GetStats();
        }
        
        [Then(@"the following products will appear that needs back order")]
        public void ThenTheFollowingProductsWillAppearThatNeedsBackOrder(Table table)
        {
            var expectedProducts = table.CreateSet<Product>();
            for (int i = 0; i < expectedProducts.ToList().Count; i++)
            {
                Assert.AreEqual(expectedProducts.ElementAt(i), NeedsBackorder.ElementAt(i));
            }
        }
        
        [Then(@"the list should be like this")]
        public void ThenTheListShouldBeLikeThis(Table table)
        {
            var employeesSorted = table.CreateSet<Employe>();
            for (int i = 0; i < employeesSorted.Count(); i++)
            {
                Assert.AreEqual(employeesSorted.ElementAt(i),employees.ElementAt(i));
            }
        }
        
        [Then(@"the transactions should look like")]
        public void ThenTheTransactionsShouldLookLike(Table table)
        {
            var trans = table.CreateSet<Transition>();
            for (int i = 0; i < trans.ToList().Count; i++)
            {
                Console.WriteLine(filteredTrans.ElementAt(i));
                Assert.AreEqual(filteredTrans.ElementAt(i),trans.ElementAt(i));
            }
        }
        
        [Then(@"max value should be (.*) and min value should be (.*)")]
        public void ThenMaxValueShouldBeAndMinValueShouldBe(int p0, int p1)
        {
            Assert.AreEqual(stats[0],p0);
            Assert.AreEqual(stats[1], p1);
        }
    }
}
