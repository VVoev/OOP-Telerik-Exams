namespace Academy.Models.Classes
{
    using Academy.Models.Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Utils.Contracts;

    public class Student : User, IStudent
    {
        //const
        private const string InvalidTrack = "The provided track is not valid!";

        //ctor

        public Student(string username,string track)
            :base(username)
        {
            this.Track = GetTrackParser(track);
            this.CourseResults = new List<ICourseResult>();
        }

        private Track GetTrackParser(string track)
        {
            switch (track.ToLower())
            {
                case "frontend": return Track.Frontend;
                case "dev": return Track.Dev;
                case "none": return Track.None;
                default: throw new ArgumentException(InvalidTrack);
            }
        }

        //Property
        public IList<ICourseResult> CourseResults { get; set; }

        public Track Track { get; set; }

        public override string ToString()
        {
            var noResultMaybe = this.CourseResults.Count == 0 ? "  * User has no course results!" : $"{string.Join(" ",this.CourseResults)}";
            var sb = new StringBuilder();
            sb.AppendLine(string.Format($"* Student:"));
            sb.AppendLine(string.Format($" - Username: {this.Username}"));
            sb.AppendLine(string.Format($" - Track: {this.Track}"));
            sb.AppendLine(string.Format($" - Course results:"));
            sb.AppendLine(string.Format($"{noResultMaybe}"));
            return sb.ToString();

            #region ToStringInput
            //*Student:
            // -Username: < username >
            // -Track: < track >
            // -Course results:
            //*User has no course results!
            #endregion
        }

    }
}
