using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public class ReferentialService
    {
        public IBankFileDefinitionService BankFileDefinitionService { get; }
        public IOperationMethodService OperationMethodService { get; }
        public IOperationTransverseService OperationTransverseService {get;}
        public IAccountService AccountService { get; }
        public IOperationService OperationService { get; }
        public IOperationDetailService OperationDetailService { get; }
        public IOperationTypeService OperationTypeService { get; }
        public IOperationTypeFamilyService OperationTypeFamilyService { get; }
        public IMovementService MovementService { get; }
        public IAssetService AssetService { get; }
        public IUserAccountService UserAccountService { get; }
        public IUserPreferenceService UserPreferenceService { get; }
        public IBankAgencyService BankAgencyService { get; }
        public IBankFamilyService BankFamilyService { get; }
        public IAccountTypeService AccountTypeService { get; }
        public IBankSubFamilyService BankSubFamilyService { get; }
        public IOperationPlaceService OperationPlaceService { get; }
        public IOperationMethodOtfService OperationMethodOtfService { get; }

        public ReferentialService(
            IBankFileDefinitionService bankFileDefinitionService,
            IOperationMethodService operationMethodService,
            IOperationDetailService operationDetailService,
            IOperationTypeService operationTypeService,
            IOperationTransverseService operationTransverseService,
            IAccountService accountService,
            IOperationService operationService,
            IOperationTypeFamilyService operationTypeFamilyService,
            IMovementService movementService,
            IAssetService assetService,
            IUserAccountService userAccountService,
            IUserPreferenceService userPreferenceService,
            IBankAgencyService bankAgencyService,
            IBankFamilyService bankFamilyService,
            IAccountTypeService accountTypeService,
            IBankSubFamilyService bankSubFamilyService,
            IOperationPlaceService operationPlaceService,
            IOperationMethodOtfService operationMethodOtfService
            )
        {
            BankFileDefinitionService = bankFileDefinitionService;
            OperationMethodService = operationMethodService;
            OperationDetailService = operationDetailService;
            OperationTypeService = operationTypeService;
            OperationTransverseService = operationTransverseService;
            AccountService = accountService;
            OperationService = operationService;
            OperationTypeFamilyService = operationTypeFamilyService;
            MovementService = movementService;
            AssetService = assetService;
            UserAccountService = userAccountService;
            UserPreferenceService = userPreferenceService;
            OperationPlaceService = operationPlaceService;
            BankAgencyService = bankAgencyService;
            BankFamilyService = bankFamilyService;
            AccountTypeService = accountTypeService;
            BankSubFamilyService = bankSubFamilyService;
            OperationMethodOtfService = operationMethodOtfService;
        }

    }
}
