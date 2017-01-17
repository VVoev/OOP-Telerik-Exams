using System;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System.Text;

namespace Academy.Models.Classes
{
    public class CourseResult : ICourseResult
    {
        //cons
        private const float MinExamPoints = 0;
        private const float MAxExamPoints = 1000;

        private const float MinCoursePoints = 0;
        private const float MAxcoursePoints = 125;

        private const int ExamExcellent = 65;
        private const int CourseExcelent = 75;



        private const string ErrorPoints = "Course result's exam points should be between {0} and {1}!";


        //fields
        private float examPoints;
        private float coursePoints;
        private Grade grade;

        public CourseResult(ICourse course,string examPts,string coursePoints)
        {
            this.Course = course;
            this.ExamPoints = float.Parse(examPts);
            this.CoursePoints = float.Parse(coursePoints);
        }


        public ICourse Course { get; protected set; }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            set
            {
                if(value<MinCoursePoints || value > MAxcoursePoints)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ErrorPoints, MinCoursePoints, MAxcoursePoints));
                }
                this.coursePoints = value;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            set
            {
                if(value<MinExamPoints || value > MAxExamPoints)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ErrorPoints,MinExamPoints,MAxExamPoints));
                }
                this.examPoints = value;
            }
        }

        public Grade Grade
        {
            get
            {
                if (this.ExamPoints >= ExamExcellent || this.CoursePoints >= CourseExcelent)
                {
                    return Grade.Excellent;
                }
                else if ((this.ExamPoints>=30 && this.ExamPoints < 60) || (this.coursePoints>=45&& this.CoursePoints < 75))
                {
                    return Grade.Passed;
                }
                else
                {
                    return Grade.Failed;
                }
            }
            set
            {
                this.grade = value;
            }
        }


        public override string ToString()
        {
            // * <Course name>: Points - <Course points>, Grade - <Grade>
            var sb = new StringBuilder();
            sb.AppendLine(string.Format($"  * {this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}"));
            return sb.ToString();
        }
    }
}
