import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterUserTableSelected } from 'app/model/filters/user.filter';
import { FilterSelected } from 'app/model/generics/filter.info.model';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadUserTable } from '../user-table.action';
import { UpdateUserTableFilterSelected, UpdateUserTableFilterSelectedByProperties } from './user-table-filter-selected.action';


export class UserTableFilterSelectedStateModel extends FilterSelected<FilterUserTableSelected> {
    constructor() {
        super(FilterUserTableSelected);
    }
}

const userTableFilterSelectedStateModel = new UserTableFilterSelectedStateModel();

@State<UserTableFilterSelectedStateModel>({
    name: 'UserTableFilterSelected',
    defaults : userTableFilterSelectedStateModel
})

@Injectable()
export class UserTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store,
        private _helperService: HelperService
        ) {
            super();
    }

    @Selector() static get(state: UserTableFilterSelectedStateModel): any { return state; }


    // @Action(UpdatePaginationUserTableFilterSelected)
    // UpdatePaginationUserTableFilterSelected(context: StateContext<UserTableFilterSelectedStateModel>, action: UpdatePaginationUserTableFilterSelected) {
    //     this.loading(context,'filter-selected');

    //     let state = context.getState();
    //     state.selected.pagination = action.payload;
    //     context.patchState(state);

    //     this.loaded(context,'filter-selected');
    // }

    @Action(UpdateUserTableFilterSelectedByProperties)
    updateUserTableFilterSelectedByProperties(context: StateContext<UserTableFilterSelectedStateModel>, action: UpdateUserTableFilterSelectedByProperties): void {
        this.loading(context,'filter-selected');

        let selected: FilterUserTableSelected;

        selected = this._helperService.getDeepClone(context.getState().selected);
        selected.isPaginationUpdate = false;

        action.payload.properties.forEach( (property) => {
            selected = this._helperService.setDeepProperty(selected,property.name,property.value);
            selected.isPaginationUpdate = property.name==='pagination' ? true : false;
        });

        context.patchState({ selected: selected });

        this.loaded(context,'filter-selected');

        //Pagination est donnée par la table
        if(!selected.isPaginationUpdate) {
            this._store.dispatch(new LoadUserTable(action.payload));
        }

    }

    @Action(UpdateUserTableFilterSelected)
    updateUserTableFilterSelected(context: StateContext<UserTableFilterSelectedStateModel>, action: UpdateUserTableFilterSelected): void {
        this.loading(context,'filter-selected');

        const selected: FilterUserTableSelected = action.payload;
        context.patchState({ selected: selected });

        this.loaded(context,'filter-selected');

        this._store.dispatch(new LoadUserTable(context.getState().selected));
    }

}
