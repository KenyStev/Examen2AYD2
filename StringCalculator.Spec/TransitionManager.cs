using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace StringCalculator.Spec
{
    public class TransitionManager
    {
        private ITransitionRepository transitionManager;

        public TransitionManager(ITransitionRepository @object)
        {
            this.transitionManager = @object;
        }

        public IEnumerable<Product> ProductsToBackOrder(IProductoRepository productoRepository)
        {
            List<Transition> procesedList = new List<Transition>();
            foreach (var transition in transitionManager.GetTransitions())
            {
                var item = procesedList.Find(x => x.ProductCode == transition.ProductCode);
                if (item != null)
                {
                    item.Qty += (transition.TransactionType == "In") ? transition.Qty : -transition.Qty;
                }
                else
                {
                    procesedList.Add(transition);
                }
            }

            var lessThan_10 = procesedList.Where(x => x.Qty < 10);

            var products = productoRepository.GetProducts().ToList();
            List<Product> productsToBackOrder = new List<Product>();

            foreach (var product in lessThan_10)
            {
                productsToBackOrder.Add(products.Find(x => x.Code == product.ProductCode));
            }

            return productsToBackOrder;
        }

        public IEnumerable<Transition> filterBy(string p0)
        {
            return transitionManager.GetTransitions().Where(t => t.TransactionType == p0);
        }
    }
}