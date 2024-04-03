
import { AsiForDetail } from '../account-statement-import/account-statement-import.model';
import { AccountForDetail } from '../referential/account.model';
import { OperationDetail } from '../referential/operation-detail.model';
import { Select, SelectCode } from '@corporate/model';

export class AsForDetail {
    id: number = null;
    asi: AsiForDetail = null;
    account: AccountForDetail = null;

    operationDetail: OperationDetail = new OperationDetail();
    operation: Select = null;
    operationMethod: Select = null;
    operationType: Select = null;
    operationTypeFamily: SelectCode = null;
    operationTransverse: Select[] = null;

    amountOperation: number = null;
    labelAs: string = null;
    dateIntegration: Date = null;
    dateImport: Date = null;
    dateOperation: Date = null;

    isDuplicated: boolean = null;
    idMovement: number = null;
    reference: string = null;

    operationLabelTemp: string = null;
    operationTransverseLabelTemp: string = null;
    
    constructor() { }
}
