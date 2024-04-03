/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DataInfo, SelectCode } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterOtfDetail } from 'app/model/filters/operation-type-family.filter';
import { AssetService } from 'app/services/referential/asset.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { OtfApiService } from '../../otf-api.service';
import { ClearOtfDetailFilter, LoadOtfDetailFilter } from './otf-detail-filter.action';

export class OtfDetailFilterStateModel extends DataInfo<FilterOtfDetail> {
    constructor() {
        super();
    }
}

const otfDetailFilterStateModel = new OtfDetailFilterStateModel();
@State<OtfDetailFilterStateModel>({
    name: 'OtfDetailFilter',
    defaults: otfDetailFilterStateModel
})
@Injectable()
export class OtfDetailFilterState extends LoaderState {
    constructor(
        private _otfApiService: OtfApiService,
        private _assetService: AssetService
    ) {
        super();
    }

    @Selector() static get(state: OtfDetailFilterStateModel): any { return state; }

    @Action(LoadOtfDetailFilter)
    loadOtfDetailFilter(context: StateContext<OtfDetailFilterStateModel>, action: LoadOtfDetailFilter): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._otfApiService.getForDetailFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result) => {
                //remplacement des assets
                result.asset.forEach((data: SelectCode) => {
                    data.code = this._assetService.get(data.code);
                });
                context.patchState({
                    datas: result
                });
            });
    }

    @Action(ClearOtfDetailFilter)
    clearOtfDetailFilter(context: StateContext<OtfDetailFilterStateModel>): void {
        context.setState(new OtfDetailFilterStateModel());
    }
}
