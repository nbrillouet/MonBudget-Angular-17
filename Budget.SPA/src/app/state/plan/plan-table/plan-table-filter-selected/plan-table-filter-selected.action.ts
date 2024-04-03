import { FilterPlanTableSelected } from 'app/model/filters/plan.filter';
import { Pagination } from '@corporate/mat-table-filter';

export const PLAN_TABLE_FILTER_SELECTED_UPDATE_PAGINATION = 'plan-table-filter-selected-update-pagination';
export const PLAN_TABLE_FILTER_SELECTED_CHANGE = 'plan-table-filter-selected-change';

export class UpdatePaginationPlanTableFilterSelected {
    static readonly type = PLAN_TABLE_FILTER_SELECTED_UPDATE_PAGINATION;

    constructor(public payload: Pagination) { }
}

export class ChangePlanTableFilterSelected {
    static readonly type = PLAN_TABLE_FILTER_SELECTED_CHANGE;

    constructor(public payload: FilterPlanTableSelected) { }
}

