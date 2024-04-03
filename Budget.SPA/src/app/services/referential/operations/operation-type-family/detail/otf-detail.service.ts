import { Injectable } from '@angular/core';
import { CorpDataForm } from '@corporate/data';
import { DataInfo, DetailFormInfo, FilterForDetail } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterOtfDetail } from 'app/model/filters/operation-type-family.filter';
import { OtfForDetail } from 'app/model/referential/operation-type-family.model';
import { ClearOtfDetailFilter } from 'app/state/referential/operation-type-family/otf-detail/otf-detail-filter/otf-detail-filter.action';
import { OtfDetailFilterState } from 'app/state/referential/operation-type-family/otf-detail/otf-detail-filter/otf-detail-filter.state';
import { ClearOtfDetail, LoadOtfDetail, SaveOtfDetail } from 'app/state/referential/operation-type-family/otf-detail/otf-detail.action';
import { OtfDetailState } from 'app/state/referential/operation-type-family/otf-detail/otf-detail.state';
import { Observable } from 'rxjs';
import { OtfForDetailFormBuilderOptions } from './otf-detail.form-builder-option';

@Injectable({ providedIn: 'root' })
export class OtfDetailService extends CorpDataForm<OtfForDetail, OtfForDetailFormBuilderOptions>
{
    @Select(OtfDetailState.get) stateDetail$: Observable<DetailFormInfo<OtfForDetail, FilterForDetail>>;
    @Select(OtfDetailFilterState.get) stateFilter$: Observable<DataInfo<FilterOtfDetail>>;

    currentId: number = null;
    saveInProgress: boolean = false;
    formIsLoaded: boolean = false;

    constructor(
        private _store: Store
    )
    {
        super(OtfForDetail, OtfForDetailFormBuilderOptions);

        this.stateDetail$
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
        this.formIsLoaded = false;
        this.initForm(OtfForDetail, OtfForDetailFormBuilderOptions);

        this._store.dispatch(new ClearOtfDetail());
        this._store.dispatch(new ClearOtfDetailFilter());
    }

    saveDetail(): void {
        this._store.dispatch(new SaveOtfDetail({ otfDetail: this.form.formGroup.getRawValue() }));
    }

    loadDetail(filterForDetail: FilterForDetail): void {
        this._store.dispatch(new LoadOtfDetail(filterForDetail));
    }

    // getGMapAddressFilterData(): GMapAddressFilterData {
    //     const gmapAddress = this.form.getValue(x=>x.bankAgency.gMapAddress);
    //     // const operationDetail = this._asifDetailService.asifForm.getValue(x=>x.operationDetail) as OperationDetail;
    //     const gMapAddressFilterData = {datas: gmapAddress, filter: null } as GMapAddressFilterData;
    //     return gMapAddressFilterData;
    // }


    initTrigger(): void {
        // this.initFormTriggerBankFamily();
        // this.initFormTriggerBankSubFamily();
        // this.initFormTriggerBankAgency();
    }

    // private initFormTriggerBankFamily(): void {
    //     this.form.getControl(x=>x.bankFamily).valueChanges.subscribe((value) => {
    //         if(this.form.formGroup.dirty) {
    //             this.updateBankFamily(value);
    //         }
    //     });
    // }

    // private initFormTriggerBankSubFamily(): void {
    //     this.form.getControl(x=>x.bankSubFamily).valueChanges.subscribe((value) => {
    //         if(this.form.formGroup.dirty) {
    //             this.updateBankSubFamily(value);
    //         }
    //     });
    // }

    // private initFormTriggerBankAgency(): void {
    //     this.form.getControl(x=>x.bankAgency).valueChanges.subscribe((value) => {
    //         if(this.form.formGroup.dirty) {
    //             // this.updateBankAgency(value);
    //         }
    //     });
    // }

    // //===========================================================
    // //===   BANK FAMILY
    // //===========================================================
    // private updateBankFamily(bankFamily: SelectCodeUrl): void {
    //     this.triggerBankFamily(bankFamily);
    // }

    // private triggerBankFamily(bankFamily: SelectCodeUrl): void {
    //     //modification bank family implique:
    //     //-->change liste bankSubFamily
    //     this.changeBankSubFamilyList(bankFamily);
    // }

    // //===========================================================
    // //===   BANK SUB FAMILY
    // //===========================================================
    // private updateBankSubFamily(bankSubFamily: SelectModel): void {
    //     this.triggerBankSubFamily(bankSubFamily);
    // }

    // private triggerBankSubFamily(bankSubFamily: SelectModel): void {
    //     //modification du type operation famille implique:
    //     //-->change liste BankAgency
    //     this.changeBankAgencyList(bankSubFamily);
    // }

    // // trigger: tr-BankFamily
    // private changeBankSubFamilyList(bankFamily: SelectCodeUrl): void {
    //     this._store.dispatch(new AccountDetailFilterChangeBankSubFamily( { bankFamily:  bankFamily } ));
    // }

    // //===========================================================
    // //===   BANK AGENCY
    // //===========================================================
    // // trigger: tr-bankSubFamily
    // private changeBankAgencyList(bankSubFamily: SelectModel): void {
    //     this._store.dispatch(new AccountDetailFilterChangeBankAgency({ bankSubFamily: bankSubFamily }));
    // }

}
