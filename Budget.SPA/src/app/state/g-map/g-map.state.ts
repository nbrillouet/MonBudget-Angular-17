import { Injectable } from '@angular/core';
import { ModelInfo } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { GMapAddress, GMapAddressFilterData, GMapSearchInfo, GMapSearchModel } from 'app/model/g-map.model.';
import { LoaderState } from '../_base/loader-state';
import { ChangeGMapDetail, LoadGMapDetail } from './g-map.action';
import { GMapApiService } from './g-map.api.service';

export class GMapDetailStateModel extends ModelInfo<GMapAddressFilterData> {
    constructor() {
        super();
    }
}

const detailInfo = new GMapDetailStateModel();
@State<GMapDetailStateModel>({
    name: 'gMapDetail',
    defaults : detailInfo
})

@Injectable()
export class GMapDetailState extends LoaderState {
    constructor(
        private _gMapApiService: GMapApiService
    )
    {
        super();

    }

    @Selector() static get(state: GMapDetailStateModel): any { return state;  }

    @Action(LoadGMapDetail)
    loadGMapDetail(context: StateContext<GMapDetailStateModel>, action: LoadGMapDetail): void {

        this.loading(context,'datas');

        context.patchState({
            model: {
                datas: null,
                filter: null
            }
        });

        context.patchState({
            model: {
                datas: action.payload.datas,
                filter: action.payload.filter
            }
        });

        this.loaded(context,'datas');
    }

    @Action(ChangeGMapDetail)
    changeGMapDetail(context: StateContext<GMapDetailStateModel>, action: ChangeGMapDetail): void {
        this.loading(context,'datas');

        this._gMapApiService
            .changeGmapTypes(action.payload.gMapAddress.gMapTypes, action.payload.language)
            .subscribe((result)=> {
                context.patchState({
                    model: {
                        datas: {
                            ...action.payload.gMapAddress,
                            gMapTypes: result
                        },
                        filter: { ...context.getState().model.filter }
                    }
                });
                this.loaded(context,'datas');
            });

        this.loaded(context,'datas');
    }

    // @Action(ChangeGMapDetailGMapType)
    // changeGMapDetailGMapType(context: StateContext<GMapDetailStateModel>, action: ChangeGMapDetailGMapType): void {
    //     this.loading(context,'datas');

    //     this._gMapApiService.changeGmapTypes(action.payload.gMapTypes, action.payload.language).subscribe((result)=> {
    //         this._store.dispatch(
    //             new UpdateFormValue({
    //                 path:'asifDetail',
    //                 value: result
    //             })
    //         );



    //         // context.patchState({
    //         //     model: result
    //         // });
    //         this.loaded(context,'datas-save');

    //         // //chargement des filtres associés
    //         // context.dispatch(new LoadAsifDetailFilter(context.getState().model));
    //     });

    //     context.patchState({
    //         model: {
    //             datas: {
    //                 ...context.getState().model.datas,
    //                 gMapTypes: null },
    //             filter: { ...context.getState().model.filter }
    //         }
    //     });

    //     this.loaded(context,'datas');
    // }


}
