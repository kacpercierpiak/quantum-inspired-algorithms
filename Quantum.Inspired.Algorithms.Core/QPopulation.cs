using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public class QPopulation
    {
        public List<QGenotype> Individuals { get; set; } = new List<QGenotype>();
        public double BestScore => Individuals.Min(x => x.GetScore());

        public QPopulation(int populationSize, int chromosomeLenght)
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

        public QPopulation() { }

        public void ObservePopulation()
        {
            Individuals.ForEach(x => x.Observe());
        }

        private static List<QGenotype> GenerateIndividuals(int populationSize, int chromosomeLenght)
        {
            return Enumerable.Range(0, populationSize)
                .Select(x => new QGenotype() { Chromosome = new ChromosomeDto() { Quantum = GenerateChromosome(chromosomeLenght) } }).ToList();
        }

        private static List<double> GenerateChromosome(int chromosomeLenght)
        {            
            var result = new List<double>();            
            for (int i = 0; i < chromosomeLenght; i++)
            {
                result.Add(Math.PI/4);
            }
            return result;
        }
    }
}
