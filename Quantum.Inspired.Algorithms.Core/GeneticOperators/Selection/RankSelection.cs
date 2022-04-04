﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.GeneticOperators.Selection
{
    public class RankSelection : ISelection
    {
        //Choose an 1<=Amax<=1.2, normally we use Amax = 1.2
        private readonly static double Amax = 1.2;   
        private readonly static double Amin = 2 - Amax;
        private readonly IFitness _fitness; 

        public RankSelection(IFitness fitness)
        {
            _fitness = fitness;
        }

        private static double CountPi(int rank, int populationSize)
        {
            return (Amax - (Amax - Amin) * ((double)rank - 1) / ((double)populationSize - 1)) * (1 / (double)populationSize);
        }

        public void Fitness(Population population)
        {
            
            population.Individuals.ForEach(x => x.SetScore(_fitness.Fitness(x)));
            population.Individuals = population.Individuals.OrderBy(x => x.GetScore()).ToList();            

            for (int i = 0; i < population.Individuals.Count; i++)
            {
                population.Individuals[i].SetPi(CountPi(i, population.Individuals.Count));              
            }
        }
        public void OperateOnPopulation(Population population, int outputSize)
        {
            Fitness(population);            

            List<int> wheel = new();            

            for(int i = 0; i < population.Individuals.Count; i++)
            {                
                wheel.AddRange(Enumerable.Repeat(i, (int)(population.Individuals[i].GetPi()*100)));
            }

            var resultPopulation = new List<Genotype>();

            for (int i = 0; i < outputSize; i++)
            {
                Random random = new();
                var id = random.Next(0, wheel.Count);

                resultPopulation.Add(population.Individuals[wheel[id]].Clone());
            }

            population.Individuals = resultPopulation;
        }

        public void OperateOnPopulation(Population population)
        {
            var outputSize = population.Individuals.Count;
            OperateOnPopulation(population, outputSize);
        }
    }
}
