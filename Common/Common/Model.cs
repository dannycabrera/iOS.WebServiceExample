using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iOS.WebServiceExample.Common.Model
{
    public class Certificate
    {
        public string Name { get; set; }
    }

    public enum ClassType
    {
        iOS,
        Android,
        XPlat
    }

    public class Class
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ClassType Type { get; set; }
    }
}
