using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Classes.Abstract
{
    public sealed class HomeworkResource : Resource, ILectureResouce
    {
        public HomeworkResource(string name, string url) : base(name, url)
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format($"   - Due date: <due date>"));
            return sb.ToString();
        }
    }
}
