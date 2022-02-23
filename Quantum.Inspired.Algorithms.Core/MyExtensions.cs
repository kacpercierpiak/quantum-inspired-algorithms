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
                Individuals = population.Individuals.Select(i => i.Clone()).ToList()
            };
        }

        public static QPopulation Clone(this QPopulation population)
        {
            return new QPopulation()
            {
                Individuals = population.Individuals.Select(i => i.Clone()).ToList()
            };
        }
    }
}
