using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Classes.Abstract
{
   public abstract class Resource
    {

        protected readonly string ErrorName = "Resource name should be between {0} and {1} symbols long!";
        protected readonly string ErrorUrl = "Resource url should be between 5 and 150 symbols long";
        protected const int MinValidName = 3;
        protected const int MaxValidName = 15;
        protected const int MinResourceUrl = 5;
        protected const int MaxResourceUrl = 150;

        protected Resource(string name,string url)
        {
            this.Name = name;
            this.Url = url;
        }

        string name;
        string url;


        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Validator.CheckForNullName(value, "Name");
                }
                if (value.Length < MinValidName || value.Length > MaxValidName)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ErrorName, MinValidName, MaxValidName));
                }
                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                Validator.CheckForNullName(value, "Url");
                if (value.Length < MinResourceUrl || value.Length > MaxResourceUrl)
                {
                    throw new ArgumentOutOfRangeException(ErrorUrl);
                }
                this.url = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format($"  * Resource:"));
            sb.AppendLine(string.Format($"   - Name: {this.Name}>"));
            sb.AppendLine(string.Format($"   - Url: {this.Url}"));
            sb.AppendLine(string.Format($"  - Type: {GetType().Name}"));
            return sb.ToString();
        }
    }
}
