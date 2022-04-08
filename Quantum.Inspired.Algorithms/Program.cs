// See https://aka.ms/new-console-template for more information

using Quantum.Inspired.Algorithms;
using Quantum.Inspired.Algorithms.Core.Algorithms;
using System.Text;
string lines = $"Algorithm,Fitness,Population Size,Target,Mutation,CrossOver,Count,Min,Max,Avg,Best Value,Best Value Counter,Best Value Avg, Best Value Counter Avg";
File.WriteAllText("NewAlg.txt", lines);
using StreamWriter file = new("NewAlg.txt", append: true);
file.WriteLine("");


for (int p = 1; p < 13; p++)
{
    var populationSize = p * 10;   
    for (int c = 4; c <= 10; c++ )
    {
        var cross = c * 10;
        StringBuilder resultG = new();
        Parallel.For(0, 21, m =>
        {
            StringBuilder result2 = new();
            Console.WriteLine($"G-P{populationSize}-C{cross}-M{m}-START");
            var mutation = m == 0 ? 1 : m * 2;
            for (int i = 0; i < 10; i++)
            {
                var ex = new FunctionOptimization(new("Genetic Algorithm", new GeneticAlgorithm()));
                result2.Append(ex.Run(populationSize, (double)(mutation) / 100, (double)(cross) / 100));

            }
            lock (resultG)
            {
                resultG.Append(result2);
            }
            Console.WriteLine($"G-P{populationSize}-C{cross}-M{m}-STOP");
        });


        file.WriteLine(resultG.ToString());

        StringBuilder resultQ1 = new();
        Parallel.For(0, 10, i =>
        {
            Console.WriteLine($"Q1-P{populationSize}-START");
            var ex = new FunctionOptimization(new("Quantum Genetic Algorithm", new QuantumGeneticAlgorithm()));
            lock (resultQ1)
            {
                resultQ1.Append(ex.Run(populationSize, 0.0, (double)(cross) / 100));
            }
            Console.WriteLine($"Q1-P{populationSize}-STOP"); 
        });

        file.WriteLine(resultQ1.ToString());
    }    

    StringBuilder resultQ2 = new();
    Parallel.For(0, 10, i =>
    {
        StringBuilder result2 = new();
        for (int c = 0; c <= 10; c++)
        {
            Console.WriteLine($"Q2-P{populationSize}-C{c}-START");
            var ex = new FunctionOptimization(new("Quantum Genetic Algorithm 2", new QuantumGeneticAlgorithm2()));

            result2.Append(ex.Run(populationSize, 0.0, 0.90 + ((double)c / 100)));
            Console.WriteLine($"Q2-P{populationSize}-C{c}-STOP");
        }
        lock (resultQ2)
        {
            resultQ2.Append(result2);
        }
    });
    file.WriteLine(resultQ2.ToString());
}



Console.ReadLine();












