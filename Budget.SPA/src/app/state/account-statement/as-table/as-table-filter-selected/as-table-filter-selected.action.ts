import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
import { Pagination } from '@corporate/mat-table-filter';

export const AS_TABLE_FILTER_CHANGE = 'as-table-filter-selected-change';
export const AS_TABLE_FILTER_PAGINATION_CHANGE = 'as-table-filter-selected-pagination-change';

export class ChangeAsTableFilterSelected {
    static readonly type = AS_TABLE_FILTER_CHANGE;

    constructor(public payload: FilterAsTableSelected ) { }
}

export class ChangeAsTableFilterSelectedPagination {
    static readonly type = AS_TABLE_FILTER_PAGINATION_CHANGE;

    constructor(public payload: Pagination ) { }
}


// export class UpdateAsTableFilterSelectedByProperties {
//     static readonly type = AS_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES ;

//     constructor(public payload: { properties: Property[] }) { }
// }

// export class UpdateAsTableFilterSelected {
//     static readonly type = AS_TABLE_FILTER_SELECTED_UPDATE;

//     constructor(public payload: FilterAsTableSelected) { }
// }

