using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MulttableByDiapazonParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint rangeStart;
            uint rangeEnd;

            CheckNumberInput(out rangeStart, "\n Enter start of range: ");
            CheckNumberInput(out rangeEnd, "\n Enter end of range: ");

            while(rangeEnd < rangeStart)
                CheckNumberInput(out rangeEnd, $"\n Please enter number that greater than {rangeStart}: ");

            Parallel.ForEach<(uint, uint)>(new List<(uint, uint)>() { (rangeStart, rangeEnd) }, WriteMultTableRangeToFile);
        }

        static void WriteMultTableRangeToFile((uint, uint) range)
        {
            StringBuilder mult = new StringBuilder();

            for (uint i = range.Item1; i <= range.Item2; i++)
            {
                for (uint j = 1; j < 11; j++)
                    mult.Append($"{i} * {j} = {i * j}\r\n");
            }

            Console.WriteLine(mult.ToString());

            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MultTable.txt", mult.ToString());
        }
        static void CheckNumberInput(out uint number, string message)
        {
            string value;

            while(true)
            {
                Console.Write(message);
                value = Console.ReadLine();

                Console.Clear();
                if (!uint.TryParse(value, out number))
                    Console.WriteLine($" Invalid input \"{value}\", try again!\n");
                else
                    break;
            }
        }
    }
}
