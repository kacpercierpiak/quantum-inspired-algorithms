// See https://aka.ms/new-console-template for more information

using Quantum.Inspired.Algorithms;
using System.Text;

string lines = $"Algorithm,Fitness,Population Size,Target,Mutation,CrossOver,Count,Min,Max,Avg,Best Value,Best Value Counter,Best Value Avg, Best Value Counter Avg";
File.WriteAllText("WriteLines.txt", lines);
using StreamWriter file = new("WriteLines.txt", append: true);
file.WriteLine("");
List<int> populations = new()
{
    20,30,40,45,50,55,60
};

List<int> crossover = new()
{
    40,
    50,
    60,
    70,
    80,
    100
};

foreach(var j in populations)
{
    foreach(var cross in crossover)
    {
        
        StringBuilder result = new();
        for (int m = 0; m < 11; m++)
        {
            Console.WriteLine($"P{j}-C{cross}-M{m}");
            var mutation = m == 0 ? 1 : m * 2;
            Parallel.For(0, 10, i =>
            {
                var ex = new FunctionOptimization();
                result.Append(ex.Run(j, (double)(mutation) / 100, (double)(cross) / 100));
            });
        }

        file.WriteLine(result.ToString());
    }
}











