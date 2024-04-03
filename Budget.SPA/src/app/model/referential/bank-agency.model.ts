
// export interface IBankGeneric {
//     id: number;
//     labelShort: string;
//     labelLong: string;
//     logoClassName: string;
// }

import { Select, SelectCodeUrl } from '@corporate/model';
import { AccountForDetail } from './account.model';
import { BankSubFamilyForDetail } from './bank-sub-family.model';

export class BankAgency {
    id: number = null;
    label: string = null;
    bankSubFamily: SelectCodeUrl = null;
    bankFamily: SelectCodeUrl = null;
}

export class BankAgencyAccounts extends BankAgency {
    accounts: AccountForDetail[]  = null;
}

export class BankAgencyForDetail extends Select {
    bankSubFamily: BankSubFamilyForDetail;
}

export class BankAgencyForList extends Select {
    accountList: AccountForDetail[];
}
