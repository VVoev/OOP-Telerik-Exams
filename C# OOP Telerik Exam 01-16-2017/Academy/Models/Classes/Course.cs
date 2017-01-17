namespace Academy.Models.Classes
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course : ICourse
    {
        //Name Const
        private const int NameMinLen = 3;
        private const int NameMaxLen = 45;

        //Error const
        private const string ErrorLectures = "The number of lectures per week must be between 1 and 7!";

        //Lectures Const
        private const int LecturesMinPerWeek = 1;
        private const int LecturesMaxPerWeek = 7;



        //fields
        private string name;
        private int lecturesPerWeek;

        //ctor 
        //(string name, string lecturesPerWeek, string startingDate)
        //Todo Possible Error check later if is not working
        public Course(string name,string lecturesPerWekk,string startingDate)
        {
            this.Lectures = new List<ILecture>();
            this.OnlineStudents = new List<IStudent>();
            this.OnsiteStudents = new List<IStudent>();

            this.Name = name;
            this.LecturesPerWeek = int.Parse(lecturesPerWekk);
            this.StartingDate = Convert.ToDateTime(startingDate);
        }

        //properties


        public DateTime EndingDate { get; set; }

        public IList<ILecture> Lectures { get; protected set; }

        public IList<IStudent> OnlineStudents { get; protected set; }

        public IList<IStudent> OnsiteStudents { get; protected set; }

        public DateTime StartingDate { get;  set; }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }

            set
            {
                // Course must have LecturesPerWeek that is an integer between 1 and 7. 
                //If that is not valid, the error message "The number of lectures per week must be between 1 and 7!"
                if (value<LecturesMinPerWeek || value > LecturesMaxPerWeek)
                {
                    throw new ArgumentOutOfRangeException(ErrorLectures);
                }
                this.lecturesPerWeek = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

             set
            {
                // Each Cours must have a valid Name that is a non-empty string
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be null or emptry");
                }
                //between 3 and 45 symbols long
                if (value.Length<=NameMinLen || value.Length >= NameMaxLen)
                {
                    throw new ArgumentNullException("Name", "The name of the course must be between 3 and 45 symbols!");
                }
                this.name = value;
            }
        }
       
        public override string ToString()
        {
            //Todo ToString in class Course
            var noLecturesMaybe = this.Lectures.Count == 0 ? "  * There are no lectures in this course!" : $"{string.Join(" ",this.Lectures)}";
            var sb = new StringBuilder();
            sb.AppendLine(string.Format($"* Course:"));
            sb.AppendLine(string.Format($" - Name: {this.Name}"));
            sb.AppendLine(string.Format($" - Lectures per week: {this.LecturesPerWeek}"));
            sb.AppendLine(string.Format($" - Starting date: {this.StartingDate.ToString(@"yyyy-MM-dd")}"));
            sb.AppendLine(string.Format($" - Ending date: {this.EndingDate}"));
            sb.AppendLine(string.Format($" - Onsite students: {this.OnsiteStudents.Count}"));
            sb.AppendLine(string.Format($" - Online students: {this.OnlineStudents.Count}"));
            sb.AppendLine(string.Format($" - Lectures:"));
            sb.AppendLine(string.Format($"{noLecturesMaybe}"));
            return sb.ToString();

            #region ToStringImplementation
            /*
            ToString
            * Course
             - Name: <name>
             - Lectures per week: <lecturesPerWeek>
             - Starting date: <startingDate>
             - Ending date: <endingDate>
             - Lectures:
              * There are no lectures in this course!
            
            */
            #endregion
        }


    }
}
