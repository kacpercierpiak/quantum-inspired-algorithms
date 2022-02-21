using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public static class MyExtensions
    {
        public static Population Clone(this Population population)
        {
            return new Population()
            {
                Individuals = population.Individuals.Select(i => new Genotype()
                {
                    Chromosome = i.Chromosome.ToString(),
                    PI = i.PI,
                    Score = i.Score,
                    StopValue = i.StopValue
                }).ToList()
            };
        }
    }
}
