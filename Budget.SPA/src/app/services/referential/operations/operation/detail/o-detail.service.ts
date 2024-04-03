import { Injectable } from '@angular/core';
import { CorpDataForm } from '@corporate/data';
import { DataInfo, DetailFormInfo, FilterForDetail } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterODetail } from 'app/model/filters/operation.filter';
import { OForDetail } from 'app/model/referential/operation.model';
import { ClearODetail, LoadODetail, SaveODetail } from 'app/state/referential/operation/operation-detail/o-detail.action';
import { ODetailState } from 'app/state/referential/operation/operation-detail/o-detail.state';
import { ClearODetailFilter } from 'app/state/referential/operation/operation-detail/operation-detail-filter/o-detail-filter.action';
import { ODetailFilterState } from 'app/state/referential/operation/operation-detail/operation-detail-filter/o-detail-filter.state';
import { Observable } from 'rxjs';
import { OForDetailFormBuilderOptions } from './o-detail.form-builer-option';

@Injectable({ providedIn: 'root' })
export class ODetailService extends CorpDataForm<OForDetail, OForDetailFormBuilderOptions>
{
    @Select(ODetailState.get) stateDetail$: Observable<DetailFormInfo<OForDetail, FilterForDetail>>;
    @Select(ODetailFilterState.get) stateFilter$: Observable<DataInfo<FilterODetail>>;

    currentId: number = null;
    saveInProgress: boolean = false;
    formIsLoaded: boolean = false;

    constructor(
        private _store: Store
    )
    {
        super(OForDetail, OForDetailFormBuilderOptions);

        this.stateDetail$
            .subscribe((x)=>{
                if(x.loader['datas']?.loaded) {
                    this.formIsLoaded = true;
                    console.log('model', x);
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

        this.stateFilter$
            // .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((x)=>{
                console.log('filter', x);
        });
    }

    destroyForm(): void {
        this.formIsLoaded = false;
        this.initForm(OForDetail, OForDetailFormBuilderOptions);

        this._store.dispatch(new ClearODetail());
        this._store.dispatch(new ClearODetailFilter());
    }

    saveDetail(): void {
        this._store.dispatch(new SaveODetail( this.form.formGroup.getRawValue() ));
    }

    loadDetail(filterForDetail: FilterForDetail): void {
        this._store.dispatch(new LoadODetail(filterForDetail));
    }

    initTrigger(): void {
        // this.initFormTriggerBankFamily();
        // this.initFormTriggerBankSubFamily();
        // this.initFormTriggerBankAgency();
    }
}
