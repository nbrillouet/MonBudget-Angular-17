import { Pagination } from '@corporate/mat-table-filter';

export class FilterUserTableSelected {
    keyword: number;
    isPaginationUpdate: boolean;
    pagination: Pagination;

    constructor() {
        this.keyword = null;
        this.pagination = new Pagination();
    }
}

export class FilterUserTableSelection {
    // selected : FilterUserTableSelected;

    constructor() {
        // this.selected = new FilterUserTableSelected();
    }
}
