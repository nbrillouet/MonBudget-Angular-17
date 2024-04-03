import { FilterPlanPosteTableSelected } from 'app/model/filters/plan-poste.filter';

export const PLAN_POSTE_TABLE_LOAD = 'plan-poste-table-load';
export const PLAN_POSTE_TABLE_DELETE = 'plan-poste-table-delete';
export const PLAN_POSTE_TABLE_CLEAR = 'plan-poste-table-clear';

export class LoadPlanPosteTable {
    static readonly type = PLAN_POSTE_TABLE_LOAD;
    constructor(public payload: any) { }
}

export class DeletePlanPosteTable {
    static readonly type = PLAN_POSTE_TABLE_DELETE;
    constructor(public payload: { idPlanPosteList: number[]; filterSelected: FilterPlanPosteTableSelected } ) { }
}

export class ClearPlanPosteTable {
    static readonly type = PLAN_POSTE_TABLE_CLEAR;
}
