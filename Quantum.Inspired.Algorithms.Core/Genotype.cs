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
        protected double _selectionScore { get; set; } = 0.0;

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
        public double GetSelectionScore() => _selectionScore;
        public double SetSelectionScore(double value) => _selectionScore = value;

        public double GetPi() => _pi;

        public void SetScore(double value) => _score = value;

        public void SetPi(double value) => _pi = value;
    }
}
