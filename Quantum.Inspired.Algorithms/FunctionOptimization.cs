using Quantum.Inspired.Algorithms;
using Quantum.Inspired.Algorithms.Core;
using Quantum.Inspired.Algorithms.Core.Algorithms;
using System.Text;

namespace Quantum.Inspired.Algorithms
{
    public class FunctionOptimization
    {
        private List<(string Name, IFitness Fitness, double Target)> GenerateFitnessList()
        {
            var result = new List<(string Name, IFitness Fitness, double Target)>
            {
                new("Matyas function", new Fit(-10.0, 10.0, 2), 0.01),
                new("Matyas function2", new Fit2(-10.0, 10.0, 2), 0.01),
                new("HimmelblauFunc", new HimmelblauFunc(-5.0, 5.0, 2), 0.01),
                new("HimmelblauFunc2", new HimmelblauFunc2(-5.0, 5.0, 2), 0.01),
                new("EasomFunc", new EasomFunc(-20.0, 20.0, 2), -0.99),
                new("EasomFunc2", new EasomFunc2(-20.0, 20.0, 2), -0.99),
                new("SchafferFunc", new SchafferFunc(-100.0, 100.0, 2), 0.30),
                new("SchafferFunc2", new SchafferFunc2(-100.0, 100.0, 2), 0.30),
                new("Schedule", new ScheduleFit(GenerateJobs(20), 40), 0)
            };
            return result;
        }
        private List<(int value, int time)> GenerateJobs(int qty)
        {
            var jobs = new List<(int value, int time)>();
            Random random = new();
            for (int i = 0; i < qty; i++)
            {
                jobs.Add(new(random.Next(1, 10), random.Next(1, 10)));
            }
            return jobs;
        }

        private List<(string Name, IGeneticAlgorithm Algorithm)> GenerateAlgorithmList()
        {
            var result = new List<(string Name, IGeneticAlgorithm Algorithm)>
            {
                new("Genetic Algorithm", new GeneticAlgorithm()),
                //new("Quantum Genetic Algorithm", new QuantumGeneticAlgorithm())
            };
            return result;
        }
        public string Run(int populationSize, double mutation, double cross)
        {
            var fitnessList = GenerateFitnessList();
            var algorithmList = GenerateAlgorithmList();

            StringBuilder result = new();        
            foreach (var (Name, Algorithm) in algorithmList)
            {
               
                foreach (var (fName, Fitness, Target) in fitnessList)
                {
                    List<(double value, int counter)> bestValue = new()
                    {
                        new(Int32.MaxValue, 0)
                    };
                    var size = Fitness.GetSize() * 2;
                    if (fName == "Schedule")
                        size = Fitness.GetSize();
                   
                    result.Append($"{Name},");
                    result.Append($"{fName},");
                    result.Append($"{populationSize},");
                    result.Append($"{Target},");

                    var count = 0;
                    var list = new List<int>();
                   
                    result.Append($"{mutation},");
                    result.Append($"{cross},");
                    for (int j = 0; j < 100; j++)
                    {
                        Algorithm.Init(populationSize, size, Fitness, mutation, cross);
                        for (int i = 0; i < 200; i++)
                        {
                            Algorithm.CreateNewPopulation();
                            if (Algorithm.GetBestGlobalScore() <= Target)
                            {
                                count++;
                                list.Add(i);
                                break;
                            }
                            if (Algorithm.GetBestGlobalScore() < bestValue.Min().value)
                            {
                                bestValue.Add(new(Algorithm.GetBestGlobalScore(), i));
                            }
                        }

                    }
                    
                    if (count > 0)
                    {
                        result.Append($"{count},");
                        result.Append($"{list?.Min() ?? 0},");
                        result.Append($"{list?.Max() ?? 0},");
                        result.Append($"{list?.Average() ?? 0},");
                    }
                    else
                        result.Append("-,-,-,-,");


                    var (value, counter) = bestValue.MinBy(x => x.value);
                    result.AppendLine($"{value}, {counter}, {bestValue.Average(x=>x.value)}, {bestValue.Average(x => x.counter)}");
                }
            }
            return result.ToString();
        }
    }
}
