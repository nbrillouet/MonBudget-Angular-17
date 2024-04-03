import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { AsForTable } from 'app/model/account-statement/account-statement-table.model';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsApiService } from '../as-api.service';
import { ChangeAsTableFilterSelectedPagination } from './as-table-filter-selected/as-table-filter-selected.action';
import { ChangeAsTable } from './as-table.action';
import { HelperFilterService } from 'app/services/helper-filter.service';

export class AsTableStateModel extends Datas<AsForTable[]> {
    constructor() {
        super();
    }
}

const asTableStateModel = new AsTableStateModel();
@State<AsTableStateModel>({
    name: 'AsTable',
    defaults : asTableStateModel
})

@Injectable()
export class AsTableState extends LoaderState {
    constructor(
        private _asApiService: AsApiService,
        private _store: Store,
        private _helperFilterService: HelperFilterService
    ) {
        super();
    }

    @Selector()
    static get(state: AsTableStateModel): any { return state; }

    @Action(ChangeAsTable)
    changeAsTable(context: StateContext<AsTableStateModel>, action: ChangeAsTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        //Prerequis pour appel back: le main doit etre renseigné
        //user / idAccount /  monthYear / isWithItTransfer
        if(this._helperFilterService.isFullFill(action.payload)) {
            this._asApiService.getAsTable(action.payload)
                .pipe(finalize(()=> {this.loaded(context,'datas');}))
                .subscribe(
                    (result) => {
                        context.patchState({
                            datas: result.datas
                        });

                        this._store.dispatch(new ChangeAsTableFilterSelectedPagination(result.pagination));
                    }
                );
        }
    }
}
