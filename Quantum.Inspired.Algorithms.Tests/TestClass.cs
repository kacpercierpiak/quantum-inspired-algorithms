using NUnit.Framework;
using Quantum.Inspired.Algorithms.Core;
using Quantum.Inspired.Algorithms.Core.GeneticOperators.Crossover;
using System;
using System.Linq;
using Quantum.Inspired.Algorithms;

namespace Quantum.Inspired.Algorithms.Tests
{
    public class TestClass
    {
        [Test]
        [TestCase("11111111111")]
        [TestCase("100100001")]
        public void CreatePairsTests(string str)
        {
           var result = new Fit(-10.0, 10.0, 2);
           var r = result.Fitness(new Genotype(){ Chromosome = str });
        }
    }
}
