using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Interfaces
{
    public interface ITable : IFurniture
    {
        decimal Lenght { get; }

        decimal Width { get; }

        decimal Area { get; }

    }
}
