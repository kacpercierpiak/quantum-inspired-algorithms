using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public interface IGeneticOperators
    {
        public void OperateOnPopulation(Population population);        
    }
}
