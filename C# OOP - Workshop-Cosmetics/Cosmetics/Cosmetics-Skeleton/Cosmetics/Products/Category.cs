using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        //fields
        private const int MinLen = 2;
        private const int MaxLen = 15;
        private string name;
        private readonly ICollection<IProduct> products;

        //constructor 
        public Category(string name)
        {
            this.products = new List<IProduct>();
            this.Name = name;
        }

        //properties
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty,"Category name"));
                Validator.CheckIfStringLengthIsValid(
                    value,
                    MaxLen,
                    MinLen,
                    string.Format
                    (GlobalErrorMessages.InvalidStringLength,"Category name", MinLen, MaxLen));
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0} category – {1} {2} in total",
                            this.Name,
                            this.products.Count,
                            this.products.Count == 1 ? "product" : "products");

            var sortedProducts = this.products
                                 .OrderBy(x => x.Brand)
                                 .ThenBy(x => x.Price);
             
            foreach (var product in sortedProducts)
            {
                sb.AppendLine(product.Print());
            }
            return sb.ToString();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.products.Contains(cosmetics))
            {
                throw new ArgumentException(string.Format($"Product {cosmetics.Name} does not exist in category {this.Name}"));
            }
            this.products.Remove(cosmetics);
        }
    }
}
