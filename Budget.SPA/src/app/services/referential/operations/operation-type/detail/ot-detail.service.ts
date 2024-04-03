import { Injectable } from '@angular/core';
import { CorpDataForm } from '@corporate/data';
import { DataInfo, DetailFormInfo, FilterForDetail } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterOtDetail } from 'app/model/filters/operation-type.filter';
import { OtForDetail } from 'app/model/referential/operation-type.model';
import { ClearOtDetailFilter } from 'app/state/referential/operation-type/ot-detail/ot-detail-filter/ot-detail-filter.action';
import { OtDetailFilterState } from 'app/state/referential/operation-type/ot-detail/ot-detail-filter/ot-detail-filter.state';
import { ClearOtDetail, LoadOtDetail, SaveOtDetail } from 'app/state/referential/operation-type/ot-detail/ot-detail.action';
import { OtDetailState } from 'app/state/referential/operation-type/ot-detail/ot-detail.state';
import { Observable } from 'rxjs';
import { OtForDetailFormBuilderOptions } from './ot-detail.form-builder-option';

@Injectable({ providedIn: 'root' })
export class OtDetailService extends CorpDataForm<OtForDetail, OtForDetailFormBuilderOptions>
{
    @Select(OtDetailState.get) stateDetail$: Observable<DetailFormInfo<OtForDetail, FilterForDetail>>;
    @Select(OtDetailFilterState.get) stateFilter$: Observable<DataInfo<FilterOtDetail>>;

    currentId: number = null;
    saveInProgress: boolean = false;
    formIsLoaded: boolean = false;

    constructor(
        private _store: Store
    )
    {
        super(OtForDetail, OtForDetailFormBuilderOptions);

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
        this.initForm(OtForDetail, OtForDetailFormBuilderOptions);

        this._store.dispatch(new ClearOtDetail());
        this._store.dispatch(new ClearOtDetailFilter());
    }

    saveDetail(): void {
        this._store.dispatch(new SaveOtDetail( this.form.formGroup.getRawValue() ));
    }

    loadDetail(filterForDetail: FilterForDetail): void {
        this._store.dispatch(new LoadOtDetail(filterForDetail));
    }

    initTrigger(): void {
        // this.initFormTriggerBankFamily();
        // this.initFormTriggerBankSubFamily();
        // this.initFormTriggerBankAgency();
    }
}
