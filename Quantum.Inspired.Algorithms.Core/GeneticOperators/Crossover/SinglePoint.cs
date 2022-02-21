using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.GeneticOperators.Crossover
{
    public class SinglePoint : IGeneticOperators
    {
        private double _probability { get; set; } = 0.80;

        public SinglePoint(double probability = 0.80)
        {
            if (probability < 0.0 || probability > 1.0)
                throw new ArgumentOutOfRangeException(nameof(probability));
            _probability = probability;
        }

        public void OperateOnPopulation(Population population)
        {            
            List<(int, int)> pairs = CreatePairs(population);
            Evolve(population, pairs);                   
        }

        public static void Evolve(Population population, List<(int, int)> pairs)
        {
            Random random = new();
            pairs.ForEach(pair =>
            {
                var crossOverPosition = random.Next(1, population.Individuals.First().Chromosome.Length);
                var tmpGene = population.Individuals[pair.Item1].Chromosome[..crossOverPosition];
              
                var replace = population.Individuals[pair.Item2].Chromosome[..crossOverPosition];
                population.Individuals[pair.Item1].Chromosome =
                population.Individuals[pair.Item1].Chromosome.Remove(0, crossOverPosition).Insert(0, replace);
                population.Individuals[pair.Item2].Chromosome =
                population.Individuals[pair.Item2].Chromosome.Remove(0, crossOverPosition).Insert(0, tmpGene);             
            });
        }

        public static List<(int, int)> CreatePairs(Population population)
        {
            List<(int, int)> pairs = new List<(int, int)>();
            Random random = new();
            var position = Enumerable.Range(0, population.Individuals.Count).ToList();
            for (int i = 0; i < population.Individuals.Count / 2; i++)
            {
                var firstParent = position[random.Next(0, position.Count)];
                position.Remove(firstParent);

                var secondParent = position[random.Next(0, position.Count)];
                position.Remove(secondParent);

                pairs.Add(new(firstParent, secondParent));
            }
            return pairs;
        }
    }
}
