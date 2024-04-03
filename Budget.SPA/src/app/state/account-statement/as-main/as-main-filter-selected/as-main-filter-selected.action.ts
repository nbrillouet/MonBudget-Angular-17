import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';

export const AS_MAIN_FILTER_SELECTED_CHANGE = 'as-main-filter-selected-change';

export class ChangeAsMainFilterSelected {
    static readonly type = AS_MAIN_FILTER_SELECTED_CHANGE;

    constructor(public payload: FilterAsMainSelected ) { }
}
