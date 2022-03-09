using Quantum.Inspired.Algorithms.Core.GeneticOperators.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.Algorithms
{
    public interface IGeneticAlgorithm
    {
        public void CreateNewPopulation();
        public double GetBestGlobalScore();
        public void Init(int populationSize, int chromosomeLenght, IFitness fitness);
    }
}
