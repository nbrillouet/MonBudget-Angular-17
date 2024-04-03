import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { AsiTable } from 'app/model/account-statement-import/account-statement-import.model';
import { Datas } from 'app/model/generics/detail-info.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { UpdateAsiTableFilterSelectedByProperties } from './asi-table-filter-selected/asi-table-filter-selected.action';
import { ClearAsiTable, LoadAsiTable } from './asi-table.action';

export class AsiTableStateModel extends Datas<AsiTable[]> {
    constructor () {
        super();
    }
}

const tableInfo = new AsiTableStateModel();
@State<AsiTableStateModel>({
    name: 'AsiTable',
    defaults : tableInfo
})

@Injectable()
export class AsiTableState extends LoaderState {
    constructor(
        private _asiService: AsiService,
        private _store: Store

        ) {
            super();
    }

    @Selector()
    static get(state: AsiTableStateModel): any { return state; }

    // @Selector()
    // static getFilter(state: AsiHistoTableStateModel) {
    //     return state.filter;
    // }

    @Action(LoadAsiTable)
    loadAsiTable(context: StateContext<AsiTableStateModel>, action: LoadAsiTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._asiService.getAsiTable(action.payload).subscribe((result)=> {
            context.patchState({
                datas: result.datas
            });

            this.loaded(context,'datas');

            this._store.dispatch(new UpdateAsiTableFilterSelectedByProperties({properties: [ { name:'pagination', value: result.pagination} ] } ));
        });
    }

    @Action(ClearAsiTable)
    clearAsiTable(context: StateContext<AsiTableStateModel>): void {
        context.setState(new AsiTableStateModel());
    }



}
