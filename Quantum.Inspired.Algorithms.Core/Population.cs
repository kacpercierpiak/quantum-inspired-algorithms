using System.Linq;
using System.Text;

namespace Quantum.Inspired.Algorithms.Core
{
    public class Population 
    {
        public List<Genotype> Individuals { get; set; } = new List<Genotype>();
        public double BestScore => Individuals.Min(x => x.GetScore());

        public Population(int populationSize, int chromosomeLenght)
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

        public Population() {}       

        private static List<Genotype> GenerateIndividuals(int populationSize, int chromosomeLenght)
        {
            return Enumerable.Range(0, populationSize)
                .Select(x => new Genotype() { Chromosome = GenerateChromosome(chromosomeLenght) }).ToList();
        }

        private static string GenerateChromosome(int chromosomeLenght)
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < chromosomeLenght; i++)
            {
                sb.Append(rand.Next(0, 2));
            }            
            return sb.ToString();
        }    
    }
}