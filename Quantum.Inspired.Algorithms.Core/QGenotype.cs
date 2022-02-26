using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public class ChromosomeDto
    {
        public string Classical { get; set; } = String.Empty;
        public List<double> Quantum { get; set; }
    }
    public class QGenotype : Genotype
    {
        public new ChromosomeDto Chromosome { get; set; } = new ChromosomeDto();

        public QGenotype(double score = 0.0, double pi = 0.0) : base(score, pi)
        {

        }
        public new QGenotype Clone()
        {
            return new QGenotype(_score, _pi)
            {
                Chromosome = new ChromosomeDto() { Quantum = Chromosome.Quantum.ToList(), Classical = Chromosome.Classical}
            };
        }

        public override Genotype Observe()
        {
            
            var sb = new StringBuilder();
            Random random = new Random();
            Chromosome.Quantum.ForEach(x =>
            {
                var alpha = Math.Cos(x);
                sb.Append(random.NextDouble() <= alpha * alpha ? 0 : 1);
            });
            Chromosome.Classical = sb.ToString();

            return new Genotype(_score, _pi) { Chromosome = Chromosome.Classical };
        }
    }
}
