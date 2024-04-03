import { FilterPlanNotAsTableSelected } from 'app/model/filters/plan-not-as.filter';

export const PLAN_NOT_AS_TABLE_FILTER_SELECTION_CHANGE = 'plan-not-as-table-filter-selection-change';

export class ChangePlanNotAsTableFilterSelection {
    static readonly type = PLAN_NOT_AS_TABLE_FILTER_SELECTION_CHANGE;

    constructor(public payload: FilterPlanNotAsTableSelected) { }
}
