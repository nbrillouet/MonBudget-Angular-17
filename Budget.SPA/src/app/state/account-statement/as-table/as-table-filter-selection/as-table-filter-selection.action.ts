import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';

export const AS_TABLE_FILTER_SELECTION_CHANGE = 'as-table-filter-selection-change';
// export const AS_TABLE_FILTER_SELECTION_CHANGE = 'as-table-filter-selection-change';

export class ChangeAsTableFilterSelection {
    static readonly type = AS_TABLE_FILTER_SELECTION_CHANGE;

    constructor(public payload: FilterAsTableSelected) { }
}

// export class ChangeAsTableFilterSelection {
//     static readonly type = AS_TABLE_FILTER_SELECTION_CHANGE;

//     constructor(public payload: FilterAsTableSelected) { }
// }

