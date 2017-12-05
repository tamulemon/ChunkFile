using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please input your file path:");
            string inputFilePath = Console.ReadLine();

            Console.WriteLine("Please input your chunk size in a number");
            string inputSize = Console.ReadLine();
            int chunkSize;
            while (!Int32.TryParse(inputSize, out chunkSize))
            {
                Console.WriteLine("Please input an integer number.");
                inputSize = Console.ReadLine();
            }

            Console.ReadLine();

        }
    }
}
