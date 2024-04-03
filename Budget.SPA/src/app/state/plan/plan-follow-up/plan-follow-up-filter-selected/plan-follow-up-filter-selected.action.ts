import { FilterPlanFollowUpSelected } from 'app/model/filters/plan-follow-up.filter';

export const PLAN_FOLLOW_UP_FILTER_SELECTED_CHANGE = 'plan-follow-up-filter-selected-change';

export class ChangePlanFollowUpFilterSelected {
    static readonly type = PLAN_FOLLOW_UP_FILTER_SELECTED_CHANGE;

    constructor(public payload: FilterPlanFollowUpSelected) { }
}
