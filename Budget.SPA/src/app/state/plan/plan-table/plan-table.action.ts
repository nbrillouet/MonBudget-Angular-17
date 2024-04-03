
export const PLAN_TABLE_LOAD = 'plan-table-load';
export const PLAN_TABLE_CLEAR = 'plan-table-clear';

export class LoadPlanTable {
    static readonly type = PLAN_TABLE_LOAD;

    constructor(public payload: any) { }
}

export class ClearPlanTable {
    static readonly type = PLAN_TABLE_CLEAR;
}
