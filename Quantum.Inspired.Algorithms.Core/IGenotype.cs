using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public interface IGenotype
    {
        public Genotype Clone();

        public Genotype Observe();
        public double GetScore();
        public double GetPi();
        public void SetScore(double value);
        public void SetPi(double value);
        public double GetSelectionScore();
        public double SetSelectionScore(double value);
    }
}
