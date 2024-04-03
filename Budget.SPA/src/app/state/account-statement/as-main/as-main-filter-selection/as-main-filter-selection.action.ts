import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';

export const AS_MAIN_FILTER_SELECTION_CHANGE = 'as-main-filter-selection-change';

export class ChangeAsMainFilterSelection {
    static readonly type = AS_MAIN_FILTER_SELECTION_CHANGE;

    constructor(public payload: FilterAsMainSelected) { }
}
