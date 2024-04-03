import { FilterAsiTableSelected } from 'app/model/filters/account-statement-import.filter';

export const ASI_TABLE_LOAD = 'asi-table-load';
export const ASI_TABLE_FILTER_CHANGE = 'asi-table-filter-change';
export const ASI_TABLE_CLEAR = 'asi-table-clear';

export class LoadAsiTable {
    static readonly type = ASI_TABLE_LOAD;

    constructor(public payload: FilterAsiTableSelected) { }
}

export class ClearAsiTable {
    static readonly type = ASI_TABLE_CLEAR;
}
