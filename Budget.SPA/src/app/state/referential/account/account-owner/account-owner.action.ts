import { AccountForDetail } from 'app/model/referential/account.model';


export const ACCOUNT_OWNER_RESPONSE = 'account-owner-response';
export const ACCOUNT_OWNER_ASK = 'account-owner-ask';

export class AskAccountOwner {
    static readonly type = ACCOUNT_OWNER_ASK;

    constructor(public payload: AccountForDetail) { }
}

export class ResponseAccountOwner {
    static readonly type = ACCOUNT_OWNER_RESPONSE;

    constructor(public payload: string) { }
}
