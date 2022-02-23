using Quantum.Inspired.Algorithms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms
{
    public class EasomFunc : Fit
    {
        public EasomFunc(double Amin = 0.0, double Amax = 0.0, int precision = 0) : base(Amin, Amax, precision) { }
        protected new static double Function(double x, double y)
        {
            return -Math.Cos(x) * Math.Cos(y) * Math.Exp(-(Math.Pow(x - Math.PI, 2) + Math.Pow(y - Math.PI, 2)));
        }
    }
}
