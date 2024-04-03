import { FilterPlanFollowUpSelected } from 'app/model/filters/plan-follow-up.filter';

export const PLAN_FOLLOW_UP_LOAD = 'plan-follow-up-load';

export class LoadPlanFollowUp {
    static readonly type = PLAN_FOLLOW_UP_LOAD;

    constructor(public payload: FilterPlanFollowUpSelected) { }
}



