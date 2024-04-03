import { Injectable } from '@angular/core';
import { TypeButtonIcon } from '@corporate/mat-table-filter';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { OtfForTable } from 'app/model/referential/operation-type-family.model';
import { AssetService } from 'app/services/referential/asset.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { OtfApiService } from '../otf-api.service';
import { ChangeOtfTableFilterSelected, ChangeOtfTableFilterSelectedPagination } from './otf-table-filter-selected/otf-table-filter-selected.action';
import { ChangeOtfTable, DeleteOtfTable } from './otf-table.action';

export class OtfTableStateModel extends Datas<OtfForTable[]> {
    constructor() {
        super();
    }
}

const otfTableStateModel = new OtfTableStateModel();

@State<OtfTableStateModel>({
    name: 'OtfTable',
    defaults : otfTableStateModel
})

@Injectable()
export class OtfTableState extends LoaderState {
    constructor(
        private _otfApiService: OtfApiService,
        private _store: Store,
        private _assetService: AssetService
    ) {
        super();
    }

    @Selector()
    static get(state: OtfTableStateModel): any { return state; }

    @Action(ChangeOtfTable)
    changeOtfTable(context: StateContext<OtfTableStateModel>, action: ChangeOtfTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        if(action.payload.user) {
            this._otfApiService.getOtfTable(action.payload)
                .pipe(finalize(()=> {this.loaded(context,'datas');}))
                .subscribe(
                    (result) => {
                        //remplacement des assets
                        result.datas.forEach((data: OtfForTable) => {
                            data.asset.code = this._assetService.get(data.asset.code);
                            data.buttonOt = {label:'(250)', tooltip: 'types opérations', icon: 'more_horiz', color: 'primary' } as TypeButtonIcon;
                            data.buttonDetail = {label:'...', tooltip: 'détail catégorie opération', icon: 'more_horiz', color: 'primary' } as TypeButtonIcon;
                        });

                        context.patchState({
                            datas: result.datas
                        });

                        this._store.dispatch(new ChangeOtfTableFilterSelectedPagination(result.pagination));
                    }
                );
        }
    }

    @Action(DeleteOtfTable)
    deleteOtfTable(context: StateContext<OtfTableStateModel>, action: DeleteOtfTable): any {
        this.loading(context,'datas-delete');

        this._otfApiService.deleteOtfTable(action.payload.idOtfList)
            .pipe(finalize(()=> {this.loaded(context,'datas-delete');}))
            .subscribe((result)=> {
                this._store.dispatch(new ChangeOtfTableFilterSelected(action.payload.filterSelected));
            });
    }
}

