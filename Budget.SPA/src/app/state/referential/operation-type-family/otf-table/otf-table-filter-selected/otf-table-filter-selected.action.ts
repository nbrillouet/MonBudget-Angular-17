import { Pagination } from '@corporate/mat-table-filter';
import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';

export const OTF_TABLE_FILTER_CHANGE = 'otf-table-filter-selected-change';
export const OTF_TABLE_FILTER_PAGINATION_CHANGE = 'otf-table-filter-selected-pagination-change';

export class ChangeOtfTableFilterSelected {
    static readonly type = OTF_TABLE_FILTER_CHANGE;

    constructor(public payload: FilterOtfTableSelected ) { }
}

export class ChangeOtfTableFilterSelectedPagination {
    static readonly type = OTF_TABLE_FILTER_PAGINATION_CHANGE;

    constructor(public payload: Pagination ) { }
}

// import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';
// import { Property } from 'app/model/generics/property.model';

// export const OTF_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES = 'otf-table-filter-selected-update-by-properties';
// export const OTF_TABLE_FILTER_SELECTED_UPDATE = 'otf-table-filter-selected-update';

// export class UpdateOtfTableFilterSelectedByProperties {
//     static readonly type = OTF_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES ;

//     constructor(public payload: { properties: Property[] }) { }
// }

// export class UpdateOtfTableFilterSelected {
//     static readonly type = OTF_TABLE_FILTER_SELECTED_UPDATE;

//     constructor(public payload: FilterOtfTableSelected) { }
// }
