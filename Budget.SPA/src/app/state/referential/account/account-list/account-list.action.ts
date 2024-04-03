export const ACCOUNT_LIST_LOAD = 'account-list-load';
export const ACCOUNT_LIST_CHANGE = 'account-list-change';

export class LoadAccountList {
    static readonly type = ACCOUNT_LIST_LOAD;

    constructor(public payload: { idUser: number }) { }
}

export class ChangeAccountList {
    static readonly type = ACCOUNT_LIST_CHANGE;

    constructor(public payload: { idUser: number; idFolder: number }) { }
}
