import { Injectable } from '@angular/core';
import { TypeButtonIcon } from '@corporate/mat-table-filter';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { OForTable } from 'app/model/referential/operation.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { OApiService } from '../o.api.service';
import { ChangeOTableFilterSelected, ChangeOTableFilterSelectedPagination } from './operation-table-filter-selected/operation-table-filter-selected.action';
import { ChangeOTable, DeleteOTable } from './operation-table.action';

export class OTableStateModel extends Datas<OForTable[]> {
    constructor() {
        super();
    }
}

const oTableStateModel = new OTableStateModel();

@State<OTableStateModel>({
    name: 'OTable',
    defaults : oTableStateModel
})

@Injectable()
export class OTableState extends LoaderState {
    constructor(
        private _oApiService: OApiService,
        private _store: Store
    ) {
        super();
    }

    @Selector()
    static get(state: OTableStateModel): any { return state; }

    @Action(ChangeOTable)
    changeOTable(context: StateContext<OTableStateModel>, action: ChangeOTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        //Prerequis pour appel back: le main doit etre renseigné
        //user / idAccount /  monthYear / isWithItTransfer
        if(action.payload.user) {
            this._oApiService.getOTable(action.payload)
                .pipe(finalize(()=> {this.loaded(context,'datas');}))
                .subscribe(
                    (result) => {
                        //remplacement des assets
                        result.datas.forEach((data: OForTable) => {
                            data.buttonDetail = {label:'...', tooltip: 'détail catégorie opération', icon: 'more_horiz', color: 'primary' } as TypeButtonIcon;
                        });

                        context.patchState({
                            datas: result.datas
                        });

                        this._store.dispatch(new ChangeOTableFilterSelectedPagination(result.pagination));
                    }
                );
        }
    }

    @Action(DeleteOTable)
    deleteOTable(context: StateContext<OTableStateModel>, action: DeleteOTable): any {
        this.loading(context,'datas-delete');

        this._oApiService.deleteOTable(action.payload.idOtfList)
            .pipe(finalize(()=> {this.loaded(context,'datas-delete');}))
            .subscribe((result)=> {
                this._store.dispatch(new ChangeOTableFilterSelected(action.payload.filterSelected));
            });
    }
}

