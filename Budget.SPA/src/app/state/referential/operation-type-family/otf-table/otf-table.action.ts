import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';

export const OTF_TABLE_CHANGE = 'otf-table-change';
export const OTF_TABLE_DELETE = 'otf-table-delete';

export class ChangeOtfTable {
    static readonly type = OTF_TABLE_CHANGE;

    constructor(public payload: FilterOtfTableSelected) { }
}

export class DeleteOtfTable {
    static readonly type = OTF_TABLE_DELETE;
    constructor(public payload: { idOtfList: number[]; filterSelected: FilterOtfTableSelected } ) { }
}
