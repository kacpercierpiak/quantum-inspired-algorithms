﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public interface IFitness
    {
        public double Fitness(IGenotype genotype);
        public int GetSize();
    }
}
