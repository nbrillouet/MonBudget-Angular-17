import { Pagination } from '@corporate/mat-table-filter';
import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';

export const OT_TABLE_FILTER_CHANGE = 'ot-table-filter-selected-change';
export const OT_TABLE_FILTER_PAGINATION_CHANGE = 'ot-table-filter-selected-pagination-change';

export class ChangeOtTableFilterSelected {
    static readonly type = OT_TABLE_FILTER_CHANGE;

    constructor(public payload: FilterOtTableSelected ) { }
}

export class ChangeOtTableFilterSelectedPagination {
    static readonly type = OT_TABLE_FILTER_PAGINATION_CHANGE;

    constructor(public payload: Pagination ) { }
}


// import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';
// import { Property } from 'app/model/generics/property.model';


// export const OT_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES = 'ot-table-filter-selected-update-by-properties';
// export const OT_TABLE_FILTER_SELECTED_UPDATE = 'ot-table-filter-selected-update';

// export class UpdateOtTableFilterSelectedByProperties {
//     static readonly type = OT_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES ;

//     constructor(public payload: { properties: Property[] }) { }
// }

// export class UpdateOtTableFilterSelected {
//     static readonly type = OT_TABLE_FILTER_SELECTED_UPDATE;

//     constructor(public payload: FilterOtTableSelected) { }
// }

