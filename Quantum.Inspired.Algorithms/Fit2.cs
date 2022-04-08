using Quantum.Inspired.Algorithms.Core;

namespace Quantum.Inspired.Algorithms
{
    public class Fit2 : Fit
    {  
        public Fit2(double Amin = 0.0, double Amax = 0.0, int precision = 0) :base(Amin,Amax,precision)
        {

        }
        protected override (string first, string second) SplitChromosome(string chromosome) => new(chromosome[..(chromosome.Length / 2)].ConvertToBinary(), chromosome[(chromosome.Length / 2)..].ConvertToBinary());
    }
}
