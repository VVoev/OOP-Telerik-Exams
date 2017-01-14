using FurnitureFromScratch.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFromScratch.Engine
{
    class Command : ICommand
    {
        private const string NullNameErrorMsg = "Name cannot be null";
        private const string NullCollectionErrorMsg = "Collection of parameters cannot be null";

        private const char SplitComandSymbol = ' ';

        private string name;
        private IList<string> parameters;

        private Command(string input)
        {
            this.TranslateInput(input);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(NullNameErrorMsg);
                }
                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return new List<string>(this.parameters);
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(NullCollectionErrorMsg);
                }
                this.parameters = value;
            }
            
        }

        public static Command Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitComandSymbol);
            this.Name = input.Substring(0, indexOfFirstSeparator);
            this.Parameters = input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitComandSymbol }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
