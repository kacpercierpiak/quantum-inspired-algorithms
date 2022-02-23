using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.GeneticOperators.Crossover
{
    public class SinglePoint : IGeneticOperators
    {
        private double _probability { get; set; } = 0.70;

        public SinglePoint(double probability = 0.7)
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

        public static (string Item1, string Item2) Cross(string item1Str, string item2Str)
        {
            Random random = new();
            var crossOverPosition = random.Next(1, item1Str.Length);
            var Item1 = item1Str.Remove(0, crossOverPosition).Insert(0, item2Str[..crossOverPosition]);
            var Item2 =item2Str.Remove(0, crossOverPosition).Insert(0, item1Str[..crossOverPosition]);
            return new(Item1, Item2);
        }


        public static void Evolve(Population population, List<(int, int)> pairs)
        {
           
            var chromosomeLenght = population.Individuals.First().Chromosome.Length;
            pairs.ForEach(pair =>
            {
                var item1Left = population.Individuals[pair.Item1].Chromosome.Substring(0, chromosomeLenght / 2);
                var item1Right = population.Individuals[pair.Item2].Chromosome.Substring(chromosomeLenght / 2, chromosomeLenght / 2);

                var item2Left = population.Individuals[pair.Item2].Chromosome.Substring(0, chromosomeLenght / 2);
                var item2Right = population.Individuals[pair.Item2].Chromosome.Substring(chromosomeLenght / 2, chromosomeLenght / 2);

                var leftResult = Cross(item1Left, item2Left);
                var rightResult = Cross(item1Right, item2Right);
                population.Individuals[pair.Item1].Chromosome = leftResult.Item1 + rightResult.Item1;
                population.Individuals[pair.Item1].Chromosome = leftResult.Item1 + rightResult.Item2;
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
