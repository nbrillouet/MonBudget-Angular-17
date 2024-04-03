using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.SERVICE
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IAsSoldeService _asSoldeService;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;


        public UserAccountService(
            IAsSoldeService asSoldeService,
            IUserAccountRepository userAccountRepository,
            IMapper mapper
            )
        {
            _asSoldeService = asSoldeService;
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;

        }

        public UserAccount Get(int idUser, int idAccount)
        {
            return _userAccountRepository.Get(idUser, idAccount);
        }

        public List<User> GetUsers(string accountNumber)
        {
            return _userAccountRepository.GetUsers(accountNumber);
        }

        public List<Account> GetAccounts(int idUser)
        {
            return _userAccountRepository.GetAccounts(idUser);
        }

        public List<AccountForDetail> GetAccountsForDetail(int idUser)
        {
            var accounts = _userAccountRepository.GetAccounts(idUser);
            return GetAccountForDetail(idUser, accounts);
        }

        public List<AccountForDetail> GetAccountsForDetail(int idUser, int idBankAgency)
        {
            var accounts = _userAccountRepository.GetAccounts(idUser,idBankAgency);
            return GetAccountForDetail(idUser, accounts);
        }

        public List<AccountForList> GetAccountsForList(int idUser, int idBankAgency)
        {
            var accounts = _userAccountRepository.GetAccounts(idUser, idBankAgency);
            return GetAccountForList(idUser, accounts);
        }

        private List<AccountForDetail> GetAccountForDetail(int idUser, List<Account> accounts)
        {
            var accountsForDetail = _mapper.Map<List<AccountForDetail>>(accounts);

            foreach (var accountForDetail in accountsForDetail)
            {
                //accountForDetail.Solde = _mapper.Map<Solde>(_asSoldeService.GetSolde(idUser, accountForDetail.Id, DateTime.Now, DateTime.Now, true));
                accountForDetail.LinkedUsers = _mapper.Map<List<Select>>(_userAccountRepository.GetLinkedUsers(accountForDetail.Id, idUser));
                
            }

            return accountsForDetail;
        }

        private List<AccountForList> GetAccountForList(int idUser, List<Account> accounts)
        {
            var accountsForList = _mapper.Map<List<AccountForList>>(accounts);

            foreach (var accountForList in accountsForList)
            {
                accountForList.Solde = _mapper.Map<Solde>(_asSoldeService.GetSolde(idUser, accountForList.Id, DateTime.Now, DateTime.Now, true));
                accountForList.LinkedUsers = _mapper.Map<List<Select>>(_userAccountRepository.GetLinkedUsers(accountForList.Id, idUser));

            }

            return accountsForList;
        }

        public User GetUserOwner(string accountNumber)
        {
            return _userAccountRepository.GetUserOwner(accountNumber);
        }

        public List<BankAgencyWithAccountsDto> GetBankAgencies(int idUser)
        {
            var bankAgencies = _userAccountRepository.GetBankAgencies(idUser);

            var bankAgencyAccountsDtos = _mapper.Map<List<BankAgencyWithAccountsDto>>(bankAgencies);

            foreach (var bankAgency in bankAgencyAccountsDtos)
            {
                bankAgency.Accounts = _mapper.Map<List<AccountForDetail>>(_userAccountRepository.GetAccounts(idUser, bankAgency.Id));
                //Find linked users
                foreach (var account in bankAgency.Accounts)
                {
                    var users = _userAccountRepository.GetLinkedUsers(account.Id, idUser);
                    //var acc = bankAgencies.SelectMany(x => x.Accounts).Distinct().Where(u => u.Id == account.Id).FirstOrDefault();
                    //var idx = acc.UserAccounts.FindIndex(x => x.IdUser == idUser);
                    //acc.UserAccounts.RemoveAt(idx);
                    account.LinkedUsers = _mapper.Map<List<Select>>(users);
                }
            }
            return bankAgencyAccountsDtos;
        }

        public List<SelectGroupDto> GetBankSubFamilySelectGroup(int idUser)
        {
            //Recuperation des Agences + comptes associés
            var bankAgencies = _userAccountRepository.GetBankAgencies(idUser); // GetBankAgenciesByIdUserGroup(idUserGroup);

            //Recuperation des banksubfamily
            var bankSubFamilies = bankAgencies.Select(x => x.BankSubFamily).ToList();
            
            List<SelectGroupDto> results = new List<SelectGroupDto>();
            //scan des baksubFamilies et creation des selectGroupDto
            foreach (var bankSubFamily in bankSubFamilies)
            {
                SelectGroupDto SelectGroupDto = new SelectGroupDto
                {
                    Id = bankSubFamily.Id,
                    Label = bankSubFamily.Label,
                    Selects = _mapper.Map<List<Select>>(GetAccountsForList(idUser, bankAgencies.Where(x => x.IdBankSubFamily == bankSubFamily.Id).FirstOrDefault().Id))
                };
                results.Add(SelectGroupDto);
            }

            return results;
        }

        public List<SelectCodeUrl> GetBankFamily(int idUser)
        {
            var results = _userAccountRepository.GetBankFamily(idUser);
            var groupResult = results
                    .GroupBy(x => new { x.Id, x.Label, x.Code, x.Asset })
                    .Select(g => new SelectCodeUrl { Id = g.Key.Id, Label = g.Key.Label, Code = g.Key.Code, Url= $"\\assets\\{g.Key.Asset.Path}\\{g.Key.Asset.Label}.{g.Key.Asset.Extension}" })
                    .ToList();

            return groupResult; // _mapper.Map<List<SelectCodeUrl>>(groupResult);
        }

        public UserAccount Create(UserAccount userAccount)
        {
            return _userAccountRepository.Create(userAccount);
        }

        public void Update(UserAccount userAccount)
        {
            _userAccountRepository.Update(userAccount);
        }

        public void Delete(UserAccount userAccount)
        {
            _userAccountRepository.Delete(userAccount);
        }
    }
}
