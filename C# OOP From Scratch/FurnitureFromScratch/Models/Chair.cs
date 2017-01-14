using FurnitureFromScratch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Models
{
    public class Chair : Furniture, IChair
    {
        private string model;
        private decimal price;
        private decimal height;

        public int NumberOfLegs { get; private set; }

        public Chair(string model,MaterialType materialType,decimal price,decimal height,int numbersOfLegs)
            :base(model,price,height)
        {
            this.MaterialType = materialType;
            this.NumberOfLegs = numbersOfLegs;
        }

   
    }
}
