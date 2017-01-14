using FurnitureFromScratch.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFromScratch.Interfaces;
using FurnitureManufacturer.Models;

namespace FurnitureFromScratch.Engine.Factories
{
    class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            return new Company(name, registrationNumber);
        }
    }
}
