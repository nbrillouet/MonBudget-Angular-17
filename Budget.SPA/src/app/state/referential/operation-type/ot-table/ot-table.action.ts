import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';

export const OT_TABLE_CHANGE = 'ot-table-change';
export const OT_TABLE_DELETE = 'ot-table-delete';

export class ChangeOtTable {
    static readonly type = OT_TABLE_CHANGE;

    constructor(public payload: FilterOtTableSelected) { }
}

export class DeleteOtTable {
    static readonly type = OT_TABLE_DELETE;
    constructor(public payload: { idOtfList: number[]; filterSelected: FilterOtTableSelected } ) { }
}
