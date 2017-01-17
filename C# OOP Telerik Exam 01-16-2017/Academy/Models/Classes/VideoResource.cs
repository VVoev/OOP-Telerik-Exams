using Academy.Models.Classes.Abstract;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Classes
{
    class VideoResource : Resource, ILectureResouce
    {
        public VideoResource(string name, string url) : base(name, url)
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format($" - Uploaded on: <uploaded date>"));
            return sb.ToString();
        }
    }
}
