using Quantum.Inspired.Algorithms.Core.GeneticOperators.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core.Algorithms
{
    public class QuantumGeneticAlgorithm2 : IGeneticAlgorithm
    {
        private int _populationSize { get; set; }
        private int _chromosomeLenght { get; set; }
        private IFitness _fitness { get; set; }
        private Q2Genotype? bestResult { get; set; }
        private Double _probability = Double.NaN;
        public List<Q2Population> Populations { get; private set; } = new List<Q2Population>();

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
            Populations.Add(new Q2Population(populationSize, chromosomeLenght));

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

        private void Update(Q2Population population)
        {
            string b = bestResult.Chromosome.Classical;
            foreach (var individual in population.Individuals)
            {
                var best = bestResult?.GetScore();
                
                for (int j=0; j < individual.Chromosome.Classical.Length/2;j++)
                {
                    QubitPair Q = new QubitPair();                    
                    var bestAmp = Convert.ToInt32(b[j..(j+2)], 2);
                    QubitPair Qprim = new QubitPair();
                    double sum = 0.0;
                    for (int amp = 0; amp < 4; amp++)
                    {
                        if (bestAmp != amp)
                        {
                            Qprim.Amplitudes[amp] = _probability * individual.Chromosome.Quantum[j].Amplitudes[amp];
                            sum += Qprim.Amplitudes[amp] * Qprim.Amplitudes[amp];
                        }
                    }
                    Qprim.Amplitudes[bestAmp] = Math.Sqrt(sum);
                   
                    individual.Chromosome.Quantum[j].Amplitudes = Qprim.Amplitudes;                   

                }
                individual.SetScore(_fitness.Fitness(individual));

            }
            
        }
    }
}
