import { FilterAccountTableSelected } from 'app/model/filters/account.filter';

export const ACCOUNT_TABLE_FILTER_SELECTION_LOAD = 'account-table-filter-selection-load';

export class LoadAccountTableFilterSelection {
    static readonly type = ACCOUNT_TABLE_FILTER_SELECTION_LOAD;

    constructor(public payload: FilterAccountTableSelected) { }
}
