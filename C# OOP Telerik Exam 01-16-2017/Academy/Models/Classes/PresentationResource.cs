using Academy.Models.Classes.Abstract;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Classes
{
    class PresentationResource : Resource, ILectureResouce
    {
        public PresentationResource(string name, string url)
            : base(name, url)
        {
        }
    }
}
