import { Select, SelectCode } from '@corporate/model';
import { BankAgencyForList } from './bank-agency.model';

export class BankSubFamilyForDetail extends Select {
    bankFamily: SelectCode;
}

export class BankSubFamilyForList extends Select {
    bankAgency: BankAgencyForList[];
}
