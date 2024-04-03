import { FilterPlanNotAsTableGroupSelected } from 'app/model/filters/plan-not-as.filter';


export const PLAN_NOT_AS_TABLE_LOAD = 'plan-not-as-table-load';
export const PLAN_NOT_AS_TABLE_CLEAR = 'plan-not-as-table-clear';

export class ChangePlanNotAsTable {
    static readonly type = PLAN_NOT_AS_TABLE_LOAD;

    constructor(public payload: FilterPlanNotAsTableGroupSelected) { }
}

export class ClearPlanNotAsTable {
    static readonly type = PLAN_NOT_AS_TABLE_CLEAR;
}

