using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IMapper _mapper;
        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly ISelectService _selectService;

        public AccountTypeService(
            IAccountTypeRepository accountTypeRepository,
            IMapper mapper,
            ISelectService selectService
            )
        {
            _accountTypeRepository = accountTypeRepository;
            _mapper = mapper;
            _selectService = selectService;

        }

        public AccountType GetById(int id)
        {
            return _accountTypeRepository.GetById(id);
        }

        public List<Select> GetSelectList(EnumSelectType enumSelectType)
        {
            var selectList = _selectService.GetSelectList(enumSelectType);
            var accountTypes = _accountTypeRepository.GetAllOrdering();
            selectList.AddRange(_mapper.Map<IEnumerable<Select>>(accountTypes).ToList());

            return selectList;
        }

        //public List<AccountType> GetAll()
        //{
        //    return _accountTypeRepository.GetAll();
        //}


        //public int Create(Account account)
        //{
        //    return _accountRepository.Create(account);
        //}

        //public void Update(Account account)
        //{
        //    _accountRepository.Update(account);
        //}

        //public void Delete(Account account)
        //{
        //    _accountRepository.Delete(account);
        //}


    }
}
