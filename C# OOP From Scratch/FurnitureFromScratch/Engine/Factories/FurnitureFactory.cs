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
            return new AdjustableChair(model, materialType, price, height, numberOfLegs);
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOFlegs)
        {
            return new Chair(model, materialType, price, height, numberOFlegs);
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            return new ConvertibleChair(model, materialType, price, height, numberOfLegs);
        }

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal lenght, decimal width)
        {
            return new Table(model, materialType, price, height, lenght, width);
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
