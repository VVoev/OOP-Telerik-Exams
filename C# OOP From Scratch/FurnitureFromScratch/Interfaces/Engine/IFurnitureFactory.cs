using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Interfaces.Engine
{
    public interface IFurnitureFactory
    {
        ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal lenght, decimal width);

        IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOFlegs);

        IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs);

        IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs);

    }
}
