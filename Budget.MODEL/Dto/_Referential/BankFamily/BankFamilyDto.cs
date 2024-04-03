using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.MODEL
{
    public class BankFamilyForList: SelectCodeUrl
    {
        public List<BankSubFamilyForList> BankSubFamily { get; set; }
    }
}
