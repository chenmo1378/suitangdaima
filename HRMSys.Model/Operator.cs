using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMSys.Model
{
    public class Operator
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public string RealName { get; set; }
        public bool IsLocked { get; set; }
    }
}
