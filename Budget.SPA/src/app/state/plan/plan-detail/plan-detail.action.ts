import { FilterForDetail } from '@corporate/model';
import { PlanForDetail } from 'app/model/plan/plan.model';

export const PLAN_DETAIL_LOAD = 'plan-detail-load';
export const PLAN_DETAIL_FILTER_CHANGE = 'plan-detail-filter-change';
export const PLAN_DETAIL_CLEAR = 'plan-detail-clear';
export const PLAN_DETAIL_SAVE = 'plan-detail-save';


export class LoadPlanDetail {
    static readonly type = PLAN_DETAIL_LOAD;

    constructor(public payload: FilterForDetail) { }
}

export class ChangePlanDetailFilter {
    static readonly type = PLAN_DETAIL_FILTER_CHANGE;

    constructor(public payload: FilterForDetail) { }
}

export class SavePlanDetail {
    static readonly type = PLAN_DETAIL_SAVE;

    constructor(public payload: PlanForDetail) { }
}

export class ClearPlanDetail {
    static readonly type = PLAN_DETAIL_CLEAR;
    // constructor(public payload: any) { }
}
