import { FilterOTableSelected } from 'app/model/filters/operation.filter';

export const O_TABLE_FILTER_SELECTION_CHANGE = 'o-table-filter-selection-change';

export class ChangeOTableFilterSelection {
    static readonly type = O_TABLE_FILTER_SELECTION_CHANGE;

    constructor(public payload: FilterOTableSelected) { }
}

// import { Injectable } from '@angular/core';
// import { Action, Selector, State, StateContext } from '@ngxs/store';
// import { FilterOperationTableSelection } from 'app/model/filters/operation.filter';
// import { FilterSelection } from 'app/model/generics/filter.info.model';
// import { OperationService } from 'app/services/referential/operation.service';
// import { LoaderState } from 'app/state/_base/loader-state';
// import { LoadOperationTableFilterSelection } from './operation-table-filter-selection.state';

// export class OperationTableFilterSelectionStateModel extends FilterSelection<FilterOperationTableSelection> {
//     constructor() {
//         super(FilterOperationTableSelection);
//     }
// }

// const operationTableFilterSelectionStateModel = new OperationTableFilterSelectionStateModel();

// @State<OperationTableFilterSelectionStateModel>({
//     name: 'OperationTableFilterSelection',
//     defaults : operationTableFilterSelectionStateModel
// })

// @Injectable()
// export class OperationTableFilterSelectionState extends LoaderState {

//     constructor(
//         private _operationService: OperationService
//         ) {
//             super();
//     }

//     @Selector() static get(state: OperationTableFilterSelectionStateModel): any { return state; }

//     @Action(LoadOperationTableFilterSelection)
//     loadOperationTableFilterSelection(context: StateContext<OperationTableFilterSelectionStateModel>, action: LoadOperationTableFilterSelection): void {
//         this.loading(context,'filter-selection');

//         context.patchState({
//             selection: null
//         });

//         this._operationService.getOperationTableFilter(action.payload).subscribe((result)=> {
//             context.patchState({
//                 selection: result
//             });

//             this.loaded(context,'filter-selection');
//         });

//     }

// }
