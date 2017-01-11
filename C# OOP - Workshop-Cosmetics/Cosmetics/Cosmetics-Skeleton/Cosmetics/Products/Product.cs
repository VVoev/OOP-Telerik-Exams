using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        //fields
        private string brand;
        private string name;
        private decimal price;

        //constants
        private const int MinProductLen = 3;
        private const int MaxProductLen = 10;
        private const int MinBrandLen = 2;
        private const int MaxBrandLen = 10;

        //constructor
        protected Product(string name,string brand,decimal price,GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product brand"));
                Validator.CheckIfStringLengthIsValid(
                                                      value,
                                                      MaxBrandLen,
                                                      MinBrandLen,
                                                      string.Format
                                                      (GlobalErrorMessages.InvalidStringLength, "Product brand", MinBrandLen, MaxBrandLen));
                this.brand = value;
            }
        }

        public GenderType Gender { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name"));
                Validator.CheckIfStringLengthIsValid(
                                                      value,
                                                      MaxProductLen,
                                                      MinProductLen,
                                                      string.Format
                                                      (GlobalErrorMessages.InvalidStringLength, "Product name", MinProductLen, MaxProductLen));
                this.name = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {

            }
        }

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendFormat($"- {this.Brand} – {this.Name}:{Environment.NewLine}");
            sb.AppendFormat($"  *Price: ${this.Price}{Environment.NewLine}");
            sb.AppendFormat($"  *For gender: {this.Gender}{Environment.NewLine}");
            return sb.ToString();
        }
    }
}
