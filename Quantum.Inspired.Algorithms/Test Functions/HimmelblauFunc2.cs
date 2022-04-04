using Quantum.Inspired.Algorithms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms
{
    public class HimmelblauFunc2 : Fit2
    {
        public HimmelblauFunc2(double Amin = 0.0, double Amax = 0.0, int precision = 0) : base(Amin, Amax, precision) { }
        protected override double Function(double x, double y)
        {
            return Math.Pow((x * x) + y - 11, 2) + Math.Pow((x + (y * y) - 7), 2);
        }
    }
}
