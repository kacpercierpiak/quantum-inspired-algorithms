using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public class Q2Population
    {
        public List<Q2Genotype> Individuals { get; set; } = new List<Q2Genotype>();
        public double BestScore => Individuals.Min(x => x.GetScore());

        public Q2Population(int populationSize, int chromosomeLenght)
        {
            if (populationSize <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(populationSize),
                    "populationSize can't be negative or equal 0");
            if (chromosomeLenght <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(chromosomeLenght),
                    "chromosomeLenght can't be negative or equal 0");
            Individuals = GenerateIndividuals(populationSize, chromosomeLenght);
        }

        public Q2Population() { }

        public void ObservePopulation()
        {
            Individuals.ForEach(x => x.Observe());
        }

        private static List<Q2Genotype> GenerateIndividuals(int populationSize, int chromosomeLenght)
        {
            return Enumerable.Range(0, populationSize)
                .Select(x => new Q2Genotype() { Chromosome = new Q2ChromosomeDto() { Quantum = GenerateChromosome(chromosomeLenght) } }).ToList();
        }

        private static List<QubitPair> GenerateChromosome(int chromosomeLenght)
        {            
            var result = new List<QubitPair>();            
            for (int i = 0; i < chromosomeLenght; i++)
            {
                result.Add(new QubitPair());
            }
            return result;
        }


    }
}
