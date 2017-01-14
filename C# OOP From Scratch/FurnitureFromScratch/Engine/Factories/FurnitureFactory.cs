using FurnitureFromScratch.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFromScratch.Interfaces;
using FurnitureFromScratch.Models;

namespace FurnitureFromScratch.Engine.Factories
{
    class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string Invalid = "Invalid material name: {0}";


        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            //Todo ....
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOFlegs)
        {
            //Todo ....
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            //Todo ....
        }

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal lenght, decimal width)
        {
            //Todo ....
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:return MaterialType.Wooden;
                case Leather:return MaterialType.Leather;
                case Plastic:return MaterialType.Plastic;
                default:throw new ArgumentException(string.Format(Invalid, material));
            }
        }
    }
}
