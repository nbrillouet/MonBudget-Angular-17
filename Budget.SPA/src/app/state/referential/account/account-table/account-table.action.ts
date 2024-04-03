import { FilterAccountTableSelected } from 'app/model/filters/account.filter';

export const ACCOUNT_TABLE_LOAD = 'account-table-load';
export const ACCOUNT_TABLE_CLEAR = 'account-table-clear';

export class LoadAccountTable {
    static readonly type = ACCOUNT_TABLE_LOAD;

    constructor(public payload: FilterAccountTableSelected) { }
}

export class ClearAccountTable {
    static readonly type = ACCOUNT_TABLE_CLEAR;
}
