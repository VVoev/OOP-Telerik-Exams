using FurnitureFromScratch.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Engine.Factories
{
    class ConsoleRenderer : IRenderer
    {
        public IEnumerable<string> Input()
        {
            var currentLine = Console.ReadLine();
            while (!string.IsNullOrEmpty(currentLine))
            {
                yield return currentLine;
                currentLine = Console.ReadLine();
            }
        }

        public void OutPut(IEnumerable<string> ouput)
        {
            var sb = new StringBuilder();
            foreach (var line in ouput)
            {
                sb.AppendLine(line);
            }
            Console.Write(sb.ToString());
        }
    }
}
