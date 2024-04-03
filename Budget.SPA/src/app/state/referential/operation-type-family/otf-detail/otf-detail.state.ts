/* eslint-disable arrow-body-style */
/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { DetailFormInfo, FilterForDetail } from '@corporate/model';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { OtfForDetail } from 'app/model/referential/operation-type-family.model';
import { AssetService } from 'app/services/referential/asset.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { catchError, finalize, throwError } from 'rxjs';
import { OtfApiService } from '../otf-api.service';
import { LoadOtfDetailFilter } from './otf-detail-filter/otf-detail-filter.action';
import { ClearOtfDetail, LoadOtfDetail, SaveOtfDetail } from './otf-detail.action';
import { ToastrService } from 'ngx-toastr';

export class OtfDetailStateModel extends DetailFormInfo<OtfForDetail, FilterForDetail> {
    constructor() {
        super();
        this.filter = new FilterForDetail();
    }
}

const detailInfo = new OtfDetailStateModel();
@State<OtfDetailStateModel>({
    name: 'otfDetail',
    defaults : detailInfo
})
@Injectable()
export class OtfDetailState extends LoaderState {
    constructor(
        private _otfApiService: OtfApiService,
        private _assetService: AssetService,
        private _store: Store,
        private _toastrService: ToastrService
    )
    {
        super();
    }

    @Selector() static get(state: OtfDetailStateModel): any { return state;  }
    @Selector() static getFilter(state: OtfDetailStateModel): any { return state.filter; }

    @Action(LoadOtfDetail)
    loadOtfDetail(context: StateContext<OtfDetailStateModel>, action: LoadOtfDetail): void {
        this.loading(context,'datas');

        context.patchState({
            filter: action.payload,
            model: null
        });

        this._otfApiService.getForDetail(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                //remplacement des assets
                result.asset.code = this._assetService.get(result.asset.code);
                context.patchState({
                    filter: action.payload,
                    model: result
                });

                //chargement des filtres associés
                context.dispatch(new LoadOtfDetailFilter(result));
            });
    }

    @Action(SaveOtfDetail)
    saveOtfDetail(context: StateContext<OtfDetailStateModel>, action: SaveOtfDetail): void {
        this.loading(context, 'datas-save');

        this._otfApiService.save(action.payload.otfDetail)
            .pipe(
                catchError((error) => {
                    return throwError(()=>error);
                }),
                finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe((result: OtfForDetail)=> {
                this._store.dispatch(new UpdateFormValue({
                    path:'otfDetail',
                    value: {
                        id : result.id
                    }
                }));
                this._toastrService.success(`catégorie opération: ${result.label} enregistré avec succès!`, 'Enregistrement effectué');
            });
    }

    @Action(ClearOtfDetail)
    clearOtfDetail(context: StateContext<OtfDetailStateModel>): void {
        context.setState(new OtfDetailStateModel());
    }
}
