using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMSys.Model
{
    //别忘了public，跨程序集访问
    public class IdName
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
