using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IBankAgencyService
    {
        List<SelectGMapAddress> GetSelectList(int idBankSubFamily);

        List<BankAgencyForList> GetByIdBankSubFamily(int idBankSubFamily, int idUser);

    }

}
