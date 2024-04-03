import { FilterUserTableSelected } from 'app/model/filters/user.filter';

export const USER_TABLE_FILTER_SELECTION_LOAD = 'user-table-filter-selection-load';

export class LoadUserTableFilterSelection {
    static readonly type = USER_TABLE_FILTER_SELECTION_LOAD;

    constructor(public payload: FilterUserTableSelected) { }
}
