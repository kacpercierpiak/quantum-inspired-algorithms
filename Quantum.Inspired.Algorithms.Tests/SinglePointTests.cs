using NUnit.Framework;
using Quantum.Inspired.Algorithms.Core;
using Quantum.Inspired.Algorithms.Core.GeneticOperators.Crossover;
using System;
using System.Linq;

namespace Quantum.Inspired.Algorithms.Tests
{
    public class SinglePointTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(11, 10)]
        public void CreatePairsTests(int populationSize, int chromosomeSize)
        {
            var population = new Population(populationSize, chromosomeSize);
            var pairs = SinglePoint.CreatePairs(population);
            Assert.AreEqual(population.Individuals.Count / 2, pairs.Count);
            var tmp = pairs.SelectMany(x=>new[] {x.Item1,x.Item2}).ToList();
            Assert.AreEqual(tmp.Count, tmp.Distinct().ToList().Count);
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(11, 10)]
        public void EvolveTests(int populationSize, int chromosomeSize)
        {
            var population = new Population(populationSize, chromosomeSize);
            
            var newPopulation = population.Clone();
            var pairs = SinglePoint.CreatePairs(newPopulation);
            SinglePoint.Evolve(newPopulation, pairs);
            
        }
    }
}
