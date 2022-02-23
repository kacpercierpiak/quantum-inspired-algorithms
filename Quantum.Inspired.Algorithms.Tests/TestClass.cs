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
        [Test]
        public void Test()
        {
            var t = new double[2, 2, 2, 4]
            {
                {
                    {
                        { 0 ,0,0,0}, 
                        { 0 ,0,0,0}
                    }, 
                    {
                        { 0 ,0,0,0}, 
                        { -1 ,1,1,0}
                    }
                },
                {
                    {
                        { -1 ,1,1,0},
                        { 1 ,-1,0,1}
                    },
                    {
                        {1 ,-1,0,1},
                        { 1 ,-1,0,+1}
                    }
                }


            };
    }

        [Test]
        public void Test2()
        {
            var t =  new EasomFunc(-5.0, 5.0, 2);
            var result = t.Fitness(new Genotype() { Chromosome = "11010000011101000001" });
        }
    }
}
