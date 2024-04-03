import { FilterPlanPosteTableSelected } from 'app/model/filters/plan-poste.filter';

export const PLAN_POSTE_TABLE_FILTER_SELECTION_LOAD = 'plan-poste-table-filter-selection-load';

export class LoadPlanPosteTableFilterSelection {
    static readonly type = PLAN_POSTE_TABLE_FILTER_SELECTION_LOAD;

    constructor(public payload: FilterPlanPosteTableSelected) { }
}
