using AutoMapper;
using Budget.DATA.Repositories;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Budget.SERVICE
{
    public class PlanPosteReferenceService : IPlanPosteReferenceService
    {
        private readonly IMapper _mapper;
        private readonly IPosteService _posteService;
        private readonly ReferentialService _referentialService;

        private readonly IPlanPosteReferenceRepository _planPosteReferenceRepository;


        public PlanPosteReferenceService(
            IMapper mapper,
            IPosteService posteService,
            IPlanPosteReferenceRepository planPosteReferenceRepository,
            ReferentialService referentialService
        )
        {
            _mapper = mapper;
            _planPosteReferenceRepository = planPosteReferenceRepository;
            _referentialService = referentialService;
            _posteService = posteService;
        }

       
        //public ComboMultiple<SelectGroupDto> GetListForComboByIdPlanPoste(int idUserGroup, int idPlanPoste, int idReferenceTable, int idPoste)
        //{
        //    ComboMultiple<SelectGroupDto> result = new ComboMultiple<SelectGroupDto>();

        //    List<PlanPosteReference> planPosteReferences = Get(idPlanPoste, idReferenceTable);
        //    List<int> idList = planPosteReferences.Select(x => x.IdReference ).ToList();
        //    var poste = _posteService.GetById(idPoste);

        //    switch (idReferenceTable)
        //    {
        //        case 1: // OPERATION_TYPE_FAMILY
        //            result.List = _referentialService.OperationTypeFamilyService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
        //            result.ListSelected = _referentialService.OperationTypeFamilyService.GetSelectListByIdList(idList);
        //            break;
        //        case 2: // OPERATION_TYPE
        //            result.List = _referentialService.OperationTypeService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
        //            result.ListSelected = _referentialService.OperationTypeService.GetSelectListByIdList(idList);
        //            break;
        //        case 3: // OPERATION
        //            result.List = _referentialService.OperationService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
        //            result.ListSelected = _referentialService.OperationService.GetSelectListByIdList(idList);
        //            break;
        //    }

        //    return result;
        //}

        public List<SelectGroupDto> GetListForSelectGroup(int idUserGroup, int idReferenceTable, int idPoste)
        {
            List<SelectGroupDto> result = new List<SelectGroupDto>();

            var poste = _posteService.GetById(idPoste);
            switch (idReferenceTable)
            {
                case 1: // OPERATION_TYPE_FAMILY
                    result = _referentialService.OperationTypeFamilyService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
                    break;
                case 2: // OPERATION_TYPE
                    result = _referentialService.OperationTypeService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
                    break;
                case 3: // OPERATION
                    result = _referentialService.OperationService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
                    break;
            }

            return result;
        }

        public List<Select> GetListForSelectList(int idPlanPoste, int idReferenceTable)
        {
            List<Select> result = new List<Select>();

            List<PlanPosteReference> planPosteReferences = Get(idPlanPoste, idReferenceTable);
            List<int> idList = planPosteReferences.Select(x => x.IdReference).ToList();
            //var poste = _posteService.GetById(idPoste);

            switch (idReferenceTable)
            {
                case 1: // OPERATION_TYPE_FAMILY
                    //result.List = _referentialService.OperationTypeFamilyService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
                    result = _referentialService.OperationTypeFamilyService.GetSelectListByIdList(idList);
                    break;
                case 2: // OPERATION_TYPE
                    //result.List = _referentialService.OperationTypeService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
                    result = _referentialService.OperationTypeService.GetSelectListByIdList(idList);
                    break;
                case 3: // OPERATION
                    //result.List = _referentialService.OperationService.GetSelectGroupListByMovement(idUserGroup, (EnumMovement)poste.IdMovement);
                    result = _referentialService.OperationService.GetSelectListByIdList(idList);
                    break;
            }

            return result;
        }

        public List<PlanPosteReference> GetByIdPlanPoste(int idPlanPoste)
        {
            return _planPosteReferenceRepository.GetByIdPlanPoste(idPlanPoste);
        }

        public List<PlanPosteReference> Get(int idPlanPoste,int idReferenceTable)
        {
            return _planPosteReferenceRepository.Get(idPlanPoste, idReferenceTable);
        }

        public void DeleteByIdPlanPoste(int idPlanPoste)
        {
            _planPosteReferenceRepository.DeleteByIdPlanPoste(idPlanPoste);
        }

        public void Create(PlanPosteReference planPosteReference)
        {
            _planPosteReferenceRepository.Create(planPosteReference);
        }

        public List<Select> Save(int idPlanPoste, int idReferenceTable, List<Select> planPosteReferenceList)
        {
            //Recherche d'enregistrement et suppression si presence
            List<PlanPosteReference> pprList = GetByIdPlanPoste(idPlanPoste);
            if(pprList.Count>0)
            {
                DeleteByIdPlanPoste(idPlanPoste);
            }

            //create
            foreach(var select in planPosteReferenceList)
            {
                Create(new PlanPosteReference { Id = 0, IdReferenceTable = idReferenceTable, IdPlanPoste = idPlanPoste, IdReference = select.Id });
            }

            return GetListForSelectList(idPlanPoste, idReferenceTable);
        }
    }
}
