import { Injectable } from '@angular/core';
import { Select, Store } from '@ngxs/store';
import { FilterAccountDetail } from 'app/model/filters/account.filter';
import { GMapAddressFilterData } from 'app/model/g-map.model.';
import { AccountForDetail } from 'app/model/referential/account.model';
import { AccountDetailFilterChangeBankAgency, AccountDetailFilterChangeBankSubFamily, ClearAccountDetailFilter } from 'app/state/referential/account/account-detail/account-detail-filter/account-detail-filter.action';
import { AccountDetailFilterState } from 'app/state/referential/account/account-detail/account-detail-filter/account-detail-filter.state';
import { ClearAccountDetail, LoadAccountDetail, SaveAccountDetail } from 'app/state/referential/account/account-detail/account-detail.action';
import { AccountDetailState } from 'app/state/referential/account/account-detail/account-detail.state';
import { Observable, Subject, takeUntil } from 'rxjs';
import { DataInfo, DetailFormInfo, FilterForDetail, Select as SelectModel, SelectCodeUrl } from '@corporate/model';
import { CorpDataForm } from '@corporate/data';
import { AccountForDetailFormBuilderOptions } from './account-detail.form-builder-option';

@Injectable({ providedIn: 'root' })
export class AccountDetailService extends CorpDataForm<AccountForDetail, AccountForDetailFormBuilderOptions>
{
    @Select(AccountDetailState.get) stateDetail$: Observable<DetailFormInfo<AccountForDetail, FilterForDetail>>;
    @Select(AccountDetailFilterState.get) stateFilter$: Observable<DataInfo<FilterAccountDetail>>;

    currentId: number = null;
    // accountForm: CorpForm<AccountForDetail, AccountForDetailFormBuilderOptions> = new CorpForm<AccountForDetail,AccountForDetailFormBuilderOptions>(AccountForDetail, AccountForDetailFormBuilderOptions);

    saveInProgress: boolean = false;
    formIsLoaded: boolean = false;

    // _unsubscribeAll: Subject<any> = new Subject<any>();
    /**
     * Constructor
     */
    constructor(
        private _store: Store
    )
    {
        super(AccountForDetail, AccountForDetailFormBuilderOptions);

        // this._unsubscribeAll = new Subject<any>();
        this.stateDetail$
            // .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((x)=>{

                if(x.loader['datas']?.loaded) {
                    this.formIsLoaded = true;
                    if(x.model.hasOwnProperty('id')) {
                        if (this.currentId !== x.model.id) {
                            this.currentId = x.model.id;
                            this.initTrigger();
                        }
                    }
                }

                if(x.loader['datas-save']?.loading) {
                    this.saveInProgress=true;
                    this.form.disableForm(true);
                }

                if(x.loader['datas-save']?.loaded) {
                    this.saveInProgress = false;
                    this.form.disableForm(false);
                }
        });

        // this.stateFilter$
        //     // .pipe(takeUntil(this._unsubscribeAll))
        //     .subscribe((x)=>{

        // });
    }

    destroyForm(): void {
        // // Unsubscribe from all subscriptions
        // this._unsubscribeAll.next(void 0);
        // this._unsubscribeAll.complete();

        this.formIsLoaded = false;
        this.initForm(AccountForDetail, AccountForDetailFormBuilderOptions);
        // this.accountForm = new CorpForm<AccountForDetail,AccountForDetailFormBuilderOptions>(AccountForDetail, AccountForDetailFormBuilderOptions);

        this._store.dispatch(new ClearAccountDetail());
        this._store.dispatch(new ClearAccountDetailFilter());
    }

    saveDetail(): void {
        this._store.dispatch(new SaveAccountDetail({ accountDetail: this.form.formGroup.getRawValue() }));
    }

    loadAccountDetail(filterForDetail: FilterForDetail): void {
        this._store.dispatch(new LoadAccountDetail(filterForDetail));
    }

    getGMapAddressFilterData(): GMapAddressFilterData {
        const gmapAddress = this.form.getValue(x=>x.bankAgency.gMapAddress);
        // const operationDetail = this._asifDetailService.asifForm.getValue(x=>x.operationDetail) as OperationDetail;
        const gMapAddressFilterData = {datas: gmapAddress, filter: null } as GMapAddressFilterData;
        return gMapAddressFilterData;
    }


    initTrigger(): void {
        this.initFormTriggerBankFamily();
        this.initFormTriggerBankSubFamily();
        this.initFormTriggerBankAgency();
    }

    private initFormTriggerBankFamily(): void {
        this.form.getControl(x=>x.bankFamily).valueChanges.subscribe((value) => {
            if(this.form.formGroup.dirty) {
                this.updateBankFamily(value);
            }
        });
    }

    private initFormTriggerBankSubFamily(): void {
        this.form.getControl(x=>x.bankSubFamily).valueChanges.subscribe((value) => {
            if(this.form.formGroup.dirty) {
                this.updateBankSubFamily(value);
            }
        });
    }

    private initFormTriggerBankAgency(): void {
        this.form.getControl(x=>x.bankAgency).valueChanges.subscribe((value) => {
            if(this.form.formGroup.dirty) {
                // this.updateBankAgency(value);
            }
        });
    }

    // private initFormTriggerOperation(): void {
    //     this.asifForm.getControl(x=>x.operation).valueChanges.subscribe((value) => {
    //         if(this.asifForm.formGroup.dirty) {
    //             this.updateOperation(value);
    //         }
    //     });
    // }

    //===========================================================
    //===   BANK FAMILY
    //===========================================================
    private updateBankFamily(bankFamily: SelectCodeUrl): void {
        this.triggerBankFamily(bankFamily);
    }

    private triggerBankFamily(bankFamily: SelectCodeUrl): void {
        //modification bank family implique:
        //-->change liste bankSubFamily
        this.changeBankSubFamilyList(bankFamily);
    }

    //===========================================================
    //===   BANK SUB FAMILY
    //===========================================================
    private updateBankSubFamily(bankSubFamily: SelectModel): void {
        this.triggerBankSubFamily(bankSubFamily);
    }

    private triggerBankSubFamily(bankSubFamily: SelectModel): void {
        //modification du type operation famille implique:
        //-->change liste BankAgency
        this.changeBankAgencyList(bankSubFamily);
    }

    // trigger: tr-BankFamily
    private changeBankSubFamilyList(bankFamily: SelectCodeUrl): void {
        this._store.dispatch(new AccountDetailFilterChangeBankSubFamily( { bankFamily:  bankFamily } ));
    }

    // private changeOperationTypeFamily(operationTypeFamily: SelectCode): void {
    //     this._store.dispatch(new AsifDetailChangeOtf( { otf: operationTypeFamily } ));
    // }

    //===========================================================
    //===   BANK AGENCY
    //===========================================================
    // private updateBankAgency(bankAgency: SelectGMapAddress): void {
    //     this.triggerBankAgency(operationType);
    // }

    // private triggerOperationType(operationType: SelectModel): void {
    //     //modification du type operation implique:
    //     //-->change liste operation
    //     this.changeOperationList(x=>x.operationType, operationType);
    // }

    // trigger: tr-bankSubFamily
    private changeBankAgencyList(bankSubFamily: SelectModel): void {
        this._store.dispatch(new AccountDetailFilterChangeBankAgency({ bankSubFamily: bankSubFamily }));
    }

    // //===========================================================
    // //===   OPERATION
    // //===========================================================
    // private updateOperation(operation: SelectModel): void {
    //     this.triggerOperation(operation);
    // }

    // private triggerOperation(operation: SelectModel): void {
    //     //modification operation implique:
    //     //-->change operationDetail / operation
    //     // this.asifForm.setValue(x=>x.operationDetail.operation, operation);

    // }

    // // trigger: tr-operationType tr-operationMethod
    // private changeOperationList(nameFunction: ((obj: ChangeOperationListParameter) => any) | (new(...params: any[]) => ChangeOperationListParameter), value: string | Date | boolean | number | SelectCode | SelectModel): void {
    //     const param = LambdaExpression.getParameters<ChangeOperationListParameter>(nameFunction.toString(), new ChangeOperationListParameter(this.asifForm), value);
    //     this._store.dispatch(new AsifDetailFilterChangeOperation(param));
    // }

    // // private changeOperationList(operationType: SelectModel): void {
    // //     this._store.dispatch(new AsifDetailFilterChangeOperation({operation: this.asifForm.getValue(x=>x.operation), operationMethod: this.asifForm.getValue(x=>x.operationMethod), ot: operationType }));
    // // }

    // //===========================================================
    // //===   OPERATION DETAIL
    // //===========================================================
    // //===   OPERATION PLACE
    // // trigger: tr-operationMethod
    // private changeOperationDetailOperationPlace(operationMethod: SelectModel): void {
    //     this._store.dispatch(new AsifDetailChangeOperationDetailOperationPlace({operationPlace: this.asifForm.getValue(x=>x.operationDetail.operationPlace) ,operationMethod: operationMethod }));
    // }
}
