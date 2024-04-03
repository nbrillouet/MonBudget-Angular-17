import { Injectable } from '@angular/core';
import { TypeButtonIcon } from '@corporate/mat-table-filter';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { OtForTable } from 'app/model/referential/operation-type.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { OtApiService } from '../ot.api.service';
import { ChangeOtTableFilterSelected, ChangeOtTableFilterSelectedPagination } from './ot-table-filter-selected/ot-table-filter-selected.action';
import { ChangeOtTable, DeleteOtTable } from './ot-table.action';

export class OtTableStateModel extends Datas<OtForTable[]> {
    constructor() {
        super();
    }
}

const otTableStateModel = new OtTableStateModel();

@State<OtTableStateModel>({
    name: 'OtTable',
    defaults : otTableStateModel
})

@Injectable()
export class OtTableState extends LoaderState {
    constructor(
        private _otApiService: OtApiService,
        private _store: Store,
        // private _assetService: AssetService
    ) {
        super();
    }

    @Selector()
    static get(state: OtTableStateModel): any { return state; }

    @Action(ChangeOtTable)
    changeOtTable(context: StateContext<OtTableStateModel>, action: ChangeOtTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        //Prerequis pour appel back: le main doit etre renseigné
        //user / idAccount /  monthYear / isWithItTransfer
        if(action.payload.user) {
            this._otApiService.getOtTable(action.payload)
                .pipe(finalize(()=> {this.loaded(context,'datas');}))
                .subscribe(
                    (result) => {
                        //remplacement des assets
                        result.datas.forEach((data: OtForTable) => {
                            data.buttonO = {label:'(250)', tooltip: 'opérations', icon: 'more_horiz', color: 'primary' } as TypeButtonIcon;
                            data.buttonDetail = {label:'...', tooltip: 'détail opération', icon: 'more_horiz', color: 'primary' } as TypeButtonIcon;
                        });

                        context.patchState({
                            datas: result.datas
                        });

                        this._store.dispatch(new ChangeOtTableFilterSelectedPagination(result.pagination));
                    }
                );
        }
    }

    @Action(DeleteOtTable)
    deleteOtTable(context: StateContext<OtTableStateModel>, action: DeleteOtTable): any {
        this.loading(context,'datas-delete');

        this._otApiService.deleteOtTable(action.payload.idOtfList)
            .pipe(finalize(()=> {this.loaded(context,'datas-delete');}))
            .subscribe((result)=> {
                this._store.dispatch(new ChangeOtTableFilterSelected(action.payload.filterSelected));
            });
    }
}

