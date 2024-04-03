import { UserForPasswordChange, UserForRegister } from 'app/model/referential/user/user.model';

export const LOGIN = 'login';
export const LOGOUT = 'logout';
export const ACCOUNT_PASSWORD_RECOVERY = 'account-password-recovery';
export const ACCOUNT_ACTIVATION = 'account-activation';
export const CHANGE_PASSWORD = 'change-password';
export const REGISTER= 'register';

// export const ACCOUNT_DETAIL_RESPONSE_OWNER = 'account-detail-response-owner';

export class Login {
    static readonly type = LOGIN;

    constructor(public payload: {username: string; password: string}) { }
}

export class Logout {
    static readonly type = LOGOUT;

    constructor() { }
}

export class AccountPasswordRecovery {
    static readonly type = ACCOUNT_PASSWORD_RECOVERY;

    constructor(public payload: {email: string }){};
}

export class AccountActivation {
    static readonly type = ACCOUNT_ACTIVATION;

    constructor(public payload: {validationCode: string }){};
}

export class ChangePassword {
    static readonly type = CHANGE_PASSWORD;
    constructor(public payload: {userForPasswordChange: UserForPasswordChange}){}

}

export class Register {
    static readonly type = REGISTER;

    constructor(public payload: {userForRegister: UserForRegister}){}
}

// export class ResponseOfAccountOwner {
//     static readonly type = ACCOUNT_DETAIL_RESPONSE_OWNER;

//     constructor(public payload: string) { }
// }
