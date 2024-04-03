import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { AsifForTable } from 'app/model/account-statement-import/account-statement-import-file.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsifApiService } from '../asif.api.service';
import { UpdatePaginationAsifTableFilterSelected } from './asif-table-filter-selected/asif-table-filter-selected.action';
import { ClearAsifTable, LoadAsifTable, SaveAsifTableInAs } from './asif-table.action';
import { ToastrService } from 'ngx-toastr';
//
export class AsifTableStateModel extends Datas<AsifForTable[]> {
    constructor() {
        super();
    }
}

const tableInfo = new AsifTableStateModel();
@State<AsifTableStateModel>({
    name: 'AsifTable',
    defaults : tableInfo
})

@Injectable()
export class AsifTableState extends LoaderState {
    constructor(
        private _toastrService: ToastrService,
        private _asifApiService: AsifApiService,
        private _store: Store

        ) {

            super();
    }

    @Selector()
    static get(state: AsifTableStateModel): any { return state; }

    @Action(LoadAsifTable)
    loadAsifTable(context: StateContext<AsifTableStateModel>, action: LoadAsifTable): void {

        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._asifApiService.getAsifTable(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: result.datas
                });

                this._store.dispatch(new UpdatePaginationAsifTableFilterSelected(result.pagination));
            });
    }

    @Action(ClearAsifTable)
    clearAsifTable(context: StateContext<AsifTableStateModel>): void {
        // context.setState(new AsifTableStateModel());
    }

    @Action(SaveAsifTableInAs)
    saveAsifTableInAs(context: StateContext<AsifTableStateModel>, action: SaveAsifTableInAs): void {

        this.loading(context,'datas-save');

        this._asifApiService.saveInAccountStatement(action.payload.idImport)
            .pipe(finalize(()=> {this.loaded(context,'datas-save');}))
            .subscribe(
                (res) => {
                    this._toastrService.success('Relevés enregistrés avec succès!', 'Enregistrement');
                }
            );
    }

}
