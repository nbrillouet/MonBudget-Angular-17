/* eslint-disable arrow-body-style */
/* eslint-disable @typescript-eslint/no-shadow */
import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { OForDetail } from 'app/model/referential/operation.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { OApiService } from '../o.api.service';
import { catchError, finalize, throwError } from 'rxjs';
import { DetailFormInfo, FilterForDetail } from '@corporate/model';
import { LoadODetailFilter } from './operation-detail-filter/o-detail-filter.action';
import { ClearODetail, LoadODetail, SaveODetail } from './o-detail.action';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { ToastrService } from 'ngx-toastr';

export class ODetailStateModel extends DetailFormInfo<OForDetail, FilterForDetail> {
    constructor() {
        super();
        this.filter = new FilterForDetail();
    }
}

const detailInfo = new ODetailStateModel();
@State<ODetailStateModel>({
    name: 'oDetail',
    defaults : detailInfo
})
@Injectable()
export class ODetailState extends LoaderState {
    constructor(
        private _oApiService: OApiService,
        private _toastrService: ToastrService,
        private _store: Store
    )
    {
        super();

    }

    @Selector() static get(state: ODetailStateModel): any { return state;  }
    @Selector() static getFilter(state: ODetailStateModel): any { return state.filter; }

    @Action(LoadODetail)
    loadODetail(context: StateContext<ODetailStateModel>, action: LoadODetail): void {
        this.loading(context,'datas');

        context.patchState({
            filter: action.payload,
            model: null
        });

        this._oApiService.getForDetail(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                // //remplacement des assets
                // result.asset.code = this._assetService.get(result.asset.code);
                context.patchState({
                    filter: action.payload,
                    model: result
                });
                //chargement des filtres associés
                context.dispatch(new LoadODetailFilter(result));
            });

    }

    @Action(SaveODetail)
    saveODetail(context: StateContext<ODetailStateModel>, action: SaveODetail): void {
        this.loading(context, 'datas-save');

        this._oApiService.saveODetail(action.payload)
            .pipe(
                catchError((error) => {
                    return throwError(()=>error);
                }),
                finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe((result: OForDetail)=> {
                this._store.dispatch(new UpdateFormValue({
                    path:'otDetail',
                    value: {
                        id : result.id
                    }
                }));
                this._toastrService.success(`type opération: ${result.label} enregistré avec succès!`, 'Enregistrement effectué');
            });
    }

    @Action(ClearODetail)
    clearOperationDetail(context: StateContext<ODetailStateModel>): void {
        context.setState(new ODetailStateModel());
    }
}
