import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterOTableSelection } from 'app/model/filters/operation.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { OApiService } from '../../o.api.service';
import { ChangeOTableFilterSelection } from './operation-table-filter-selection.action';

export class OTableFilterSelectionStateModel extends FilterSelection<FilterOTableSelection> {
    constructor() {
        super(FilterOTableSelection);
    }
}

const oTableFilterSelectionStateModel = new OTableFilterSelectionStateModel();

@State<OTableFilterSelectionStateModel>({
    name: 'OTableFilterSelection',
    defaults : oTableFilterSelectionStateModel
})

@Injectable()
export class OTableFilterSelectionState extends LoaderState {

    constructor(
        private _store: Store,
        private _oApiService: OApiService
        ) {
            super();
    }

    @Selector()
    static get(state: OTableFilterSelectionStateModel): any { return state; }

    @Action(ChangeOTableFilterSelection)
    changeOTableFilterSelection(context: StateContext<OTableFilterSelectionStateModel>, action: ChangeOTableFilterSelection): void {

        this.loading(context,'filter-selection');

        if(action.payload?.user) {
            this._oApiService.getOTableFilter(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'filter-selection');}))
            .subscribe(
                (res) => {
                    context.patchState({
                        selection: res
                    });
                }
            );
        }
    }

}

// import { FilterOTableSelected } from 'app/model/filters/operation.filter';

// export const O_TABLE_FILTER_SELECTION_CHANGE = 'o-table-filter-selection-change';

// export class ChangeOTableFilterSelection {
//     static readonly type = O_TABLE_FILTER_SELECTION_CHANGE;

//     constructor(public payload: FilterOTableSelected) { }
// }

// import { FilterOperationTableSelected } from 'app/model/filters/operation.filter';

// export const OPERATION_TABLE_FILTER_SELECTION_LOAD = 'operation-table-filter-selection-load';

// export class LoadOperationTableFilterSelection {
//     static readonly type = OPERATION_TABLE_FILTER_SELECTION_LOAD;

//     constructor(public payload: FilterOperationTableSelected) { }
// }
