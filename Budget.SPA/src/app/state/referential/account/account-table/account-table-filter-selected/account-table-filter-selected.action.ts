import { FilterAccountTableSelected } from 'app/model/filters/account.filter';
import { Property } from 'app/model/generics/property.model';


export const ACCOUNT_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES = 'account-table-filter-selected-update-by-properties';
export const ACCOUNT_TABLE_FILTER_SELECTED_UPDATE = 'account-table-filter-selected-update';

export class UpdateAccountTableFilterSelectedByProperties {
    static readonly type = ACCOUNT_TABLE_FILTER_SELECTED_UPDATE_BY_PROPERTIES ;

    constructor(public payload: { properties: Property[] }) { }
}

export class UpdateAccountTableFilterSelected {
    static readonly type = ACCOUNT_TABLE_FILTER_SELECTED_UPDATE;

    constructor(public payload: FilterAccountTableSelected) { }
}
