using Quantum.Inspired.Algorithms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms
{
    public class ScheduleFit : IFitness
    {
        private readonly List<(int value, int time)> jobs;
        private readonly int limit;

        public ScheduleFit(List<(int value, int time)> jobs, int limit)
        {
            this.jobs = jobs;
            this.limit = limit;
        }
        public double Fitness(IGenotype genotype)
        {
            var gene = genotype.Observe();
            var result = 0;
            var deadline = 0;

            for (int i = 0; i < gene.Chromosome.Length; i++)
            {
                if (gene.Chromosome[i] == '1')
                {
                    result += jobs[i].value;
                    deadline += jobs[i].time;
                }
            }
            if (result == 0 || deadline > limit)
                return 1;
            return (double)1/result;
        }

        public int GetSize()
        {
            return jobs.Count;
        }
    }
}
