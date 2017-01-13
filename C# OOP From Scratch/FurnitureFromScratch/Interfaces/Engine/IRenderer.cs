using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Interfaces.Engine
{
    interface IRenderer
    {
        IEnumerable<string> Input();
        void OutPut(IEnumerable<string> ouput);
    }
}
