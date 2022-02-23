using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.GeneticOperators.Mutation
{
    public class BitInversion : IGeneticOperators
    {
        private double _probability { get; set; } = 0.0;

        public BitInversion(double probability = 0.15)
        {
            if(probability < 0.0 || probability > 1.0)
                throw new ArgumentOutOfRangeException(nameof(probability));
            _probability = probability;
        }

        public void OperateOnPopulation(Population population)
        {
            Random random = new();
            population.Individuals.ForEach(i =>
            {
            StringBuilder sb = new StringBuilder(i.Chromosome);
            for (int j = 0; j < i.Chromosome.Length;j++)
                {
                    if (random.NextDouble() <= _probability)
                        sb[j] = (sb[j] == '0' ? '1' :'0');                  
                }
            i.Chromosome = sb.ToString();
            });            
        } 
       
    }
}
