using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class BankFamilyService : IBankFamilyService
    {
        private readonly IMapper _mapper;
        private readonly IBankFamilyRepository _bankFamilyRepository;
        private readonly ISelectService _selectService;

        public BankFamilyService(
            IBankFamilyRepository bankFamilyRepository,
            ISelectService selectService,
            IMapper mapper
            )
        {
            _bankFamilyRepository = bankFamilyRepository;
            _selectService = selectService;
            _mapper = mapper;
        }


        public List<Select> GetSelectList(EnumSelectType enumSelectType)
        {
            var selectList = _selectService.GetSelectList(enumSelectType);
            var bankFamilies = _bankFamilyRepository.GetAllOrdering();
            selectList.AddRange(_mapper.Map<IEnumerable<Select>>(bankFamilies).ToList());

            return selectList;
        }

        public List<SelectCode> GetSelectCodeList(EnumSelectType enumSelectType)
        {
            var selectCodeList = _selectService.GetSelectCodeList(enumSelectType);
            var bankFamilies = _bankFamilyRepository.GetAllOrdering();
            selectCodeList.AddRange(_mapper.Map<List<SelectCode>>(bankFamilies).ToList());

            return selectCodeList;
        }

        public List<SelectCodeUrl> GetSelectCodeUrlList(EnumSelectType enumSelectType)
        {
            //var selectCodeUrlList = _selectService.GetSelectCodeList(enumSelectType);
            var bankFamilies = _bankFamilyRepository.GetAllOrdering();
            var selectCodeUrlList = _mapper.Map<List<SelectCodeUrl>>(bankFamilies).ToList();

            //selectCodeUrlList.AddRange(_mapper.Map<List<SelectCodeUrl>>(bankFamilies).ToList());

            return selectCodeUrlList;
        }

        public SelectCode GetSelectCode(string code)
        {
            var bankFamily = _bankFamilyRepository.GetByCode(code);
            return _mapper.Map<SelectCode>(bankFamily);

            //return selectCodeList;
        }

    }

}
