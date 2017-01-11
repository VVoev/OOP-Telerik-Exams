using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo,IProduct
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender,uint mililitres,UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Mililitres = mililitres;
            this.Usage = usage;
        }
        public override decimal Price
        {
            get
            {
                return this.Mililitres*base.Price;
            }
        }

        public uint Mililitres { get; private set; }
        public UsageType Usage { get; private set; }

    }
}
