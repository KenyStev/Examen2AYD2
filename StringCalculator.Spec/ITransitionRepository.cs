using System.Collections.Generic;

namespace StringCalculator.Spec
{
    public interface ITransitionRepository
    {
        IEnumerable<Transition> GetTransitions();
    }
}