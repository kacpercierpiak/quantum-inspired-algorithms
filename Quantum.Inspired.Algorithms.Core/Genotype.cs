using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public class Genotype : IGenotype
    {
        public string Chromosome { get; set; } = String.Empty;
        protected double _score { get; set; }

        protected double _pi { get; set; }

        public Genotype Clone()
        {
            return new Genotype(_score, _pi)
            {
                Chromosome = (string)Chromosome.Clone()         
            };
        }

        public Genotype(double score = 0.0, double pi= 0.0)
        {
            _score = score;
            _pi = pi;
        }

        public virtual Genotype Observe() => this;

        public double GetScore() => _score;

        public double GetPi() => _pi;

        public void SetScore(double value) => _score = value;

        public void SetPi(double value) => _pi = value;
    }
}
