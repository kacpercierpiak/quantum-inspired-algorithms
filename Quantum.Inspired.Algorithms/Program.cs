// See https://aka.ms/new-console-template for more information
using Quantum.Inspired.Algorithms;
using Quantum.Inspired.Algorithms.Core;
using Quantum.Inspired.Algorithms.Core.Algorithms;




for (int j = 0; j < 10; j++)
{
    Console.WriteLine("!!!!!!!!!!Hello, World!");
    var Fitness = new Fit(-10.0, 10.0, 2);
    var population = new GeneticAlgorithm(20, Fitness.m, Fitness);
    Console.WriteLine(population.BestGlobalScore);
    for (int i = 0; i < 40; i++)
    {
        population.CreateNewPopulation();
        Console.WriteLine(i);
        Console.WriteLine(population.Populations[i + 1].BestScore);
        Console.WriteLine(population.BestGlobalScore);
        if (population.BestGlobalScore <= 0.001)
            break;
    }
}





