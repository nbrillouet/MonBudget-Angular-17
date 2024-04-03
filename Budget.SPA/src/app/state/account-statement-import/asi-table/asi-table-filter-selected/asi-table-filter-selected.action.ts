import { FilterAsiTableSelected } from 'app/model/filters/account-statement-import.filter';
import { Property } from 'app/model/generics/property.model';

export const ASI_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES = 'asi-table-filter-selected-update-by-properties';
export const ASI_TABLE_FILTER_SELECTED_UPDATE = 'asi-table-filter-selected-update';

export class UpdateAsiTableFilterSelectedByProperties {
    static readonly type = ASI_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES ;

    constructor(public payload: { properties: Property[] }) { }
}

export class UpdateAsiTableFilterSelected {
    static readonly type = ASI_TABLE_FILTER_SELECTED_UPDATE;

    constructor(public payload: FilterAsiTableSelected) { }
}

// export const ASI_TABLE_FILTER_SELECTED_UPDATE_PAGINATION = 'asi-table-filter-selected-update-pagination';
// export const ASI_TABLE_FILTER_SELECTED_CHANGE = 'asi-table-filter-selected-change';

// export class UpdatePaginationAsiTableFilterSelected {
//     static readonly type = ASI_TABLE_FILTER_SELECTED_UPDATE_PAGINATION;

//     constructor(public payload: Pagination) { }
// }

// export class SynchronizeAsiTableFilterSelected {
//     static readonly type = ASI_TABLE_FILTER_SELECTED_CHANGE;

//     constructor(public payload: FilterAsiTableSelected) { }
// }
