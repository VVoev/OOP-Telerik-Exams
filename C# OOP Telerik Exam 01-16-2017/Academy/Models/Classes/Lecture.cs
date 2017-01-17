namespace Academy.Models.Classes
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using System.Text;

    public class Lecture : ILecture
    {
        //cons
        private const int NameMinLen = 5;
        private const int NameMaxLen = 30;
        private readonly string ErrorLecture = "Lecture's name should be between 5 and 30 symbols long!";
        //fields
        private string name;

        //ctor
        public Lecture(string name,string date,ITrainer trainer)
        {
            this.Name = name;
            this.Date = Convert.ToDateTime(date);
            this.Trainer = trainer;
            this.Resouces = new List<ILectureResouce>();

        }


        //properties
        public DateTime Date { get;  set; }

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
                    throw new ArgumentNullException("Name", "Name cannot be null");
                }
                if(value.Length<NameMinLen || value.Length > NameMaxLen)
                {
                    throw new ArgumentOutOfRangeException(ErrorLecture);
                }
                this.name = value;
            }
        }

        public IList<ILectureResouce> Resouces { get;  set; }

        public ITrainer Trainer { get;  set; }

        public override string ToString()
        {
            var noResourcesMaybe = this.Resouces.Count == 0 ? "  * There are no resources in this lecture." : $"{string.Join(" ",this.Resouces)}";
            var sb = new StringBuilder();
            sb.AppendLine(string.Format($" * Lecture:"));
            sb.AppendLine(string.Format($"  - Name: {this.Name}"));
            sb.AppendLine(string.Format($"  - Date: {this.Date}"));
            sb.AppendLine(string.Format($"  - Trainer username: {this.Trainer.Username}"));
            sb.AppendLine(string.Format($"   - Resources:"));
            sb.AppendLine(string.Format($"   - {noResourcesMaybe}:"));
            return sb.ToString();
        }

        #region LectureInput
        //* Lecture:
        // - Name: <name>
        // - Date: <date>
        // - Trainer username: <username>
        // - Resources:
        //* There are no resources in this lecture.
        #endregion

    }
}
