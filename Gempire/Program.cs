using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gempire
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing StreamWriter and StreamReader
            string[] lines = { "First line", "Second line", "Third line" };
            string path = @"C:\Users\jonph\Desktop\C#\Projects\Gempire\Gempire\Data\Test.txt";

            foreach (var line in lines)
            {
                using (var file = new StreamWriter(path, true))
                {
                    file.WriteLine(line);
                }
            }

            using (var file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                file.Close();
            }
            Console.ReadLine();
        }
    }
}
