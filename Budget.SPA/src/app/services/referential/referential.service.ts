import { Injectable, Injector } from '@angular/core';
import { OtfApiService } from 'app/state/referential/operation-type-family/otf-api.service';
import { OtApiService } from 'app/state/referential/operation-type/ot.api.service';
import { OApiService } from 'app/state/referential/operation/o.api.service';
import { BankAgencyService } from './bank-agency.service';
import { BankSubFamilyService } from './bank-sub-family.service';
import { OperationMethodService } from './operation-method.service';
import { OperationTransverseService } from './operation-tranverse.service';


//FACADE
@Injectable()
export class ReferentialService {
    //AccountTypeService
    // private _accountTypeService: AccountTypeService;
    // public get accountTypeService(): AccountTypeService {
    //   if(!this._accountTypeService){
    //     this._accountTypeService = this.injector.get(AccountTypeService);
    //   }
    //   return this._accountTypeService;
    // }

    // //AccountService
    // private _accountService: AccountService;
    // public get accountService(): AccountService {
    //   if(!this._accountService){
    //     this._accountService = this.injector.get(AccountService);
    //   }
    //   return this._accountService;
    // }

    //BankAgencyService
    private _bankAgencyService: BankAgencyService;
    public get bankAgencyService(): BankAgencyService {
        if(!this._bankAgencyService){
        this._bankAgencyService = this.injector.get(BankAgencyService);
        }
        return this._bankAgencyService;
    }

    //Operation
    private _operationService: OApiService;
    public get operationService(): OApiService {
        if(!this._operationService){
        this._operationService = this.injector.get(OApiService);
        }
        return this._operationService;
    }

    //OperationMethodService
    private _operationMethodService: OperationMethodService;
    public get operationMethodService(): OperationMethodService {
        if(!this._operationMethodService){
        this._operationMethodService = this.injector.get(OperationMethodService);
        }
        return this._operationMethodService;
    }

    //OperationTypeFamilyService
    private _otfService: OtfApiService;
    public get operationTypeFamilyService(): OtfApiService {
        if(!this._otfService){
        this._otfService = this.injector.get(OtfApiService);
        }
        return this._otfService;
    }

    //OperationTypeService
    private _otService: OtApiService;
    public get operationTypeService(): OtApiService {
        if(!this._otService){
        this._otService = this.injector.get(OtApiService);
        }
        return this._otService;
    }

    //OperationTransverseService
    private _operationTransverseService: OperationTransverseService;
    public get operationTransverseService(): OperationTransverseService {
        if(!this._operationTransverseService){
        this._operationTransverseService = this.injector.get(OperationTransverseService);
        }
        return this._operationTransverseService;
    }

    //BankSubFamilyService
    private _bankSubFamilyService: BankSubFamilyService;
    public get bankSubFamilyService(): BankSubFamilyService {
        if(!this._bankSubFamilyService){
        this._bankSubFamilyService = this.injector.get(BankSubFamilyService);
        }
        return this._bankSubFamilyService;
    }

    constructor(private injector: Injector) {  }


}
