using FurnitureFromScratch.Engine.Factories;
using FurnitureFromScratch.Interfaces;
using FurnitureFromScratch.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Engine
{
   public sealed class FurnitureManufacturerEngine : IFurnitureManufacturerEngine
    {
        //properties

        private static IFurnitureManufacturerEngine instance;

        private readonly ICompanyFactory companyFactory;
        private readonly IFurnitureFactory furnitureFactory;
        private readonly IDictionary<string, ICompany> companies;
        private readonly IDictionary<string, IFurniture> furnitures;
        private readonly IRenderer renderer;

        //constructor
        private FurnitureManufacturerEngine()
        {
            this.companyFactory = new CompanyFactory();
            this.furnitureFactory = new FurnitureFactory();
            this.companies = new Dictionary<string, ICompany>();
            this.furnitures = new Dictionary<string, IFurniture>();
            this.renderer = new ConsoleRenderer();
        }

        public static IFurnitureManufacturerEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FurnitureManufacturerEngine();
                }
                return instance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var comandsRessult = this.ProcessCommands(commands);
            //this.rendererCommandRessults(comandsRessult);
        }

        private IEnumerable<string> ProcessCommands(ICollection<ICommand> commands)
        {
            var commandRessults = new List<string>();
            foreach (var command in commands)
            {
                string comandResult;
                switch (command.Name)
                {
                    case EngineConstants.CreateCompanyCommand:
                        var companyName = command.Parameters[0];
                        var companyRegistrationNumber = command.Parameters[1];
                        comandResult = this.CreateCompany(companyName, companyRegistrationNumber);
                        commandRessults.Add(comandResult);
                        break;
                    case EngineConstants.AddFurnitureToCompanyCommand:
                        var companyAddTo = command.Parameters[0];
                        var furnituresToBeAdded = command.Parameters[1];
                        comandResult = this.AddFurnitureToCompany(companyAddTo, furnituresToBeAdded);
                        commandRessults.Add(comandResult);
                        break;
                    case EngineConstants.RemoveFurnitureFromCompanyCommand:
                        var companyRemoveFrom = command.Parameters[0];
                        var furnituresToBeRemoved = command.Parameters[1];
                        comandResult = this.RemoveFurnitureFromCompany(companyRemoveFrom, furnituresToBeRemoved);
                        commandRessults.Add(comandResult);
                        break;
                    case EngineConstants.FindFurnitureFromCompanyCommand:
                        var companyFind = command.Parameters[0];
                        var furnitureFind = command.Parameters[1];
                        comandResult = this.FindFurniture(companyFind, furnitureFind);
                        commandRessults.Add(comandResult);
                        break;
                    case EngineConstants.ShowCompanyCatalogCommand:
                        var companyCatalog = command.Parameters[0];
                        comandResult = this.ShowCatalog(companyCatalog);
                        commandRessults.Add(comandResult);
                        break;
                    case EngineConstants.CreateTableCommand:
                        var tableModel = command.Parameters[0];
                        var tableMaterial = command.Parameters[1];
                        var tablePrice = decimal.Parse(command.Parameters[2]);
                        var tableHeight = decimal.Parse(command.Parameters[3]);
                        var tableLenght = decimal.Parse(command.Parameters[4]);
                        var tableWidth = decimal.Parse(command.Parameters[5]);
                        comandResult = this.CreateTable(tableModel, tableMaterial, tablePrice, tableHeight, tableLenght, tableWidth);
                        commandRessults.Add(comandResult);
                        break;
                    case EngineConstants.CreateChairCommand:
                        var chairModel = command.Parameters[0];
                        var chairMaterial = command.Parameters[1];
                        var chairPrice = decimal.Parse(command.Parameters[2]);
                        var chairHeight = decimal.Parse(command.Parameters[3]);
                        var chairLegs = int.Parse(command.Parameters[4]);
                        var chairType = command.Parameters[5];
                        comandResult = this.CreateChair(chairModel, chairMaterial, chairPrice, chairHeight, chairLegs, chairType);
                        commandRessults.Add(comandResult);
                        break;
                    case EngineConstants.SetChairHeight:
                        var adjChairModel = command.Parameters[0];
                        var adjChairHeight = decimal.Parse(command.Parameters[1]);
                        comandResult = this.AdjustChairHeight(adjChairModel, adjChairHeight);
                        commandRessults.Add(comandResult);
                        break;
                    case EngineConstants.ConvertChair:
                        var convertibleChairModel = command.Parameters[0];
                        comandResult = this.ConvertChair(convertibleChairModel);
                        commandRessults.Add(comandResult);
                        break;
                    default: commandRessults.Add(string.Format(EngineConstants.InvalidCommandErrorMessage, command.Name));
                        break;
                }
            }
            return commandRessults;
        }

        private string ConvertChair(string convertibleChairModel)
        {
            if (!this.furnitures.ContainsKey(convertibleChairModel))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, convertibleChairModel);
            }
            var convChair = this.furnitures[convertibleChairModel] as IConvertibleChair;
            if(convChair == null)
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, convertibleChairModel);
            }
            convChair.Convert();
            return string.Format(EngineConstants.ChairStateConvertedSuccessMessage, convertibleChairModel);


        }

        private string AdjustChairHeight(string adjChairModel, decimal height)
        {
            if (!this.furnitures.ContainsKey(adjChairModel))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, adjChairModel);
            }
            var adjChair = this.furnitures[adjChairModel] as IAdjustableChair;
            if (adjChair == null)
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, adjChairModel);
            }
            adjChair.SetHeight(height);
            return string.Format(EngineConstants.ChairHeightAdjustedSuccessMessage, adjChairModel);
        }

        private string CreateChair(string chairModel, string chairMaterial, decimal chairPrice, decimal chairHeight, int chairLegs, string chairType)
        {
            if (this.companies.ContainsKey(chairModel))
            {
                return string.Format(EngineConstants.FurnitureExistsErrorMessage, chairModel);
            }
            IChair chair;
            switch (chairType)
            {
                case EngineConstants.NormalChairType:
                    chair = this.furnitureFactory.CreateChair(chairModel, chairMaterial, chairPrice, chairHeight, chairLegs);
                    break;
                case EngineConstants.AdjustableChairType:
                    chair = this.furnitureFactory.CreateAdjustableChair(chairModel, chairMaterial, chairPrice, chairHeight, chairLegs);
                    break;
                case EngineConstants.ConvertibleChairType:
                    chair = this.furnitureFactory.CreateConvertibleChair(chairModel, chairMaterial, chairPrice, chairHeight, chairLegs);
                    break;
                default: return string.Format(EngineConstants.InvalidChairTypeErrorMessage, chairType);
            }
            this.furnitures.Add(chairModel, chair);
            return string.Format(EngineConstants.ChairCreatedSuccessMessage, chairModel);
        }

        private string CreateTable(string tableModel, string tableMaterial, decimal tablePrice, decimal tableHeight, decimal tableLenght, decimal tableWidth)
        {
            if (this.companies.ContainsKey(tableModel))
            {
                return string.Format(EngineConstants.FurnitureExistsErrorMessage, tableModel);
            }
            var table = this.furnitureFactory.CreateTable(tableModel, tableMaterial, tablePrice, tableHeight, tableLenght, tableWidth);
            this.furnitures.Add(tableModel, table);

            return string.Format(EngineConstants.TableCreatedSuccessMessage, tableModel);
        }

        private string ShowCatalog(string companyCatalog)
        {
            if (!this.companies.ContainsKey(companyCatalog))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyCatalog);
            }
            return this.companies[companyCatalog].Catalog();
        }

        private string FindFurniture(string companyName, string furnitureName)
        {
            if (!this.companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyName);
            }
            var company = this.companies[companyName];
            var furniture = company.Find(furnitureName);
            if (furniture == null)
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, furnitureName);
            }
            return furniture.ToString();

        }

        private string RemoveFurnitureFromCompany(string companyRemoveFrom, string furnituresToBeRemoved)
        {
            if (!this.companies.ContainsKey(companyRemoveFrom))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, companyRemoveFrom);
            }
            if (!this.companies.ContainsKey(furnituresToBeRemoved))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, furnituresToBeRemoved);
            }
            var company = this.companies[companyRemoveFrom];
            var furniture = this.furnitures[furnituresToBeRemoved];
            company.Remove(furniture);
            return string.Format(EngineConstants.FurnitureRemovedSuccessMessage, furnituresToBeRemoved, companyRemoveFrom);
        }

        private string AddFurnitureToCompany(string companyAddTo, string furnituresToBeAdded)
        {
            if (!this.companies.ContainsKey(companyAddTo))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyAddTo);
            }
            if (!this.furnitures.ContainsKey(furnituresToBeAdded))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage,furnituresToBeAdded);
            }
            var company = this.companies[companyAddTo];
            var furniture = this.furnitures[furnituresToBeAdded];
            company.Add(furniture);
            return string.Format(EngineConstants.FurnitureAddedSuccessMessage, furnituresToBeAdded, companyAddTo);

        }

        private string CreateCompany(string companyName, string companyRegistrationNumber)
        {
            if (this.companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyExistsErrorMessage, companyName);
            }
            var company = this.companyFactory.CreateCompany(companyName, companyRegistrationNumber);
            this.companies.Add(companyName, company);

            return string.Format(EngineConstants.CompanyCreatedSuccessMessage, companyName);
        }

        private ICollection<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();
            foreach (var currentLine in this.renderer.Input())
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);
            }
            return commands;
        }
    }
}
