using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public class OperationMethodService : IOperationMethodService
    {
        private readonly IOperationMethodRepository _operationMethodRepository;
        private readonly IOperationMethodLexicalService _operationMethodLexicalService;
        private readonly ISelectService _selectService;
        private readonly IMapper _mapper;

        public OperationMethodService(IOperationMethodRepository operationMethodRepository,
                                      IOperationMethodLexicalService operationMethodLexicalService,
                                      ISelectService selectService,
                                      IMapper mapper)
        {
            _operationMethodRepository = operationMethodRepository;
            _operationMethodLexicalService = operationMethodLexicalService;
            _selectService = selectService;
            _mapper = mapper;
        }

        public List<Select> GetSelectList(EnumSelectType enumSelectType)
        {
            var selectList = _selectService.GetSelectList(enumSelectType);
            var operationMethods = _operationMethodRepository.GetAllByOrder();

            selectList.AddRange(_mapper.Map<IEnumerable<Select>>(operationMethods).ToList());

            return selectList;
        }

        public Select GetSelect(int idOperationMethod)
        {
            var operationMethod = _operationMethodRepository.GetById(idOperationMethod);

            return _mapper.Map<Select>(operationMethod);
        }



        public List<OperationMethod> GetAllForEdit()
        {
            return _operationMethodRepository.GetAllForEdit();
        }

        public List<OperationMethod> GetAllByOrder()
        {
            return _operationMethodRepository.GetAllByOrder();
        }

        public OperationMethod GetById(int idOperationMethod)
        {
            return _operationMethodRepository.GetById(idOperationMethod);
        }

        public OperationMethod GetOperationMethodByFileLabel(string operationLabel, EnumBankFamily enumBankFamily)
        {

            List<OperationMethodLexical> operationMethodLexicals = _operationMethodLexicalService.GetAllByOrder().Where(x => x.IdBankFamily == (int)enumBankFamily).ToList();
            //chercher le mot clef du lexique dans l'operation label
            foreach (var operationMethodLexical in operationMethodLexicals)
            {
                if (operationLabel.Contains(operationMethodLexical.Keyword))
                {
                    var operationMethod = _operationMethodRepository.GetById(operationMethodLexical.IdOperationMethod);
                    operationMethod.KeywordWork = operationMethodLexical.Keyword;
                    return operationMethod;
                }
            }

            return null; // GetById((int)EnumOperationMethod.Inconnu);
        }

        public List<OperationMethod> GetAll()
        {
            return _operationMethodRepository.GetAll();
        }

        public int Create(OperationMethod operationMethod)
        {
            return _operationMethodRepository.Create(operationMethod);
        }

        public void Update(OperationMethod operationMethod)
        {
            _operationMethodRepository.Update(operationMethod);
        }

        public void Delete(OperationMethod operationMethod)
        {
            _operationMethodRepository.Delete(operationMethod);
        }
    }
}
