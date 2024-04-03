using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.MODEL.Database
{
    public class OperationMethodOtf
    {
        public int Id { get; set; }
        public int IdOperationMethod { get; set; }
        public OperationMethod OperationMethod { get; set; }
        public int IdOperationTypeFamily { get; set; }
        public OperationTypeFamily OperationTypeFamily { get; set; }
    }

}
