using FurnitureFromScratch.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch
{
    class Program
    {
        static void Main()
        {
            //Singleton Implementation
            FurnitureManufacturerEngine.Instance.Start();
        }
    }
}
