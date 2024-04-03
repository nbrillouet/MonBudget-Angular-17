import { FilterUserTableSelected } from 'app/model/filters/user.filter';
import { Property } from 'app/model/generics/property.model';

export const USER_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES = 'user-table-filter-selected-update-by-properties';
export const USER_TABLE_FILTER_SELECTED_UPDATE = 'user-table-filter-selected-update';


export class UpdateUserTableFilterSelectedByProperties {
    static readonly type = USER_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES;

    constructor(public payload: { properties: Property[] } ) { }
}

export class UpdateUserTableFilterSelected {
    static readonly type = USER_TABLE_FILTER_SELECTED_UPDATE;

    constructor(public payload: FilterUserTableSelected ) { }
}
