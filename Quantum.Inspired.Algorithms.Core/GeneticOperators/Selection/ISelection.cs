using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.GeneticOperators.Selection
{
    public interface ISelection : IGeneticOperators
    {
        public void Fitness(Population population);
        public void OperateOnPopulation(Population population, int outputSize);
    }
}
