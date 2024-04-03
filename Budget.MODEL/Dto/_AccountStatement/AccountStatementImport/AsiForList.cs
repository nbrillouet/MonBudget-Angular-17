using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.MODEL.Dto
{
    public class AsiForList
    {
        public int CountBankAgency { get; set; }
        public int CountAsiFile { get; set; }
        public List<AsiListByBankAgency> AsiByBankAgencyList { get; set; }

        public AsiForList()
        {
            AsiByBankAgencyList = new List<AsiListByBankAgency>();
        }
    }
}
