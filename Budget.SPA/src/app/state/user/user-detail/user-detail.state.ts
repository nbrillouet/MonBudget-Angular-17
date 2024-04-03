import { Injectable } from '@angular/core';
import { DetailFormInfo } from '@corporate/model';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { UserForDetail, UserPreference } from 'app/model/referential/user/user.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { UserApiService } from '../user.api.service';
import { AddShortcutUserDetail, ChangeAvatarUserDetail, ChangeUserPreferenceUserDetail, ClearUserDetail, DeleteShortcutUserDetail, DeleteUserDetail, LoadUserDetail, SaveUserDetail } from './user-detail.action';

export class UserDetailStateModel extends DetailFormInfo<UserForDetail,null>  {

}

const userDetail = new UserDetailStateModel();
@State<UserDetailStateModel>({
    name: 'userDetail',
    defaults : userDetail
})

@Injectable()
export class UserDetailState extends LoaderState {
    constructor(
        private _userApiService: UserApiService,
        private _store: Store
        ) {
            super();
    }

    @Selector()
    static get(state: UserDetailStateModel): any {  return state; }

    @Action(LoadUserDetail)
    loadUserDetail(context: StateContext<UserDetailStateModel>, action: LoadUserDetail): void {
        this.loading(context,'datas');
        context.patchState({model: null});

        this._userApiService.getUserForDetail(action.payload.idUser)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result)=> {
                context.patchState({
                    model: result
                });
            });
    }

    @Action(ClearUserDetail)
    clear(context: StateContext<UserDetailStateModel>): void {
        context.setState(new UserDetailStateModel());
    }

    @Action(SaveUserDetail)
    saveUserDetail(context: StateContext<UserDetailStateModel>, action: SaveUserDetail): void {
        this.loading(context, 'user-detail-save');

        this._userApiService.saveUserForDetail(action.payload).subscribe((result: UserForDetail) => {
            //MAJ du state/form à partir des données du result
            this._store.dispatch(new UpdateFormValue({
                    path:'userDetail',
                    value: result
                })
            );
            this.loaded(context, 'user-detail-save');
            // //dispatch afterSave
            // this._store.dispatch(new OnAfterSaveForm({path: 'couvertureDetail', idOrdre: result.id, categorie: result.categorie, statut: result.statut, enumFormSequence: result.enumFormSequence, forcableSave: false }))

            // //reload tableFilter
            // this._store.dispatch(new ReloadTableFilter({ component: CouvertureComponent, name: 'tableFilter' }));
        },
        (error) => {
            // this._store.dispatch(new OnAfterSaveErrorForm({path: 'couvertureDetail',error: error, statutPrevious: context.getState().model.saveForm.statutPrevious, forcableSave: context.getState().model.saveForm.forcableSave }));
        });
    }

    @Action(DeleteUserDetail)
    deleteUserDetail(context: StateContext<UserDetailStateModel>, action: DeleteUserDetail): void {
        context.patchState(context.getState());
    }

    @Action(DeleteShortcutUserDetail)
    deleteShortcutUserDetail(context: StateContext<UserDetailStateModel>, action: DeleteShortcutUserDetail): void {
        const state = context.getState();

        this._userApiService.deleteShortcut(state.model.id,action.idShortcut)
            .subscribe(()=> {
                //TODO
                // state.shortcuts.splice(state.shortcuts.findIndex(x=>x.id==action.id), 1);
                // context.patchState(state);
            });
    }

    @Action(AddShortcutUserDetail)
    addShortcutUserDetail(context: StateContext<UserDetailStateModel>, action: AddShortcutUserDetail): void {
        const state = context.getState();
        //TODO
        // this._userService.addShortcut(state.id,action.shortcut)
        //     .subscribe(result=> {
        //         state.shortcuts.push(<IUserShortcut>result);

        //         context.patchState(
        //             state
        //         );
        //     })
    }

    @Action(ChangeAvatarUserDetail)
    changeAvatarUserDetail(context: StateContext<UserDetailStateModel>, action: ChangeAvatarUserDetail): void {
        // this.loading(context, 'change-avatar');

        // context.patchState({
        //     model: {
        //         ...context.getState().model,
        //         avatarUrl: 'assets/images/users/avatar/profile.jpg'
        //     }
        // });


            // context.patchState({
            //     model: {
            //         ...context.getState().model,
            //         avatarUrl: 'assets/images/users/avatar/avatar_2.jpg'
            //     }
            // });

        this._userApiService.changeAvatar(action.payload.idUser, action.payload.file).subscribe((result) => {

            // context.patchState({
            //     model: {
            //         ...context.getState().model,
            //         avatarUrl: result
            //     }
            // });
        });

        // this.loaded(context, 'change-avatar');

    }

    @Action(ChangeUserPreferenceUserDetail)
    changeThemeUserDetail(context: StateContext<UserDetailStateModel>, action: ChangeUserPreferenceUserDetail): void {
        this.loading(context, 'change-user-preference');

        // context.patchState({
        //     model: {
        //         ...context.getState().model,
        //         avatarUrl: 'assets/images/users/avatar/profile.jpg'
        //     }
        // });


            // context.patchState({
            //     model: {
            //         ...context.getState().model,
            //         avatarUrl: 'assets/images/users/avatar/avatar_2.jpg'
            //     }
            // });

        this._userApiService.updateUserPreference(action.payload.idUser, action.payload.userPreference).subscribe((result: UserPreference) => {
            context.patchState({
                model: {
                    ...context.getState().model,
                    userPreference: result
                }
            });

            this.loaded(context, 'change-user-preference');
        });

        // this.loaded(context, 'change-avatar');

    }
}
