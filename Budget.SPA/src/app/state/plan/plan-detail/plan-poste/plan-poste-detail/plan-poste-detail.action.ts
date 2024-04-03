import { SelectGroup } from '@corporate/model';
import { PlanPosteDetailFilter } from 'app/model/filters/plan-poste.filter';
import { PlanPosteForDetail } from 'app/model/plan/plan-poste/plan-poste.model';

export const PLAN_POSTE_DETAIL_LOAD = 'plan-poste-detail-load';
export const PLAN_POSTE_DETAIL_SAVE = 'plan-poste-detail-save';
export const PLAN_POSTE_DETAIL_CLEAR = 'plan-poste-detail-clear';
export const PLAN_POSTE_PLAN_POSTE_REFERENCE_CHANGE= 'plan-poste-plan-poste-reference-change';

export class LoadPlanPosteDetail {
    static readonly type = PLAN_POSTE_DETAIL_LOAD;

    constructor(public payload: PlanPosteDetailFilter) { }
}

export class SavePlanPosteDetail {
    static readonly type = PLAN_POSTE_DETAIL_SAVE;

    constructor(public payload: PlanPosteForDetail) { }
}

export class ClearPlanPosteDetail {
    static readonly type = PLAN_POSTE_DETAIL_CLEAR;
}

//CHANGE PlanPosteReference
export class ChangePlanPostePlanPosteReference {
    static readonly type = PLAN_POSTE_PLAN_POSTE_REFERENCE_CHANGE;
    constructor(public payload: SelectGroup[]) { }
}


