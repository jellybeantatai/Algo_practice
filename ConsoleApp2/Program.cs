using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = { { 3, 4 }, { 2, 3 }, { 7, 8 } };

            for(int i=0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("|"+arr[i,j]+"|");
                }
                Console.WriteLine("");
                for (int k=0; k < arr.GetLength(1); k++)
                {
                    Console.Write("---");
                }
                Console.WriteLine("");
            }

            if (1 > null)
            {
                Console.WriteLine("haha");
            }
        }
    }
}
