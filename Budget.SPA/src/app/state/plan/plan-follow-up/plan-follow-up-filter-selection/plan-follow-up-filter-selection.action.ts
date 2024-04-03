import { FilterPlanFollowUpSelected } from 'app/model/filters/plan-follow-up.filter';

export const PLAN_FOLLOW_UP_FILTER_SELECTION_LOAD = 'plan-follow-up-filter-selection-load';

export class LoadPlanFollowUpFilterSelection {
    static readonly type = PLAN_FOLLOW_UP_FILTER_SELECTION_LOAD;

    constructor(public payload: FilterPlanFollowUpSelected) { }
}
