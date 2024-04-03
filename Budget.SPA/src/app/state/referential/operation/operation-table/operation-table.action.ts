import { FilterOTableSelected } from 'app/model/filters/operation.filter';

export const O_TABLE_CHANGE = 'o-table-change';
export const O_TABLE_DELETE = 'o-table-delete';

export class ChangeOTable {
    static readonly type = O_TABLE_CHANGE;

    constructor(public payload: FilterOTableSelected) { }
}

export class DeleteOTable {
    static readonly type = O_TABLE_DELETE;
    constructor(public payload: { idOtfList: number[]; filterSelected: FilterOTableSelected } ) { }
}
