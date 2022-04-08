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

        public static Q2Population Clone(this Q2Population population)
        {
            return new Q2Population()
            {
                Individuals = population.Individuals.Select(i => i.Clone()).ToList()
            };
        }

        public static string ConvertToRBC(this string binary) => BinaryConverter.BinaryToRBC(binary);
        public static string ConvertToBinary(this string rbc) => BinaryConverter.RBCtoBinary(rbc);

    }
}
