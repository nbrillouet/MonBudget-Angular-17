import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { ChangeOtTable } from '../ot-table.action';
import { ChangeOtTableFilterSelected, ChangeOtTableFilterSelectedPagination } from './ot-table-filter-selected.action';

export class OtTableFilterSelectedStateModel extends FilterSelected<FilterOtTableSelected> {
    constructor() {
        super(FilterOtTableSelected);
    }
}

const otTableFilterSelectedStateModel = new OtTableFilterSelectedStateModel();

@State<OtTableFilterSelectedStateModel>({
    name: 'OtTableFilterSelected',
    defaults : otTableFilterSelectedStateModel
})

@Injectable()
export class OtTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store
        ) {
            super();
    }

    @Selector()
    static get(state: OtTableFilterSelectedStateModel): any { return state; }


    @Action(ChangeOtTableFilterSelected)
    changeOtTableFilterSelected(context: StateContext<OtTableFilterSelectedStateModel>, action: ChangeOtTableFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: action.payload
        });

        this._store.dispatch(new ChangeOtTable(action.payload));

        this.loaded(context,'filter-selected');
    }

    @Action(ChangeOtTableFilterSelectedPagination)
    changeOtTableFilterSelectedPagination(context: StateContext<OtTableFilterSelectedStateModel>, action: ChangeOtTableFilterSelectedPagination): void {
        this.loading(context,'filter-selected-pagination');

        context.patchState({
            selected: {
                ...context.getState().selected,
                pagination: action.payload
            }
        });

        this.loaded(context,'filter-selected-pagination');
    }
}

// import { Injectable } from '@angular/core';
// import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
// import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';
// import { FilterSelected } from 'app/model/generics/filter.info.model';
// import { HelperService } from 'app/services/helper.service';
// import { LoaderState } from 'app/state/_base/loader-state';
// import { LoadOtTable } from '../ot-table.action';
// import { UpdateOtTableFilterSelected, UpdateOtTableFilterSelectedByProperties } from './ot-table-filter-selected.action';

// export class OtTableFilterSelectedStateModel extends FilterSelected<FilterOtTableSelected> {
//     constructor () {
//         super(FilterOtTableSelected);
//     }
// }

// const otTableFilterSelectedStateModel = new OtTableFilterSelectedStateModel();

// @State<OtTableFilterSelectedStateModel>({
//     name: 'OtTableFilterSelected',
//     defaults : otTableFilterSelectedStateModel
// })

// @Injectable()
// export class OtTableFilterSelectedState extends LoaderState {
//     constructor(
//         private _store: Store,
//         private _helperService: HelperService
//         ) {
//             super();
//     }

//     @Selector() static get(state: OtTableFilterSelectedStateModel): any { return state; }

//     @Action(UpdateOtTableFilterSelectedByProperties)
//     updateOtTableFilterSelectedByProperties(context: StateContext<OtTableFilterSelectedStateModel>, action: UpdateOtTableFilterSelectedByProperties): void {
//         this.loading(context,'filter-selected');

//         let selected: FilterOtTableSelected;

//         selected = this._helperService.getDeepClone(context.getState().selected);
//         selected.isPaginationUpdate = false;

//         action.payload.properties.forEach( (property) => {
//             selected = this._helperService.setDeepProperty(selected, property.name, property.value);
//             selected.isPaginationUpdate = property.name==='pagination' ? true : false;
//         });

//         this.updateOtTableFilterSelectedCommon(selected, context);
//     }

//     @Action(UpdateOtTableFilterSelected)
//     updateOtTableFilterSelected(context: StateContext<OtTableFilterSelectedStateModel>, action: UpdateOtTableFilterSelected): void {
//         this.loading(context,'filter-selected');

//         const selected: FilterOtTableSelected = action.payload;
//         selected.isPaginationUpdate = false;

//         this.updateOtTableFilterSelectedCommon(selected, context);

//     }

//     updateOtTableFilterSelectedCommon(selected: FilterOtTableSelected, context: StateContext<OtTableFilterSelectedStateModel>): void {
//         //user
//         selected.user = selected.user == null ? this._helperService.getUserForGroupFromStorage() : selected.user;
//         // //monthYear
//         // selected.monthYear = selected.monthYear == null ? this._helperService.getMonthYear() : selected.monthYear;

//         context.patchState({ selected: selected });

//         this.loaded(context,'filter-selected');

//         //Pagination est donnée par la table

//         if(!selected.isPaginationUpdate) {
//             this._store.dispatch(new LoadOtTable(context.getState().selected));
//         }
//     }


// }
