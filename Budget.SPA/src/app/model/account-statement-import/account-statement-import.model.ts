import { Select } from '@corporate/model';
import { BankAgency } from '../referential/bank-agency.model';
import { UserForMinimal } from '../referential/user/user.model';

export class AsiTable {
    id: number;
    user: UserForMinimal;
    bankAgency: Select;
    fileImport: string;
    dateImport: Date;
}

export class AsiForList {
    countBankAgency: number = null;
    countAsiFile: number = null;
    asiByBankAgencyList: AsiListByBankAgency[] = [];
}

export class AsiListByBankAgency {
    bankAgency: BankAgency = new BankAgency();
    asiForList: AsiTable[] = [];
}

export class AsiForDetail extends AsiTable {

}
