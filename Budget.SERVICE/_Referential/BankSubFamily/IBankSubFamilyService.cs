using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System.Collections.Generic;

namespace Budget.SERVICE
{
    public interface IBankSubFamilyService
    {
        List<Select> GetSelectList(int idBankFamily);

        BankSubFamily GetById(int idBankAgency);
        List<BankSubFamilyForList> GetByIdBankFamily(int idBankFamily, int idUser);

    }

}
