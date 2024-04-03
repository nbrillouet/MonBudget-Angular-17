/* eslint-disable arrow-body-style */
/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DetailFormInfo, DetailInfo, FilterForDetail } from '@corporate/model';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { OtForDetail } from 'app/model/referential/operation-type.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { catchError, finalize, throwError } from 'rxjs';
import { OtApiService } from '../ot.api.service';
import { LoadOtDetailFilter } from './ot-detail-filter/ot-detail-filter.action';
import { ClearOtDetail, LoadOtDetail, SaveOtDetail } from './ot-detail.action';
import { ToastrService } from 'ngx-toastr';

export class OtDetailStateModel extends DetailFormInfo<OtForDetail, FilterForDetail> {
    constructor() {
        super();
        this.filter = new FilterForDetail();
    }
}

const detailInfo = new OtDetailStateModel();
@State<OtDetailStateModel>({
    name: 'otDetail',
    defaults : detailInfo
})
@Injectable()
export class OtDetailState extends LoaderState {
    constructor(
        private _otApiService: OtApiService,
        private _store: Store,
        private _toastr: ToastrService
    )
    {
        super();
    }

    @Selector() static get(state: OtDetailStateModel): any { return state;  }
    @Selector() static getFilter(state: OtDetailStateModel): any { return state.filter; }

    @Action(LoadOtDetail)
    loadOtDetail(context: StateContext<OtDetailStateModel>, action: LoadOtDetail): void {
        this.loading(context,'datas');

        context.patchState({
            filter: action.payload,
            model: null
        });

        this._otApiService.getForDetail(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                // //remplacement des assets
                // result.asset.code = this._assetService.get(result.asset.code);
                context.patchState({
                    filter: action.payload,
                    model: result
                });

                //chargement des filtres associés
                context.dispatch(new LoadOtDetailFilter(result));
            });
    }

    @Action(SaveOtDetail)
    saveOtDetail(context: StateContext<OtDetailStateModel>, action: SaveOtDetail): void {
        this.loading(context, 'datas-save');

        this._otApiService.saveOtDetail(action.payload)
            .pipe(
                catchError((error) => {
                    return throwError(()=>error);
                }),
                finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe((result: OtForDetail)=> {
                this._store.dispatch(new UpdateFormValue({
                    path:'otDetail',
                    value: {
                        id : result.id
                    }
                }));
                this._toastr.success(`type opération: ${result.label} enregistré avec succès!`, 'Enregistrement effectué');
            });
    }

    @Action(ClearOtDetail)
    clearOtDetail(context: StateContext<OtDetailStateModel>): void {
        context.setState(new OtDetailStateModel());
    }
}
