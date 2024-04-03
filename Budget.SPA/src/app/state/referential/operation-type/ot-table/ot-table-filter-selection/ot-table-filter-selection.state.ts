import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterOtTableSelection } from 'app/model/filters/operation-type.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { OtApiService } from '../../ot.api.service';
import { ChangeOtTableFilterSelection } from './ot-table-filter-selection.action';

export class OtTableFilterSelectionStateModel extends FilterSelection<FilterOtTableSelection> {
    constructor() {
        super(FilterOtTableSelection);
    }
}

const otTableFilterSelectionStateModel = new OtTableFilterSelectionStateModel();

@State<OtTableFilterSelectionStateModel>({
    name: 'OtTableFilterSelection',
    defaults : otTableFilterSelectionStateModel
})

@Injectable()
export class OtTableFilterSelectionState extends LoaderState {

    constructor(
        private _store: Store,
        private _otApiService: OtApiService
        ) {
            super();
    }

    @Selector()
    static get(state: OtTableFilterSelectionStateModel): any { return state; }

    @Action(ChangeOtTableFilterSelection)
    changeOtTableFilterSelection(context: StateContext<OtTableFilterSelectionStateModel>, action: ChangeOtTableFilterSelection): void {

        this.loading(context,'filter-selection');

        if(action.payload?.user) {
            this._otApiService.getOtTableFilter(action.payload)
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

// import { Injectable } from '@angular/core';
// import { Action, Selector, State, StateContext } from '@ngxs/store';
// import { FilterOtTableSelection } from 'app/model/filters/operation-type.filter';
// import { FilterSelection } from 'app/model/generics/filter.info.model';
// import { OtService } from 'app/services/referential/operation-type.service';
// import { LoaderState } from 'app/state/_base/loader-state';
// import { LoadOtTableFilterSelection } from './ot-table-filter-selection.action';

// export class OtTableFilterSelectionStateModel extends FilterSelection<FilterOtTableSelection> {
//     constructor() {
//         super(FilterOtTableSelection);
//     }
// }

// const otTableFilterSelectionStateModel = new OtTableFilterSelectionStateModel();

// @State<OtTableFilterSelectionStateModel>({
//     name: 'OtTableFilterSelection',
//     defaults : otTableFilterSelectionStateModel
// })

// @Injectable()
// export class OtTableFilterSelectionState extends LoaderState {

//     constructor(
//         private _otService: OtService
//         ) {
//             super();
//     }

//     @Selector() static get(state: OtTableFilterSelectionStateModel): any { return state; }

//     @Action(LoadOtTableFilterSelection)
//     loadOtTableFilterSelection(context: StateContext<OtTableFilterSelectionStateModel>, action: LoadOtTableFilterSelection): void {
//         this.loading(context,'filter-selection');

//         context.patchState({
//             selection: null
//         });

//         this._otService.getForTableFilter(action.payload).subscribe((result)=> {
//             context.patchState({
//                 selection: result
//             });

//             this.loaded(context,'filter-selection');
//         });

//     }

// }
