using AutoMapper;
using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget.SERVICE
{
    public class FilterDetailService : IFilterDetailService
    {
        private readonly IMapper _mapper;
        private readonly ReferentialService _referentialService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IReferenceTableService _referenceTableService;
        private readonly IPlanPosteService _planPosteService;
        private readonly IPlanPosteReferenceService _planPosteReferenceService;

        public FilterDetailService(
            IMapper mapper,
            ReferentialService referentialService,
            IReferenceTableService referenceTableService,
            IPlanPosteService planPosteService,
            IPlanPosteReferenceService planPosteReferenceService,
            IHostingEnvironment hostingEnvironment
        )
        {
            _mapper = mapper;
            _referentialService = referentialService;
            _referenceTableService = referenceTableService;
            _planPosteService = planPosteService;
            _hostingEnvironment = hostingEnvironment;
            _planPosteReferenceService = planPosteReferenceService;
        }


        public FilterOperationForDetail GetFilterForOperation(OperationForDetail operationForData)
        {
            FilterOperationForDetail FilterOperationForDetail = new FilterOperationForDetail()
            {
                OperationMethod = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Empty),
                OperationType = _referentialService.OperationTypeService.GetSelectGroup(operationForData.User.IdUserGroup)
            };

            return FilterOperationForDetail;
        }

        public FilterOtForDetail GetFilterForOt(OtForDetail otForDetail)
        {
            FilterOtForDetail filterOtForDetail = new FilterOtForDetail()
            {
                OperationTypeFamily = _referentialService.OperationTypeFamilyService.GetSelectGroup(otForDetail.User.IdUserGroup)
            };

            return filterOtForDetail;
        }

        public FilterOtfForDetail GetFilterForOtf(OtfForDetail otfForDetail)
        {
            FilterOtfForDetail filterOtfForDetail = new FilterOtfForDetail()
            {
                Asset = _referentialService.AssetService.GetSelectList(EnumAssetFamily.OTF), // GetOtfLogoList(),
                Movement = _referentialService.MovementService.GetSelectList(EnumSelectType.Empty)
            };

            return filterOtfForDetail;
        }

        public FilterAccountForDetail GetFilterForAccount(AccountForDetail accountForDetail)
        {
            FilterAccountForDetail filterAccountForDetail = new FilterAccountForDetail()
            {
                BankFamily = _referentialService.BankFamilyService.GetSelectCodeUrlList(EnumSelectType.Empty),
                BankSubFamily = accountForDetail.BankAgency != null
                    ? _referentialService.BankSubFamilyService.GetSelectList(accountForDetail.BankFamily.Id)
                    : null,
                BankAgency = accountForDetail.BankAgency != null
                    ? _referentialService.BankAgencyService.GetSelectList(accountForDetail.BankSubFamily.Id)
                    : null,
                AccountType = _referentialService.AccountTypeService.GetSelectList(EnumSelectType.Empty)
            };

            return filterAccountForDetail;
        }

        public FilterPlanPosteForDetail GetFilterForPlanPoste(int idUserGroup, PlanPosteForDetail planPosteForDetail)
        {
            FilterPlanPosteForDetail FilterPlanPosteForDetail = new FilterPlanPosteForDetail()
            {
                ReferenceTable = _mapper.Map<List<Select>>(_referenceTableService.GetAll()),
                PlanPosteReference = _planPosteReferenceService.GetListForSelectGroup(idUserGroup, planPosteForDetail.ReferenceTable.Id, planPosteForDetail.Poste.Id)
            };
            
            return FilterPlanPosteForDetail;
        }

        public FilterAsForDetail GetFilterForAs(AsForDetail asForDetail)
        {
            //FilterAsForDetail filterAsForDetail = new FilterAsForDetail()
            //{
            //    OperationMethod = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Inconnu),
            //    OperationTypeFamily = null, //_referentialService.OperationTypeFamilyService.GetSelectList(asForDetail.User.IdUserGroup, (EnumMovement)asForDetail.IdMovement, EnumSelectType.Inconnu),
            //    OperationType = _referentialService.OperationTypeService.GetSelectList(asForDetail.OperationTypeFamily.Id, EnumSelectType.Empty),
            //    Operation = _referentialService.OperationService.GetSelectList(asForDetail.Asi.User.IdUserGroup, asForDetail.OperationMethod.Id, asForDetail.OperationType.Id, EnumSelectType.Inconnu),
            //    OperationTransverse = _referentialService.OperationTransverseService.GetSelectList(asForDetail.Asi.User.Id, EnumSelectType.Empty),
            //    //operationPlace: inconnu nest pas mis dans la liste des selctionnables
            //    OperationPlace = _referentialService.OperationPlaceService.GetSelectListRestrict()
            //};
            FilterAsForDetail filterAsForDetail = new FilterAsForDetail()
            {
                OperationMethod = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Empty),
                OperationTypeFamily = asForDetail.OperationMethod != null
                    ? _referentialService.OperationMethodOtfService.GetOtfSelect(asForDetail.OperationMethod.Id)
                    : null,
                OperationType = asForDetail.OperationTypeFamily != null
                    ? _referentialService.OperationTypeService.GetSelectList(asForDetail.Account.Id, asForDetail.IdMovement, asForDetail.OperationTypeFamily.Id, EnumSelectType.Empty)
                    : null,
                Operation = asForDetail.OperationMethod != null && asForDetail.OperationType != null
                    ? _referentialService.OperationService.GetSelectList(asForDetail.Asi.User.IdUserGroup, asForDetail.OperationMethod.Id, asForDetail.OperationType.Id, EnumSelectType.Empty)
                    : null,
                OperationTransverse = _referentialService.OperationTransverseService.GetSelectList(asForDetail.Asi.User.Id, EnumSelectType.Empty),
                OperationPlace = _referentialService.OperationPlaceService.GetSelectListRestrict()
            };

            return filterAsForDetail;
        }

        //TODO merge with GetFilterForAs
        public FilterAsifForDetail GetFilterForAsif(AsifForDetail asifForDetail)
        {
            return _mapper.Map<FilterAsifForDetail>(GetFilterForAs(asifForDetail));
            //FilterAsifForDetail filterAsForDetail = new FilterAsifForDetail()
            //{
            //    OperationMethod = _referentialService.OperationMethodService.GetSelectList(EnumSelectType.Empty),
            //    OperationTypeFamily = asifForDetail.OperationMethod != null
            //        ? _referentialService.OperationMethodOtfService.GetOtfSelect(asifForDetail.OperationMethod.Id)
            //        : null,
            //    OperationType = asifForDetail.OperationTypeFamily!=null
            //        ? _referentialService.OperationTypeService.GetSelectList(asifForDetail.OperationTypeFamily.Id, EnumSelectType.Empty)
            //        : null,
            //    Operation = asifForDetail.OperationMethod !=null && asifForDetail.OperationType != null
            //        ? _referentialService.OperationService.GetSelectList(asifForDetail.Asi.User.IdUserGroup, asifForDetail.OperationMethod.Id, asifForDetail.OperationType.Id, EnumSelectType.Empty)
            //        : null,
            //    OperationTransverse = _referentialService.OperationTransverseService.GetSelectList(asifForDetail.Asi.User.Id, EnumSelectType.Empty),
            //    OperationPlace = _referentialService.OperationPlaceService.GetSelectListRestrict()
            //};

            //return filterAsForDetail;
        }
                

        private List<Select> GetOtfLogoList()
        {
            List<Select> logoList = new List<Select>();
            var basePath = _hostingEnvironment.WebRootPath;
            var files = Directory.EnumerateFiles($"{basePath}/assets/images/Otf");
            int i = 0;
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName.Contains("_32"))
                {
                    var logo = new Select
                    {
                        Id = i,
                        Label = fileName.Replace("_32.png", string.Empty)
                    };
                    logoList.Add(logo);
                    i++;
                }
            }
            return logoList;
        }

    }
}
