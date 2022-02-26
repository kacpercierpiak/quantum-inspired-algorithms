// See https://aka.ms/new-console-template for more information
using Quantum.Inspired.Algorithms;
using Quantum.Inspired.Algorithms.Core;
using Quantum.Inspired.Algorithms.Core.Algorithms;

var count = 0;
var list = new List<int>();
for (int j = 0; j < 100; j++)
{
    //var Fitness = new Fit(-10.0, 10.0, 2); //min-> 0
    //var Fitness = new HimmelblauFunc(-5.0, 5.0, 2); //min-> 0.01
    //var Fitness = new EasomFunc(-20.0, 20.0, 2); //min-> -0.99
    var Fitness = new SchafferFunc(-100.0, 100.0, 2); // min-> 0.30
    var population = new QuantumGeneticAlgorithm(80, Fitness.m, Fitness
        );
    for (int i = 0; i < 200; i++)
    {
        population.CreateNewPopulation();
        if (population.BestGlobalScore <= 0.30)
        {
            count++;
            list.Add(i);
            
            break;
        }
            
    }
}

Console.WriteLine(count.ToString());
if(count != 0)
{
    Console.WriteLine(list.Min());
    Console.WriteLine(list.Max());
    Console.WriteLine(list.Average());
}






