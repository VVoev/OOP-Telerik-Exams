using FurnitureFromScratch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company()
        {
            this.furnitures = new List<IFurniture>();
        }

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (value.Length < 5)
                {
                    throw new ArgumentException("Name should be at least 5 symbols");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            set
            {
                if (value.Length != 10 || value == null)
                {
                    throw new ArgumentException("Registration number should be exatctly 10 digits");
                }
                if (this.ContainsOnlyDigits(value))
                {
                    throw new ArgumentException("Should contain only digits");
                }
                this.registrationNumber = value;

            }
        }

        private bool ContainsOnlyDigits(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            throw new NotImplementedException();
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());

        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }
    }
}
