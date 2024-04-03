using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class BankSubFamilyService : IBankSubFamilyService
    {
        private readonly IMapper _mapper;
        private readonly IBankSubFamilyRepository _bankSubFamilyRepository;
        private readonly ISelectService _selectService;
        private readonly IBankAgencyService _bankAgencyService;

        public BankSubFamilyService(
            IBankSubFamilyRepository bankSubFamilyRepository,
            ISelectService selectService,
            IBankAgencyService bankAgencyService,
            IMapper mapper
            )
        {
            _bankSubFamilyRepository = bankSubFamilyRepository;
            _selectService = selectService;
            _bankAgencyService = bankAgencyService;
            _mapper = mapper;
        }

        public BankSubFamily GetById(int idBankAgency)
        {
            return _bankSubFamilyRepository.GetById(idBankAgency);
        }

        public List<BankSubFamilyForList> GetByIdBankFamily(int idBankFamily, int idUser)
        {
            var bankSubFamilies = _bankSubFamilyRepository.GetByIdBankFamily(idBankFamily);
            var bankSubFamilyForList = _mapper.Map<List<BankSubFamilyForList>>(bankSubFamilies);
            foreach(var bankSubFamily in bankSubFamilyForList)
            {
                bankSubFamily.BankAgency = _bankAgencyService.GetByIdBankSubFamily(bankSubFamily.Id, idUser);
            }
            return bankSubFamilyForList;
        }

        public List<Select> GetSelectList(int idBankFamily)
        {
            //var selectList = _selectService.GetSelectList(enumSelectType);
            var bankAgencies = _bankSubFamilyRepository.GetByIdBankFamily(idBankFamily);
            var selectList = _mapper.Map<List<Select>>(bankAgencies).ToList(); //.AddRange(_mapper.Map<IEnumerable<Select>>(bankAgencies).ToList());

            return selectList;
        }

    }
}
