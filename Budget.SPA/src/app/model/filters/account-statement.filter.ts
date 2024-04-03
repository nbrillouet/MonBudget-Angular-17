import { Select, SelectGroup } from '@corporate/model';
import { FilterDateRange, FilterNumberRange, Pagination } from '@corporate/mat-table-filter';
import { UserForAuth } from '../referential/user/user.model';
import { FilterAccountMonthYear } from './account-month-year.filter';

export class FilterAsMainSelected extends FilterAccountMonthYear {
    user: UserForAuth= null;
    isWithItTransfer: boolean= true;
    tabIndex: number= 1;
}

export class FilterAsTableSelected extends FilterAsMainSelected {
    operationMethod: Select[] = null;
    operationTypeFamily: Select[] = null;
    operationType: Select[] = null;
    operation: Select[] = null;
    dateIntegration: FilterDateRange = null;
    amountOperation: FilterNumberRange = null;

    isPaginationUpdate: boolean=false;
    pagination: Pagination = new Pagination();

    constructor() {
        super();
    }
}

export class FilterAsMainSelection  {
    month: Select[]=null;
    year: number[]=null;
}

export class FilterAsTableSelection extends FilterAsMainSelection {
    operationMethod: Select[]=null;
    operationTypeFamily: SelectGroup[]=null;
    operationType: SelectGroup[]=null;
    operation: Select[]=null;


    constructor() {
        super();
    }
}

export class FilterAsDetail {
    operation: Select[];
    operationMethod: Select[];
    operationType: Select[];
    operationTypeFamily: Select[];
    operationPlace: Select[];
    operationTransverse: Select[];
}
