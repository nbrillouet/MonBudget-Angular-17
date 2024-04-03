import { FilterAsifTableSelected } from 'app/model/filters/account-statement-import-file.filter';
import { Pagination } from '@corporate/mat-table-filter';

export const ASIF_TABLE_FILTER_SELECTED_UPDATE_PAGINATION = 'asif-table-filter-selected-update-pagination';
export const ASIF_TABLE_FILTER_SELECTED_CHANGE = 'asif-table-filter-selected-change';
export const ASIF_TABLE_FILTER_SELECTED_LOAD = 'asif-table-filter-selected-load';

export class UpdatePaginationAsifTableFilterSelected {
    static readonly type = ASIF_TABLE_FILTER_SELECTED_UPDATE_PAGINATION;

    constructor(public payload: Pagination) { }
}

export class ChangeAsifTableFilterSelected {
    static readonly type = ASIF_TABLE_FILTER_SELECTED_CHANGE;

    constructor(public payload: FilterAsifTableSelected) { }
}

export class LoadAsifTableFilterSelected {
    static readonly type = ASIF_TABLE_FILTER_SELECTED_LOAD;

    constructor(public payload: FilterAsifTableSelected) { }
}

