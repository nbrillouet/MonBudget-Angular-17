import { Select, SelectGroup } from '@corporate/model';
import { Pagination } from '@corporate/mat-table-filter';
import { UserForGroup } from '../referential/user/user.model';
import { assign } from 'lodash';

export class FilterOtDetail {
    operationTypeFamily: SelectGroup[];
}

export class FilterOtTableSelected {
    user: UserForGroup = null;
    label: string = null;
    operationTypeFamily: Select = null;
    pagination: Pagination = null;

    constructor(selected?: Partial<FilterOtTableSelected>) {
        assign(this, selected);
    }
}

export class FilterOtTableSelection {
    operationTypeFamily: Select[];

    constructor() { }
}
