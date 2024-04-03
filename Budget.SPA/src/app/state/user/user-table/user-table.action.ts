export const USER_TABLE_LOAD = 'user-table-load';
export const USER_TABLE_CLEAR = 'user-table-clear';

export class LoadUserTable {
    static readonly type = USER_TABLE_LOAD;

    constructor(public payload: any) { }
}

export class ClearUserTable {
    static readonly type = USER_TABLE_CLEAR;
}
