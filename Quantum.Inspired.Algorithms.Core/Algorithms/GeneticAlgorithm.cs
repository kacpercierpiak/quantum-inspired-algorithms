using Quantum.Inspired.Algorithms.Core.GeneticOperators.Crossover;
using Quantum.Inspired.Algorithms.Core.GeneticOperators.Mutation;
using Quantum.Inspired.Algorithms.Core.GeneticOperators.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.Algorithms
{
    public class GeneticAlgorithm
    {
        private int _populationSize { get; set; }
        private int _chromosomeLenght { get; set;}
        private ISelection _selection { get; set; }
        private IGeneticOperators _mutation { get; set; }
        private IGeneticOperators _crossover { get; set; }
        private IFitness _fitness { get; set; }
        public List<Population> Populations { get; private set; } = new List<Population>();

        public double BestGlobalScore = 0.0;
        
        
        
        public GeneticAlgorithm(
            int populationSize, 
            int chromosomeLenght, 
            IFitness fitness,
            ISelection? selection = null, 
            IGeneticOperators? mutation = null, 
            IGeneticOperators? crossover = null)
        {            
            _populationSize = populationSize;
            _chromosomeLenght = chromosomeLenght;
            Populations.Add(new Population(populationSize, chromosomeLenght*2));
            _fitness = fitness;
            _selection = selection ?? new RankSelection(_fitness);
            _selection.Fitness(Populations.First());
            _mutation = mutation ?? new BitInversion();
            _crossover = crossover ?? new SinglePoint();
            BestGlobalScore = Populations.Min(x => x.BestScore);
        }    
        

        public void CreateNewPopulation()
        {
            var currentPopulation = Populations.Last().Clone();
            var newPopulation = currentPopulation.Clone();
            _mutation.OperateOnPopulation(newPopulation);
            _crossover.OperateOnPopulation(newPopulation);
            newPopulation.Individuals.AddRange(currentPopulation.Individuals);
            _selection.OperateOnPopulation(newPopulation, _populationSize);
            Populations.Add(newPopulation);
            BestGlobalScore = Populations.Min(x => x.BestScore);
        }

    }
}
