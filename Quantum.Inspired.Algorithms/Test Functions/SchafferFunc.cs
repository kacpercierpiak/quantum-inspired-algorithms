using Quantum.Inspired.Algorithms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms
{
    public class SchafferFunc : Fit
    {
        public SchafferFunc(double Amin = 0.0, double Amax = 0.0, int precision = 0) : base(Amin, Amax, precision){}     

        protected new static double Function(double x, double y)
        {
            return 0.5 + ((Math.Pow(Math.Cos(Math.Sin(Math.Abs((x * x) - (y * y)))), 2) - 0.5) / Math.Pow(1 + 0.001 * ((x * x) + (y * y)), 2));
        }
    }
}
