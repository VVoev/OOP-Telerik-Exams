using FurnitureFromScratch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Models
{
    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model,decimal price,decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.height = height;
        }


        public virtual decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Height cannot be less than 0m");
                }
                this.height = value;
            }
        }

        public virtual string Material { get; set; }

        public virtual string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be null");
                }
                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be less than 0 BGN");
                }
                this.price = value;
            }
        }

        protected MaterialType MaterialType { get; set; }

        
    }
}
