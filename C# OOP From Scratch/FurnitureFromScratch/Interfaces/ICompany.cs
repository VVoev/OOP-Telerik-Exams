namespace FurnitureFromScratch.Interfaces
{
    using System.Collections.Generic;

    public interface ICompany
    {
        string name { get; }

        string RegistratinNumber { get; }

        ICollection<IFurniture> Furnitures { get; }

        void Add(IFurniture furniture);

        void Remove(IFurniture furniture);

        IFurniture Find(string model);

        string Catalog();


    }
}
