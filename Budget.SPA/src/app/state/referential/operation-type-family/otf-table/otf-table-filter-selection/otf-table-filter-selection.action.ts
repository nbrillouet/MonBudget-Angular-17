import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';

export const OTF_TABLE_FILTER_SELECTION_CHANGE = 'otf-table-filter-selection-change';

export class ChangeOtfTableFilterSelection {
    static readonly type = OTF_TABLE_FILTER_SELECTION_CHANGE;

    constructor(public payload: FilterOtfTableSelected) { }
}


// import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';

// export const OTF_TABLE_FILTER_SELECTION_LOAD = 'otf-table-filter-selection-load';

// export class LoadOtfTableFilterSelection {
//     static readonly type = OTF_TABLE_FILTER_SELECTION_LOAD;

//     constructor(public payload: FilterOtfTableSelected) { }
// }
