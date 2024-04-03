import { Select, SelectGroup } from '@corporate/model';
import { Pagination } from '@corporate/mat-table-filter';
import { UserForGroup } from '../referential/user/user.model';
import { assign } from 'lodash';

export class FilterODetail {
    operationMethod: Select[];
    operationType: SelectGroup[];
}

export class FilterOTableSelected {
    user: UserForGroup = null;
    label: string = null;
    operationMethod: Select = null;
    operationType: Select = null;
    pagination: Pagination = null;

    constructor(selected?: Partial<FilterOTableSelected>) {
        assign(this, selected);
    }
}

export class FilterOTableSelection {
    operationMethod: Select[];
    operationType: SelectGroup[];

    constructor() {  }
}

// export class FilterOperationType {
//     operationMethod: Select;
//     operationType: Select;
// }
