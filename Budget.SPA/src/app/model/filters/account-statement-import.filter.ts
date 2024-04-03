import { Pagination } from '@corporate/mat-table-filter';
import { BankAgency } from '../referential/bank-agency.model';
import { UserForGroup } from '../referential/user/user.model';

export class FilterAsiTableSelected {
    user: UserForGroup = null;
    idBankAgency: number;
    indexTabBankAgency: number;

    isPaginationUpdate: boolean;
    pagination: Pagination;

    constructor() {
        this.idBankAgency = null;
        this.pagination = new Pagination();
        this.indexTabBankAgency = 0;
    }
}

export class FilterAsiTableSelection {
    bankAgencies: BankAgency[];

    constructor() {

        // this.selected = new FilterAsiTableSelected();
    }
}
