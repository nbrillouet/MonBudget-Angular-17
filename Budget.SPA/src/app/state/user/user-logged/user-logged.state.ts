import { Injectable } from '@angular/core';
import { DataInfo } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { UserForLogged } from 'app/model/referential/user/user.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { UserApiService } from '../user.api.service';
import { LoadUserLogged, UpdateStatusUserLogged, UpdateUserPreference } from './user-logged.action';

export class UserLoggedStateModel extends DataInfo<UserForLogged>  {

}

const userLogged = new UserLoggedStateModel();;
@State<UserLoggedStateModel>({
    name: 'userLogged',
    defaults : userLogged
})

@Injectable()
export class UserLoggedState extends LoaderState {
    constructor(
        private _userApiService: UserApiService
        ) {
            super();
    }

    @Selector()
    static get(state: UserLoggedStateModel): any {  return state; }

    @Action(LoadUserLogged)
    loadUserLogged(context: StateContext<UserLoggedStateModel>, action: LoadUserLogged): void {
        this.loading(context,'datas');
        context.patchState({datas: null});

        this._userApiService.getUserForLogged(action.payload.idUser).subscribe((result)=> {
            context.patchState(
                {datas: result}
            );
            this.loaded(context,'datas');
        });
    }

    @Action(UpdateStatusUserLogged)
    updateStatusUserLogged(context: StateContext<UserLoggedStateModel>, action: UpdateStatusUserLogged): void {
        this.loading(context,'user-status');

        context.patchState({datas: {
            ...context.getState().datas,
            userPreference: {
                ...context.getState().datas.userPreference,
                status: action.payload.enumStatus
            }
        } });

        this._userApiService.updateUserForLogged(context.getState().datas).subscribe((result)=> {
            context.patchState(
                {datas: result}
            );
            this.loaded(context,'user-status');
        });
    }

    @Action(UpdateUserPreference)
    updateUserPreference(context: StateContext<UserLoggedStateModel>, action: UpdateUserPreference): void {
        this.loading(context,'user-preference');

        this._userApiService.updateUserPreference(action.payload.idUser, action.payload.userPreference).subscribe((result)=> {
            context.patchState({
                datas: {
                    ...context.getState().datas,
                    userPreference: result
                }
            });
            this.loaded(context,'user-preference');
        });
    }


}





