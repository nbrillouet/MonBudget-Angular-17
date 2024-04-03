using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Mailjet.Client.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE
{
    public partial class OperationService
    {
        public OperationForDetail SaveDetail(OperationForDetail oForDetail)
        {
            Operation operation = CheckValues(oForDetail);
            operation = Save(operation);
            
            var oForDetailSaved = GetForDetail(operation.Id, oForDetail.User.Id);

            return oForDetailSaved;
        }

        private Operation CheckValues(OperationForDetail oForDetail)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Check des données      
            //IsExist(couvertureForData, forcableSave, businessExceptionMessages);
            //if (HelperDate.IsWeekEnd(couvertureForData.DateOperation))
            //{
            //    businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_ERR_046, true));
            //}

            //Check des données
            if (oForDetail == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_REF_OPE_ERR_001));
            }

            if (oForDetail.Label == null)
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_REF_OPE_ERR_002));
            }

            if (_operationRepository.IsDuplicate(oForDetail))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_REF_OPE_ERR_003));
            }

            if (businessExceptionMessages.Any())
            {
                throw new BusinessException(businessExceptionMessages);
            }

            //if (businessExceptionMessages.Any())
            //{
            //    throw new BusinessException(businessExceptionMessages);
            //}

            return _mapper.Map<Operation>(oForDetail);
        }

        public Operation Save(Operation operation)
        {
            operation = operation.Id == 0
               ? Create(operation)
               : Update(operation);

            return operation;
        }

        //private OperationForDetail Save(Operation operation, int idUser)
        //{
        //    operation = operation.Id == 0
        //       ? Create(operation)
        //       : Update(operation);

        //    OperationForDetail otfForDetail = GetForDetail(operation.Id, idUser);

        //    return otfForDetail;
        //}

        //public Select Create(Operation operation)
        //{
        //    Operation o = CheckValues(operation);

        //    return _mapper.Map<Select>(_operationRepository.Create(operation));
        //}
        private Operation Create(Operation operation)
        {
            operation = _operationRepository.Create(operation);
            return operation;
        }

        private Operation Update(Operation operation)
        {
            operation = _operationRepository.Update(operation);
            return operation;
        }

        public void Delete(Operation operation)
        {
            _operationRepository.Delete(operation);
        }

        public bool Delete(int idOperation)
        {
            var operation = _operationRepository.GetById(idOperation);

            _operationRepository.Delete(operation);

            return true;
        }

        public void Delete(List<int> idOList)
        {
            CheckForDeleteList(idOList);
            foreach (var idO in idOList)
            {
                Operation o = GetById(idO);
                if (o != null)
                {
                    Delete(o);
                }
            }

            //CheckForDeleteOperations(idOperationList);
            //foreach (var idOperation in idOperationList)
            //{
            //    Delete(idOperation);
            //}
        }

        //private Operation CheckValues(Operation operation)
        //{
        //    List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
        //    operation.Label = operation.Label.ToUpper();

        //    //Check des données
        //    if (operation == null)
        //    {
        //        businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_REF_OPE_ERR_001));
        //    }

        //    if (operation.Label == null)
        //    {
        //        businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_REF_OPE_ERR_002));
        //    }

        //    if (_operationRepository.IsDuplicate(operation))
        //    {
        //        businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_REF_OPE_ERR_003));
        //    }

        //    if (businessExceptionMessages.Any())
        //    {
        //        throw new BusinessException(businessExceptionMessages);
        //    }

        //    return operation;
        //}

        private void CheckForDeleteList(List<int> idOperationList)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            foreach (var idOperation in idOperationList)
            {
                var operation = _operationRepository.GetById(idOperation);
                businessExceptionMessages.AddRange(CheckForDelete(operation));
            }

            if (businessExceptionMessages.Count() > 0)
            {
                throw new BusinessException(businessExceptionMessages);
            }
        }

        private List<BusinessExceptionMessage> CheckForDelete(Operation operation)
        {
            List<BusinessExceptionMessage> businessExceptionMessages = new List<BusinessExceptionMessage>();
            //Recherche si operation est mandatory
            if (operation.IsMandatory)
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OPE_ERR_000));

            //Recherche si operation utilisée dans account statement file
            if (_accountStatementCheckReferentialService.AsifHasOperation(operation.Id))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OPE_ERR_001));
            }

            //Recherche si operation utilisé dans account statement
            if (_accountStatementCheckReferentialService.AsHasOperation(operation.Id))
            {
                businessExceptionMessages.Add(_businessExceptionMessageService.Get(EnumBusinessException.BUS_OPE_ERR_002));
            }

            return businessExceptionMessages;
            //if (businessExceptionMessages.Count > 0)
            //{
            //    throw new BusinessException(businessExceptionMessages);
            //}
        }

        
    }
}
