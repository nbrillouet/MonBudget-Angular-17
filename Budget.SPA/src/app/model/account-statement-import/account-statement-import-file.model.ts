import { Select } from '@corporate/model';
import { AsForDetail } from '../account-statement/account-statement-detail.model';
import { Account } from '../referential/account.model';

export class AsifGroupByAccounts {
    accounts: Account[]=[];
    idImport: number=null;
}

export class AsifForTable {
    id: number=null;
    operation: Select=null;
    operationMethod: Select=null;
    operationType: Select=null;
    operationTypeFamily: Select=null;
    amountOperation: number=null;
    labelAs: string=null;
    dateIntegration: Date=null;
    idDuplicated: boolean=null;
    detailRow: boolean=null;
}

export class AsifForDetail extends AsForDetail {

}
