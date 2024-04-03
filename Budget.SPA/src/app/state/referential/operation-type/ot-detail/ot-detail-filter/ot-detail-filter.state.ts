/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DataInfo } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterOtDetail } from 'app/model/filters/operation-type.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { OtApiService } from '../../ot.api.service';
import { ClearOtDetailFilter, LoadOtDetailFilter } from './ot-detail-filter.action';

export class OtDetailFilterStateModel extends DataInfo<FilterOtDetail> {
    constructor() {
        super();
    }
}

const otDetailFilterStateModel = new OtDetailFilterStateModel();
@State<OtDetailFilterStateModel>({
    name: 'OtDetailFilter',
    defaults: otDetailFilterStateModel
})
@Injectable()
export class OtDetailFilterState extends LoaderState {
    constructor(
        private _otApiService: OtApiService
    ) {
        super();
    }

    @Selector() static get(state: OtDetailFilterStateModel): any { return state; }

    @Action(LoadOtDetailFilter)
    loadOtDetailFilter(context: StateContext<OtDetailFilterStateModel>, action: LoadOtDetailFilter): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._otApiService.getForDetailFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result) => {
                // //remplacement des assets
                // result.asset.forEach((data: SelectCode) => {
                //     data.code = this._assetService.get(data.code);
                // });
                context.patchState({
                    datas: result
                });
            });

        // this.loading(context,'datas');

        // const state = context.getState();
        // state.datas = null;
        // context.patchState(state);

        // this._otService.getForDetailFilter(action.payload)
        //     .subscribe((result) => {
        //         const state = context.getState();
        //         state.datas = result;
        //         context.patchState(state);

        //         this.loaded(context,'datas');
        //     });
    }

    @Action(ClearOtDetailFilter)
    clearOtDetailFilter(context: StateContext<OtDetailFilterStateModel>): void {
        context.setState(new OtDetailFilterStateModel());
    }
}
