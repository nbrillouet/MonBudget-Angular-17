import { Pagination } from '@corporate/mat-table-filter';
import { FilterOTableSelected } from 'app/model/filters/operation.filter';

export const O_TABLE_FILTER_CHANGE = 'o-table-filter-selected-change';
export const O_TABLE_FILTER_PAGINATION_CHANGE = 'o-table-filter-selected-pagination-change';

export class ChangeOTableFilterSelected {
    static readonly type = O_TABLE_FILTER_CHANGE;

    constructor(public payload: FilterOTableSelected ) { }
}

export class ChangeOTableFilterSelectedPagination {
    static readonly type = O_TABLE_FILTER_PAGINATION_CHANGE;

    constructor(public payload: Pagination ) { }
}

// import { FilterOperationTableSelected } from 'app/model/filters/operation.filter';
// import { Property } from 'app/model/generics/property.model';

// export const OPERATION_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES = 'operation-table-filter-selected-update-by-properties';
// export const OPERATION_TABLE_FILTER_SELECTED_UPDATE = 'operation-table-filter-selected-update';

// export class UpdateOperationTableFilterSelectedByProperties {
//     static readonly type = OPERATION_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES ;

//     constructor(public payload: { properties: Property[] }) { }
// }

// export class UpdateOperationTableFilterSelected {
//     static readonly type = OPERATION_TABLE_FILTER_SELECTED_UPDATE;

//     constructor(public payload: FilterOperationTableSelected) { }
// }
