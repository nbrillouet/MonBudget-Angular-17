import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';

export const OT_TABLE_FILTER_SELECTION_CHANGE = 'ot-table-filter-selection-change';

export class ChangeOtTableFilterSelection {
    static readonly type = OT_TABLE_FILTER_SELECTION_CHANGE;

    constructor(public payload: FilterOtTableSelected) { }
}

// import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';

// export const OT_TABLE_FILTER_SELECTION_LOAD = 'ot-table-filter-selection-load';

// export class LoadOtTableFilterSelection {
//     static readonly type = OT_TABLE_FILTER_SELECTION_LOAD;

//     constructor(public payload: FilterOtTableSelected) { }
// }
