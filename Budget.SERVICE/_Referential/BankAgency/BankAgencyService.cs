using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class BankAgencyService : IBankAgencyService
    {
        private readonly IMapper _mapper;
        private readonly IBankAgencyRepository _bankAgencyRepository;
        private readonly ISelectService _selectService;
        private readonly IUserAccountService _userAccountService;
        //private readonly IAccountStatementService _accountStatementService;

        public BankAgencyService(
            IBankAgencyRepository bankAgencyRepository,
            ISelectService selectService,
            IUserAccountService userAccountService,
            IMapper mapper
            //IAccountStatementService accountStatementService
            )
        {
            _bankAgencyRepository = bankAgencyRepository;
            _selectService = selectService;
            _userAccountService = userAccountService;
            _mapper = mapper;
            //_accountStatementService = accountStatementService;
        }


        public List<SelectGMapAddress> GetSelectList(int idBankSubFamily)
        {
            //var selectList = _selectService.GetSelectList(enumSelectType);
            var bankAgencies = _bankAgencyRepository.GetByIdBankSubFamily(idBankSubFamily);
            var selectList = _mapper.Map<List<SelectGMapAddress>>(bankAgencies).ToList();
            //selectList.AddRange(_mapper.Map<IEnumerable<Select>>(bankAgencies).ToList());

            return selectList;
        }

        public List<BankAgencyForList> GetByIdBankSubFamily(int idBankSubFamily, int idUser)
        {
            var bankAgencies = _bankAgencyRepository.GetByIdBankSubFamily(idBankSubFamily);
            var bankAgencyForList = _mapper.Map<List<BankAgencyForList>>(bankAgencies);

            foreach (var bankAgency in bankAgencyForList)
            {
                bankAgency.AccountList = _userAccountService.GetAccountsForList(idUser, bankAgency.Id);
            }
            return bankAgencyForList;
        }

    }

}
