using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMSys.Model
{
    public class T_OperationLog
    {
        public System.Guid Id { get; set; }
        public System.Guid OperatorId { get; set; }
        public System.DateTime MakeDate { get; set; }
        public System.String ActionDesc { get; set; }
    }

}
