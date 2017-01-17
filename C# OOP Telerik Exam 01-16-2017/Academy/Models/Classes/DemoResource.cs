using System;
using Academy.Models.Contracts;
using Academy.Models.Classes.Abstract;
using System.Text;

namespace Academy.Models.Classes
{
    public class DemoResource : Resource,ILectureResouce
    {
        public DemoResource(string name,string url)
            :base(name,url)
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            //sb.AppendLine(string.Format($"  * Resource:"));
            return sb.ToString();
        }

    }
}
