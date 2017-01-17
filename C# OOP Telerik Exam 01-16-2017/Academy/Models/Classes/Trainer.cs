namespace Academy.Models.Classes
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Trainer : ITrainer
    {
        //constants
        private const int MinCharsInTrainerUsername = 3;
        private const int MaxCharsInTrainerUsername = 16;
        private const string ErrorMsg = "User's username should be between 3 and 16 symbols long!";

        //fields
        private string username;
        private IList<string> technologies;

        //ctor
        //(string username, string technologies)
        public Trainer(string username,string technologies)
        {
            //Todo Check Trainer maybe it is totally wrong!
            this.Username = username;
            this.technologies = new List<string>();
            Parser(technologies);
        }

        private void Parser(string technologies)
        {
            var allTech = technologies.Split(',');
            foreach (var item in allTech)
            {
                this.technologies.Add(item);
            }
        }



        //properties
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                //null check
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Username", "Username cannot me empty or null");
                }
                //out of range  "User's username should be between 3 and 16 symbols long!"
                if (value.Length<MinCharsInTrainerUsername || value.Length > MaxCharsInTrainerUsername)
                {
                    throw new ArgumentOutOfRangeException(ErrorMsg);
                }
                this.username = value;
            }
        }

        public IList<string> Technologies
        {
            get
            {
                return new List<string>(this.technologies);
            }
            set
            {
                this.technologies = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format($"* Trainer:"));
            sb.AppendLine(string.Format($" - Username: {this.Username}"));
            sb.AppendFormat(string.Format($" - Technologies: {string.Join("; ", this.Technologies)}"));
            return sb.ToString();
        }

        #region Trainger ToString implementation       
        //* Trainer:
        //- Username: <username>
        //- Technologies: <technology>; <technology>; <technology>;
        #endregion

    }
}
