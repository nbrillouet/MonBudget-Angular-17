import { Select, SelectCode } from '@corporate/model';


export class AsForTable {
    id: number=null;
    account: Select=null;
    bankAgency: Select=null;
    operation: Select=null;
    operationMethod: Select=null;
    operationType: Select=null;
    operationTypeFamily: Select=null;
    amountOperation: number=null;
    labelAs: string=null;
    dateIntegration: Date=null;
    idDuplicated: boolean=null;
    plans: SelectCode[]=null;
}
