using Quantum.Inspired.Algorithms.Core;

namespace Quantum.Inspired.Algorithms
{
    public class Fit : IFitness
    {
        private readonly double _Amin = 0.0;
        private readonly double _Amax = 0.0;
        private readonly int _precision = 0;
        private readonly int m = 0;

        public Fit(double Amin = 0.0, double Amax = 0.0, int precision = 0)
        {
            _Amin = Amin;
            _Amax = Amax;
            _precision = precision;
            var target = (Amax - Amin) * Math.Pow(10, precision) + 1;
            for (m = 0; Math.Pow(2, m) < target; m++) { }

        }

        public int GetSize()
        {
            return m;
        }
        public double Fitness(IGenotype genotype)
        {
            var gene = genotype.Observe();
            var first = gene.Chromosome.Substring(0, gene.Chromosome.Length / 2);
            var second = gene.Chromosome.Substring(gene.Chromosome.Length / 2, gene.Chromosome.Length / 2);

            var x = (double)_Amin + ((_Amax - _Amin) * (double)Convert.ToInt32(first, 2) / (Math.Pow(2, m) - 1));
            var y = (double)_Amin + ((_Amax - _Amin) * (double)Convert.ToInt32(second, 2) / (Math.Pow(2, m) - 1));
            return Function(x, y);
        }

        protected virtual double Function(double x, double y)
        {
            return (0.26 * ((x * x) + (y * y))) - (0.48 * x * y);
        }
    }
}
