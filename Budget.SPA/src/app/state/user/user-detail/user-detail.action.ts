import { UserShortcut } from 'app/model/referential/user/user-shortcut.model';
import { UserForDetail, UserPreference } from 'app/model/referential/user/user.model';

export const USER_DETAIL_LOAD = 'user-detail-load';
export const USER_DETAIL_CLEAR = 'user-detail-clear';
export const USER_DETAIL_SYNCHRONIZE = 'user-detail-synchronize';

export const USER_ADD = 'user-add';
export const USER_DELETE = 'user-delete';
export const USER_DELETE_SHORTCUT  = 'user-delete-shortcut';
export const USER_ADD_SHORTCUT = 'user-add-shortcut';

export const USER_CHANGE_AVATAR = 'user-change-avatar';
export const USER_CHANGE_USER_PREFERENCE = 'user-change-user-preference';

// export class SynchronizeUserDetail {
//     static readonly type = USER_DETAIL_SYNCHRONIZE;

//     constructor(public payload: UserForDetail) { }
// }

export class SaveUserDetail {
    static readonly type = USER_ADD;

    constructor(public payload: UserForDetail) { }
}

export class DeleteUserDetail {
    static readonly type = USER_DELETE;

    constructor(public idUser: number) {}
}

export class LoadUserDetail {
    static readonly type = USER_DETAIL_LOAD;

    constructor(public payload: {idUser: number}) { }
}

export class ClearUserDetail {
    static readonly type = USER_DETAIL_CLEAR;
}

export class DeleteShortcutUserDetail {
    static readonly type = USER_DELETE_SHORTCUT;

    constructor(public idShortcut: number) {}
}

export class AddShortcutUserDetail {
    static readonly type = USER_ADD_SHORTCUT;

    constructor(public shortcut: UserShortcut) {}
}

export class ChangeAvatarUserDetail {
    static readonly type = USER_CHANGE_AVATAR;

    constructor(public payload: {idUser: number; file: FormData}) {}
}

export class ChangeUserPreferenceUserDetail {
    static readonly type = USER_CHANGE_USER_PREFERENCE;

    constructor(public payload: {idUser: number; userPreference: UserPreference}) {}
}

//================================================================================================


