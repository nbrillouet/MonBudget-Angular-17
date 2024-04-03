import { Select, SelectCode } from '@corporate/model';
import { Pagination } from '@corporate/mat-table-filter';
import { UserForGroup } from '../referential/user/user.model';

export class FilterAccountTableSelected {
    user: UserForGroup= null;
    number: string = null;
    label: string = null;
    bankFamily: Select[];

    isPaginationUpdate: boolean;
    pagination: Pagination;// = new Pagination();

    constructor(){
        this.pagination = new Pagination();
    }
}

export class FilterAccountTableSelection {
    bankFamily: Select[];
    number: string = null;
    label: string = null;

    constructor() {
    }
}

export class FilterAccountDetail {
    bankAgency: Select[];
    bankSubFamily: Select[];
    bankFamily: SelectCode[];
    accountType: Select[];
}
