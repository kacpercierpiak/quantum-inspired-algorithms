using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public class QubitPair
    {

        public double[] Amplitudes = { 0.5,0.5,0.5,0.5};
    }
    public class Q2ChromosomeDto
    {
        public string Classical { get; set; } = String.Empty;
        public List<QubitPair> Quantum { get; set; } = new List<QubitPair>();
    }
    public class Q2Genotype : Genotype
    {
        public new Q2ChromosomeDto Chromosome { get; set; } = new Q2ChromosomeDto();

        public Q2Genotype(double score = 0.0, double pi = 0.0) : base(score, pi)
        {

        }
        public new Q2Genotype Clone()
        {
            return new Q2Genotype(_score, _pi)
            {
                Chromosome = new Q2ChromosomeDto() { Quantum = Chromosome.Quantum.ToList(), Classical = Chromosome.Classical}
            };
        }

        public override Genotype Observe()
        {
            
            var sb = new StringBuilder();
            Random random = new();

            for (int i = 0; i < Chromosome.Quantum.Count/2; i++)
            {
                var x = Chromosome.Quantum[i];
                var r = random.NextDouble();
                if (r < x.Amplitudes[1] * x.Amplitudes[1])
                {
                    sb.Append("00");     
                }
                else if (r < (x.Amplitudes[1] * x.Amplitudes[1]) + (x.Amplitudes[2] * x.Amplitudes[2]))
                {
                    sb.Append("01");              
                }
                else if (r < (x.Amplitudes[1] * x.Amplitudes[1]) + (x.Amplitudes[2] * x.Amplitudes[2]) + (x.Amplitudes[3] * x.Amplitudes[3]))
                {
                    sb.Append("10");
                }
                else
                {
                    sb.Append("11");
                }
            }
            Chromosome.Classical = sb.ToString();

            return new Genotype(_score, _pi) { Chromosome = Chromosome.Classical };
        }
    }
}
