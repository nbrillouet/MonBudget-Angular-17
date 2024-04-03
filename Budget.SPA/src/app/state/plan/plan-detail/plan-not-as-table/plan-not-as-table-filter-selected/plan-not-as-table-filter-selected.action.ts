import { Pagination } from '@corporate/mat-table-filter';
import { FilterPlanNotAsTableGroupSelected } from 'app/model/filters/plan-not-as.filter';
// import { Pagination } from 'app/model/pagination-to-delete.model';

export const PLAN_NOT_AS_TABLE_FILTER_SELECTED_PAGINATION_CHANGE = 'plan-not-as-table-filter-selected-pagination-change';
export const PLAN_NOT_AS_TABLE_FILTER_SELECTED_CHANGE = 'plan-not-as-table-filter-selected-change';

export class ChangePlanNotAsTableFilterSelectedPagination {
    static readonly type = PLAN_NOT_AS_TABLE_FILTER_SELECTED_PAGINATION_CHANGE;

    constructor(public payload: Pagination) { }
}

export class ChangePlanNotAsTableFilterSelected {
    static readonly type = PLAN_NOT_AS_TABLE_FILTER_SELECTED_CHANGE;

    constructor(public payload: FilterPlanNotAsTableGroupSelected) { }
}
