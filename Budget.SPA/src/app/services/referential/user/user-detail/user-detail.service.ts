import { Injectable } from '@angular/core';
import { CorpDataForm } from '@corporate/data';
import { ModelInfo } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { UserShortcut } from 'app/model/referential/user/user-shortcut.model';
import { UserForDetail, UserPreference } from 'app/model/referential/user/user.model';
import { AddShortcutUserDetail, ChangeAvatarUserDetail, ChangeUserPreferenceUserDetail, DeleteShortcutUserDetail, DeleteUserDetail, LoadUserDetail, SaveUserDetail } from 'app/state/user/user-detail/user-detail.action';
import { UserDetailState } from 'app/state/user/user-detail/user-detail.state';
import { Observable } from 'rxjs';
import { UserForDetailFormBuilderOptions } from './user-for-detail.form-builder-option';

@Injectable({ providedIn: 'root' })
export class UserDetailService extends CorpDataForm<UserForDetail, UserForDetailFormBuilderOptions>
{
    @Select(UserDetailState.get) public state$: Observable<ModelInfo<UserForDetail>>;

    /**
     * Constructor
     */
    constructor(
        public _store: Store
    )
    {
        super(UserForDetail, UserForDetailFormBuilderOptions);

        this.state$.subscribe((x)=> {
            if(x?.loader['datas']?.loaded) {
            }
        });
    }


    // // -----------------------------------------------------------------------------------------------------
    // // @ Public methods
    // // -----------------------------------------------------------------------------------------------------
    load(idUser: number): void {
        this._store.dispatch(new LoadUserDetail({idUser: idUser}));
    }

    save(userForDetail: UserForDetail): void {
        this._store.dispatch(new SaveUserDetail(userForDetail));
    }

    delete(idUser: number): any {
        this._store.dispatch(new DeleteUserDetail(idUser));
    }

    addShortcut(shortcut: UserShortcut): any {
        this._store.dispatch(new AddShortcutUserDetail(shortcut));
    }

    deleteShortcut(idShorcut: number): void {
        this._store.dispatch(new DeleteShortcutUserDetail(idShorcut));
    }

    changeAvatar(idUser: number, file: any): void {
        this._store.dispatch(new ChangeAvatarUserDetail( {idUser: idUser, file: file }));
    }

    changeUserPreference(idUser: number, userPreference: UserPreference): void {
        this._store.dispatch(new ChangeUserPreferenceUserDetail( {idUser: idUser, userPreference: userPreference }));
    }

}
