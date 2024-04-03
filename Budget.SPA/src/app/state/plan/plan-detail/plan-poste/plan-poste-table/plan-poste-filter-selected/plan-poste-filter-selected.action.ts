import { FilterPlanPosteTableSelected } from 'app/model/filters/plan-poste.filter';
import { Pagination } from '@corporate/mat-table-filter';

export const PLAN_POSTE_TABLE_FILTER_SELECTED_UPDATE_PAGINATION = 'plan-poste-table-filter-selected-update-pagination';
export const PLAN_POSTE_TABLE_FILTER_SELECTED_CHANGE = 'plan-poste-table-filter-selected-change';

export class UpdatePaginationPlanPosteTableFilterSelected {
    static readonly type = PLAN_POSTE_TABLE_FILTER_SELECTED_UPDATE_PAGINATION;

    constructor(public payload: Pagination) { }
}

export class ChangePlanPosteTableFilterSelected {
    static readonly type = PLAN_POSTE_TABLE_FILTER_SELECTED_CHANGE;

    constructor(public payload: FilterPlanPosteTableSelected) { }
}
// export class SynchronizePlanPosteTableFilterSelected {
//     static readonly type = PLAN_POSTE_TABLE_FILTER_SELECTED_CHANGE;

//     constructor(public payload: FilterPlanPosteTableSelected) { }
// }
