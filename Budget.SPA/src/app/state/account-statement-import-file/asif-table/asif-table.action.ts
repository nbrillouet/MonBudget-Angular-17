
export const ASIF_TABLE_LOAD = 'asif-table-load';
export const ASIF_TABLE_LOAD_SUCCESS = 'asif-table-load-success';
export const ASIF_TABLE_FILTER_CHANGE = 'asif-table-filter-change';
export const ASIF_TABLE_CLEAR = 'asif-table-clear';
export const ASIF_TABLE_SAVE_IN_AS = 'asif-table-save-in-as';

export class LoadAsifTable {
    static readonly type = ASIF_TABLE_LOAD;

    constructor(public payload: any) { }
}

export class SaveAsifTableInAs {
    static readonly type = ASIF_TABLE_SAVE_IN_AS;

    constructor(public payload: { idImport: number }) { }
}

export class ClearAsifTable {
    static readonly type = ASIF_TABLE_CLEAR;
    // constructor(public payload: any) { }
}
