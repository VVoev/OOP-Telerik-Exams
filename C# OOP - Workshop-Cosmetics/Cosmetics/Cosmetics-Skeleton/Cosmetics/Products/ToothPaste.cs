using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    class ToothPaste : Product, IToothpaste
    {
        private IList<string> ingredients;
        public ToothPaste(string name, string brand, decimal price, GenderType gender,IList<string>ingredients)
            : base(name, brand, price, gender)
        {
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }
    }
}
