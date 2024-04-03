import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterUserTableSelection } from 'app/model/filters/user.filter';
import { FilterSelection } from 'app/model/generics/filter.info.model';
import { UserService } from 'app/services/referential/user.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadUserTableFilterSelection } from './user-table-filter-selection.action';

export class UserTableFilterSelectionStateModel extends FilterSelection<FilterUserTableSelection> {
    constructor () {
        super(FilterUserTableSelection);
    }
}

const userTableFilterSelectionStateModel = new UserTableFilterSelectionStateModel();

@State<UserTableFilterSelectionStateModel>({
    name: 'UserTableFilterSelection',
    defaults : userTableFilterSelectionStateModel
})

@Injectable()
export class UserTableFilterSelectionState extends LoaderState {

    constructor(
        private _userService: UserService
        ) {
            super();
    }

    @Selector() static get(state: UserTableFilterSelectionStateModel): any { return state; }

    @Action(LoadUserTableFilterSelection)
    loadUserTableFilterSelection(context: StateContext<UserTableFilterSelectionStateModel>, action: LoadUserTableFilterSelection): void {
        this.loading(context,'filter-selection');

        context.patchState({
            selection: null
        });

        this._userService.getUserTableFilter(action.payload).subscribe((result)=> {
            context.patchState({
                selection: result
            });

            this.loaded(context,'filter-selection');
        });

    }

}
