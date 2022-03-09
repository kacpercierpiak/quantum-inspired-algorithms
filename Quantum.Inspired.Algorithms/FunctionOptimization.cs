using Quantum.Inspired.Algorithms;
using Quantum.Inspired.Algorithms.Core;
using Quantum.Inspired.Algorithms.Core.Algorithms;

namespace Quantum.Inspired.Algorithms
{
    public static class FunctionOptimization
    {
        private static List<(string Name, IFitness Fitness, double Target)> GenerateFitnessList()
        {
            var result = new List<(string Name, IFitness Fitness, double Target)>();
          //result.Add(new("Matyas function", new Fit(-10.0, 10.0, 2), 0.01));
          //result.Add(new("HimmelblauFunc", new HimmelblauFunc(-5.0, 5.0, 2), 0.01));
          //result.Add(new("EasomFunc", new EasomFunc(-20.0, 20.0, 2), -0.99));
          //result.Add(new("SchafferFunc", new SchafferFunc(-100.0, 100.0, 2), 0.30));
            result.Add(new("Schedule", new ScheduleFit(GenerateJobs(20),40),0));
            return result;
        }
        private static List<(int value, int time)> GenerateJobs(int qty)
        {
            var jobs = new List<(int value, int time)>();
            Random random = new();
            for (int i = 0; i < qty; i++)
            {
                jobs.Add(new(random.Next(1, 10), random.Next(1, 10)));
            }
            return jobs;
        }

        private static List<(string Name, IGeneticAlgorithm Algorithm)> GenerateAlgorithmList()
        {
            var result = new List<(string Name, IGeneticAlgorithm Algorithm)>();
            result.Add(new("Genetic Algorithm", new GeneticAlgorithm()));
            result.Add(new("Quantum Genetic Algorithm", new QuantumGeneticAlgorithm()));
            return result;
        }
        public static void Run()
        {
            var fitnessList = GenerateFitnessList();
            var algorithmList = GenerateAlgorithmList();
            


            foreach (var (Name, Algorithm) in algorithmList)
            {
                List<(double value, int counter)> bestValue = new List<(double value, int counter)>();
                bestValue.Add(new(Int32.MaxValue, 0));
                Console.WriteLine($"*** {Name} ***");
                foreach (var (fName, Fitness, Target) in fitnessList)
                {
                    var size = Fitness.GetSize() * 2;
                    if (fName == "Schedule")
                        size = Fitness.GetSize();
                    Console.WriteLine($@"--- {fName} ---");
                    var count = 0;
                    var list = new List<int>();
                    for (int j = 0; j < 100; j++)
                    {
                        Algorithm.Init(20, size, Fitness);
                        for (int i = 0; i < 200; i++)
                        {
                            Algorithm.CreateNewPopulation();
                            if (Algorithm.GetBestGlobalScore() <= Target)
                            {
                                count++;
                                list.Add(i);
                                break;
                            }
                            if(Algorithm.GetBestGlobalScore() < bestValue.Min().value)
                            {
                                bestValue.Add(new(Algorithm.GetBestGlobalScore(), i));
                            }
                        }
                        
                    }

                    Console.WriteLine(count.ToString());
                    if (count != 0)
                    {
                        Console.WriteLine(list.Min());
                        Console.WriteLine(list.Max());
                        Console.WriteLine(list.Average());
                    }
                    var b = bestValue.MinBy(x => x.value);
                    Console.WriteLine($"{b.value} - {b.counter} - {bestValue.Average(x=>x.value)} - {bestValue.Average(x => x.counter)}");
                }
            }
        }
    }
}
