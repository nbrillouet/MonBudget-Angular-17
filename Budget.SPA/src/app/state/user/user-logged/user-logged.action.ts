import { EnumUserStatus } from 'app/model/enum/enum-user-status.enum';
import { UserPreference } from 'app/model/referential/user/user.model';

export const USER_LOGGED_LOAD = 'user-logged-load';
export const USER_LOGGED_UPDATE_STATUS = 'user-logged-update-status';
export const USER_LOGGED_UPDATE_USER_PREFERENCE = 'user-logged-update-user-preference';

export class LoadUserLogged {
    static readonly type = USER_LOGGED_LOAD;

    constructor(public payload: {idUser: number}) { }
}

export class UpdateStatusUserLogged {
    static readonly type = USER_LOGGED_UPDATE_STATUS;

    constructor(public payload: {enumStatus: EnumUserStatus}) {};
}

export class UpdateUserPreference {
    static readonly type = USER_LOGGED_UPDATE_USER_PREFERENCE;

    constructor(public payload: {idUser: number, userPreference: UserPreference}) {};
}
