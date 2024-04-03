import { Select, SelectCode } from '@corporate/model';
import { Pagination } from '@corporate/mat-table-filter';
import { UserForGroup } from '../referential/user/user.model';
import { assign } from 'lodash';

export class FilterOtfTableSelected {
    user: UserForGroup = null;
    label: string = null;
    movement: Select = null;
    pagination: Pagination = null;

    constructor(planPosteDetailFilter?: Partial<FilterOtfTableSelected>) {
        assign(this, planPosteDetailFilter);
    }
}

export class FilterOtfTableSelection {
    movement: Select[];

    constructor() {

    }
}

export class FilterOtfDetail {
    asset: SelectCode[];
    movement: Select[];
}
