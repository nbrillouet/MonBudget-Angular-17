import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { ChangeAsTable } from '../as-table.action';
import { ChangeAsTableFilterSelected, ChangeAsTableFilterSelectedPagination } from './as-table-filter-selected.action';

export class AsTableFilterSelectedStateModel extends FilterSelected<FilterAsTableSelected> {
    constructor() {
        super(FilterAsTableSelected);
    }
}

const asTableFilterSelectedStateModel = new AsTableFilterSelectedStateModel();

@State<AsTableFilterSelectedStateModel>({
    name: 'AsTableFilterSelected',
    defaults : asTableFilterSelectedStateModel
})

@Injectable()
export class AsTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store,
        private _helperService: HelperService
        ) {
            super();
    }

    @Selector()
    static get(state: AsTableFilterSelectedStateModel): any { return state; }


    @Action(ChangeAsTableFilterSelected)
    changeAsTableFilterSelected(context: StateContext<AsTableFilterSelectedStateModel>, action: ChangeAsTableFilterSelected): void {
        this.loading(context,'filter-selected');

        context.patchState({
            selected: action.payload
        });

        this._store.dispatch(new ChangeAsTable(action.payload));

        this.loaded(context,'filter-selected');
    }

    @Action(ChangeAsTableFilterSelectedPagination)
    changeAsTableFilterSelectedPagination(context: StateContext<AsTableFilterSelectedStateModel>, action: ChangeAsTableFilterSelectedPagination): void {
        this.loading(context,'filter-selected-pagination');

        context.patchState({
            selected: {
                ...context.getState().selected,
                pagination: action.payload
            }
        });

        this.loaded(context,'filter-selected-pagination');
    }



    // @Action(UpdateAsTableFilterSelectedByProperties)
    // updateAsTableFilterSelectedByProperties(context: StateContext<AsTableFilterSelectedStateModel>, action: UpdateAsTableFilterSelectedByProperties): void {
    //     this.loading(context,'filter-selected');

    //     let selected: FilterAsTableSelected;

    //     selected = this._helperService.getDeepClone(context.getState().selected);
    //     selected.isPaginationUpdate = false;

    //     action.payload.properties.forEach( (property) => {
    //         selected = this._helperService.setDeepProperty(selected,property.name,property.value);
    //         if(property.name==='pagination') { selected.isPaginationUpdate=true; }

    //     });

    //     this.updateAsTableFilterSelectedCommon(selected, context);
    // }

    // @Action(UpdateAsTableFilterSelected)
    // updateAsTableFilterSelected(context: StateContext<AsTableFilterSelectedStateModel>, action: UpdateAsTableFilterSelected): void {
    //     this.loading(context,'filter-selected');

    //     const selected: FilterAsTableSelected = action.payload;
    //     selected.isPaginationUpdate = false;

    //     this.updateAsTableFilterSelectedCommon(selected, context);
    // }

    // updateAsTableFilterSelectedCommon(selected: FilterAsTableSelected, context: StateContext<AsTableFilterSelectedStateModel>): void {
    //     //user
    //     // selected.user = selected.user == null ? this._helperService.getUserForGroupFromStorage() : selected.user;
    //     //monthYear
    //     selected.monthYear = selected.monthYear == null ? this._helperService.getMonthYear() : selected.monthYear;

    //     context.patchState({ selected: selected });

    //     this.loaded(context,'filter-selected');

    //     //Pagination est donnée par la table
    //     if(!selected.isPaginationUpdate) { this._store.dispatch(new LoadAsTable(context.getState().selected)); }

    // }



}
