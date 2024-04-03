import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';

export const AS_TABLE_CHANGE = 'as-table-change';
// export const AS_TABLE_CLEAR = 'as-table-clear';

export class ChangeAsTable {
    static readonly type = AS_TABLE_CHANGE;

    constructor(public payload: FilterAsTableSelected) { }
}

// export class ClearAsTable {
//     static readonly type = AS_TABLE_CLEAR;
// }
