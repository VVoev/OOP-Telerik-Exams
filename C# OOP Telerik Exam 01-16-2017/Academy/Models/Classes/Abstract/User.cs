using System;

namespace Academy.Models.Classes
{
    public abstract class User : IUser
    {
        //cons
        protected const int MinCharsInUsername = 3;
        protected const int MaxCharsInUsername = 16;
        protected const string ErrorUser = "User's username should be between 3 and 16 symbols long!";

        //field
        private string username;

        //ctor
        protected User(string username)
        {
            this.Username = username;
        }

        //property
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Username", "Username cannot me empty or null");
                }
                if (value.Length < MinCharsInUsername || value.Length > MaxCharsInUsername)
                {
                    throw new ArgumentOutOfRangeException(ErrorUser);
                }
                this.username = value;
            }
        }

    }
}
