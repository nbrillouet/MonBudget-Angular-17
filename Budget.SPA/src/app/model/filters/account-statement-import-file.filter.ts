import { Select, SelectGroup } from '@corporate/model';
import { Pagination } from '@corporate/mat-table-filter';
import { UserForGroup } from '../referential/user/user.model';
import { FilterAsDetail } from './account-statement.filter';

export class FilterAsifTableSelected {
    user: UserForGroup= null;
    idImport: number= null;
    account: Select= null;
    state: Select= null;
    indexTabAsifState: number = 0;
    asiBankAgencyLabel: string= null;
    asiDateImport: Date= null;
    pagination: Pagination = new Pagination();
}

export class FilterAsifTableSelection {
    account: Select[]=[];
    state: Select[]=[];

    operationMethod: Select[]=[];
    operationTypeFamily: SelectGroup[]=[];
    operationType: SelectGroup[]=[];
    operation: Select[]=[];

    constructor() { }
}

export class FilterAsifDetail extends FilterAsDetail {
    // operation : ISelect[];
    // operationMethod: ISelect[];
    // operationType: ISelect[];
    // operationTypeFamily: ISelect[];
    // operationPlace: ISelect[];
    // operationTransverse: ISelect[];
}

// export class FilterAsifDetail {
//     idAsif: number;
//     user: IUserForGroup;
// }

