using Quantum.Inspired.Algorithms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms
{
    public class Fit : IFitness
    {
        private readonly double _Amin = 0.0;
        private readonly double _Amax = 0.0;
        private readonly int _precision = 0;
        public readonly int m = 0;

        public Fit(double Amin = 0.0, double Amax = 0.0, int precision = 0)
        {
            _Amin = Amin;
            _Amax = Amax;
            _precision = precision;
            var target = (Amax - Amin) * Math.Pow(10, precision) + 1;
            for (m = 0; Math.Pow(2, m) < target; m++) { }

        }
        public double Fitness(Genotype chromosome)
        {
            var value = (double)_Amin + ((_Amax - _Amin) * (double)Convert.ToInt32(chromosome.Chromosome, 2) / (Math.Pow(2, m) - 1));

            var x = value;
            var y = value;
            return (0.26 * ((x * x) + (y * y))) - (0.48 * x * y);
        }
    }
}
