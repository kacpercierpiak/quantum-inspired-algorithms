using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Inspired.Algorithms.Core
{
    public static class BinaryConverter
    {
        public static char XOR(char a, char b) =>  (a == b) ? '0' : '1';       
        public static char Flip(char c) => (c == '0') ? '1' : '0';
        public static string BinaryToRBC(string binary)
        {
            StringBuilder result = new();
            result.Append(binary[0]);

            for(int i = 1; i < binary.Length; i++)
            {
                result.Append(XOR(binary[i - 1], binary[i]));
            }

            return result.ToString();
        }
        public static string RBCtoBinary(string rbc)
        {
            StringBuilder result = new();
            result.Append(rbc[0]);

            for (int i = 1; i < rbc.Length; i++)
            {
                if (rbc[i] == '0')
                    result.Append(result[i - 1]);
                else
                    result.Append(Flip(result[i - 1]));
            }

            return result.ToString();
        }
    }
}
