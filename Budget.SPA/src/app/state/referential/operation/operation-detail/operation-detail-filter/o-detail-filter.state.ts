/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DataInfo } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterODetail } from 'app/model/filters/operation.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { OApiService } from '../../o.api.service';
import { ClearODetailFilter, LoadODetailFilter } from './o-detail-filter.action';

export class ODetailFilterStateModel extends DataInfo<FilterODetail> {
    constructor() {
        super();
    }
}

const oDetailFilterStateModel = new ODetailFilterStateModel();
@State<ODetailFilterStateModel>({
    name: 'oDetailFilter',
    defaults: oDetailFilterStateModel
})
@Injectable()
export class ODetailFilterState extends LoaderState {
    constructor(
        private _oApiService: OApiService
    ) {
        super();
    }

    @Selector() static get(state: ODetailFilterStateModel): any { return state; }

    @Action(LoadODetailFilter)
    loadODetailFilter(context: StateContext<ODetailFilterStateModel>, action: LoadODetailFilter): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._oApiService.getDetailFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result) => {
                context.patchState({
                    datas: result
                });
            });
    }

    @Action(ClearODetailFilter)
    clearODetailFilter(context: StateContext<ODetailFilterStateModel>): void {
        context.setState(new ODetailFilterStateModel());
    }
}
