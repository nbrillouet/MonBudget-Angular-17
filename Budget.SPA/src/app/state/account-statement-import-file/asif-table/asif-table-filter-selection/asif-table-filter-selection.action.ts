import { FilterAsifTableSelected } from 'app/model/filters/account-statement-import-file.filter';


export const ASIF_TABLE_FILTER_SELECTION_LOAD = 'asif-table-filter-selection-load';

export class LoadAsifTableFilterSelection {
    static readonly type = ASIF_TABLE_FILTER_SELECTION_LOAD;

    constructor(public payload: FilterAsifTableSelected) { }
}
