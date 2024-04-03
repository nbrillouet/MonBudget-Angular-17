import { Pagination } from '@corporate/mat-table-filter';
import { UserForGroup } from '../referential/user/user.model';

export class FilterPlanTableSelected {
    user: UserForGroup= null;
    year: number = null;
    pagination: Pagination = new Pagination();
}

export class FilterPlanTableSelection {
    year: number[];
}

export class FilterPlanDetail {
    // user: UserForGroup= null;
    // year: number;
    // pagination: Pagination = new Pagination();
}

