using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public class Genotype
    {
        public string Chromosome { get; set; } = String.Empty;
        public double Score { get; set; } = 0.0;

        public double PI { get; set; } = 0.0;

        public double StopValue { get; set; } = 0;

        public Genotype Clone()
        {
            return new Genotype()
            {
                Chromosome = (string)Chromosome.Clone(),
                Score = Score,
                PI = PI,
                StopValue = StopValue
            };
        }

    }
}
