import { PlanFollowUpAmountRealFilter } from 'app/model/filters/plan-follow-up-amount-real.filter';

export const PLAN_FOLLOW_UP_AMOUNT_REAL_FILTER_CHANGE = 'plan-follow-up-amount-real-filter-change';
export const PLAN_FOLLOW_UP_AMOUNT_REAL_LOAD = 'plan-follow-up-amount-real-load';

export class ChangePlanFollowUpAmountRealFilter {
    static readonly type = PLAN_FOLLOW_UP_AMOUNT_REAL_FILTER_CHANGE;

    constructor(public payload: PlanFollowUpAmountRealFilter) { }
}

export class LoadPlanFollowUpAmountReal {
    static readonly type = PLAN_FOLLOW_UP_AMOUNT_REAL_LOAD;

    constructor(public payload: PlanFollowUpAmountRealFilter) { }
}

