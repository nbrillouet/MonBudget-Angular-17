import { Select } from '@corporate/model';
import { PlanPosteReferenceFilter } from 'app/model/filters/plan-poste.filter';
import { PlanPosteForDetail } from 'app/model/plan/plan-poste/plan-poste.model';

export const PLAN_POSTE_DETAIL_FILTER_LOAD = 'plan-poste-detail-filter-load';
export const PLAN_POSTE_DETAIL_FILTER_CLEAR = 'plan-poste-detail-filter-clear';
export const PLAN_POSTE_DETAIL_FILTER_CHANGE_PLAN_POSTE_REFERENCE = 'plan-poste-detail-filter-change-plan-poste-reference';
// export const ACCOUNT_DETAIL_FILTER_CHANGE_BANK_SUB_FAMILY = 'account-detail-filter-change-bank-sub-family';
// export const ACCOUNT_DETAIL_FILTER_CHANGE_BANK_AGENCY = 'account-detail-filter-change-bank-agency';

export class LoadPlanPosteDetailFilter {
    static readonly type = PLAN_POSTE_DETAIL_FILTER_LOAD;

    constructor(public payload: {idUserGroup: number; planPosteForDetail: PlanPosteForDetail}) { }
}

export class ClearPlanPosteDetailFilter {
    static readonly type = PLAN_POSTE_DETAIL_FILTER_CLEAR;
}


export class PlanPosteDetailFilterChangePlanPosteReference {
    static readonly type = PLAN_POSTE_DETAIL_FILTER_CHANGE_PLAN_POSTE_REFERENCE;

    constructor(public payload: PlanPosteReferenceFilter) { }
}
