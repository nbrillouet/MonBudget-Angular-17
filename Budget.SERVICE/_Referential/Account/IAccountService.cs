using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IAccountService
    {
        PagedList<AccountForTable> GetForTable(FilterAccountTableSelected filterAccountTableSelected);
        List<BankAgencyWithAccountsDto> GetForList(int idUser);
        List<BankFamilyForList> GetByBankFamily(int idUser);
        AccountForDetail GetForDetail(int? idAccount);
        Account GetFullById(int idAccount);
        Account GetByNumber(string number);
        AccountForDetail GetForDetailByNumber(string number);
        Select GetSelectById(int idAccount);
        bool AskAccountOwner(AccountForDetail accountForDetail);
        AccountOwnerDto ResponseOfAccountOwner(string responseEncrypt);
        AccountForDetail Save(AccountForDetail accountForDetail);

        //void Update(AccountForDetailDto accountForDetailDto);
        //Account Create(int idUser, AccountForDetailDto accountForDetailDto);
        //void Update(Account account);
        //void Delete(Account account);
        //void Delete(int idUser, int idAccount);
        //List<Account> GetAll();
        //List<Account> GetByIdBankAgency(int idBankAgency);
        //Account GetById(int idAccount);
        //AccountForDetailDto GetForDetailById(int id);
    }
}
