import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { Datas } from 'app/model/generics/detail-info.model';
import { UserTable } from 'app/model/user.model';
import { UserService } from 'app/services/referential/user.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { UpdateUserTableFilterSelectedByProperties } from './user-table-filter-selected/user-table-filter-selected.action';
import { ClearUserTable, LoadUserTable } from './user-table.action';

export class UserTableStateModel extends Datas<UserTable[]> {
    constructor() {
        super();
    }
}

const tableInfo = new UserTableStateModel();
@State<UserTableStateModel>({
    name: 'UserTable',
    defaults : tableInfo
})

@Injectable()
export class UserTableState extends LoaderState {
    constructor(
        private _userService: UserService,
        private _store: Store) {
            super();
    }

    @Selector() static get(state: UserTableStateModel): any { return state; }

    @Action(LoadUserTable)
    loadUserTable(context: StateContext<UserTableStateModel>, action: LoadUserTable): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._userService.getUserTable(action.payload).subscribe(result=> {
            context.patchState({
                datas: result.datas
            });

            this._store.dispatch(new UpdateUserTableFilterSelectedByProperties({properties: [ { name:'pagination', value: result.pagination} ] }));
            this.loaded(context,'datas');
        });
    }

    @Action(ClearUserTable)
    clearUserTable(context: StateContext<UserTableStateModel>): void {
        return context.setState(new UserTableStateModel());
    }
}
