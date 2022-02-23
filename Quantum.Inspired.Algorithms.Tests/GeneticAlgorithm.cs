using NUnit.Framework;
using Quantum.Inspired.Algorithms.Core;
using System;

namespace Quantum.Inspired.Algorithms.Tests
{
    public class GeneticAlgorithmTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1,1)]
        [TestCase(10, 1)]
        [TestCase(1, 10)]
        public void PopulationInit(int populationSize, int chromosomeSize)
        {
            Population population = new Population(populationSize, chromosomeSize);
            Assert.AreEqual(populationSize, population.Individuals.Count);
            population.Individuals.ForEach(i =>
            {
                Assert.AreEqual(chromosomeSize, i.Chromosome.Length);
            });
        }




        [Test]
        [TestCase(0, 10)]
        [TestCase(10, 0)]
        [TestCase(0, 0)]
        [TestCase(-10, 10)]
        [TestCase(10, -10)]
        [TestCase(-10, -10)]
        public void PopulationInitFail(int populationSize, int chromosomeSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(delegate { new Population(populationSize, chromosomeSize); });
        }
    }
}