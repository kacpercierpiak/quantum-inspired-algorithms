﻿using Quantum.Inspired.Algorithms.Core.GeneticOperators.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.Algorithms
{
    public class QuantumGeneticAlgorithm : IGeneticAlgorithm
    {
        private int _populationSize { get; set; }
        private int _chromosomeLenght { get; set; }
        private IFitness _fitness { get; set; }
        private QGenotype? bestResult { get; set; }
        private Double _probability = Double.NaN;
        public List<QPopulation> Populations { get; private set; } = new List<QPopulation>();

        private double BestGlobalScore = 0.0;

        public double GetBestGlobalScore()
        {
            return BestGlobalScore;
        }

        public void Init(
            int populationSize,
            int chromosomeLenght,
            IFitness fitness,
            double mutation, double cross)
        {
            Populations.Clear();
            Populations.Add(new QPopulation(populationSize, chromosomeLenght));

            _populationSize = populationSize;
            _chromosomeLenght = chromosomeLenght;
            _fitness = fitness;
            _probability = cross;
            Populations[0].ObservePopulation();
            Populations[0].Individuals.ForEach(x => x.SetScore(_fitness.Fitness(x)));
            bestResult = Populations[0].Individuals.OrderBy(x => x.GetScore()).First();
            
            BestGlobalScore = Populations.Min(x => x.BestScore);
        }


        public void CreateNewPopulation()
        {
            var currentPopulation = Populations.First().Clone();
            currentPopulation.Individuals.ForEach(x=> x.SetScore(_fitness.Fitness(x)));
            Update(currentPopulation);           
            bestResult = currentPopulation.Individuals.OrderBy(x => x.GetScore()).First();            

            Populations.Add(currentPopulation);
            BestGlobalScore = Populations.Min(x => x.BestScore);
        }

        private void Update(QPopulation population)
        {
            foreach (var individual in population.Individuals)
            {
                var best = bestResult?.GetScore();
                var newIsbetter = individual.GetScore() >= best;          
                for (int j=0; j < individual.Chromosome.Classical.Length;j++)
                {
                    char x = individual.Chromosome.Classical[j];
                    char b = bestResult.Chromosome.Classical[j];
                    var delta = lookup[x == '1' ? 1 : 0, b == '1' ? 1 : 0, newIsbetter ? 1 : 0];
                    double angle = individual.Chromosome.Quantum[j] % Math.PI;
                    int index = (angle > double.Epsilon) && angle < ((Math.PI / 4) - double.Epsilon) ? 0 :
                        (angle > (Math.PI - double.Epsilon)) && angle < ((Math.PI / 2) + double.Epsilon) ? 1 :
                        (Math.Abs(((Math.PI / 2 + individual.Chromosome.Quantum[j]) % Math.PI) - Math.PI / 2) < double.Epsilon) ? 2 : 3;

                    double sign = signs_table[x == '1' ? 1 : 0, b == '1' ? 1 : 0, newIsbetter ? 1 : 0, index];
                    individual.Chromosome.Quantum[j] += delta * sign;    
                }
                individual.SetScore(_fitness.Fitness(individual));

            }
            
        }

        private readonly double[,,] lookup = new double[2, 2, 2]
        {
            {{0, 0}, {0, Math.PI*0.05}},
            {{Math.PI*0.01, Math.PI*0.025}, {Math.PI*0.005, Math.PI*0.025}}
        };

        private readonly double[,,,] signs_table = new double[2, 2, 2,4]
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
                        { 1 ,-1,0,1},
                        { 1 ,-1,0,1}
                    }
                }
};
    }
}
