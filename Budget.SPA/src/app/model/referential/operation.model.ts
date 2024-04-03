
import { TypeButtonIcon } from '@corporate/mat-table-filter';
import { Select } from '@corporate/model';
import { UserForGroup } from './user/user.model';

export class O {
    id: number=null;
    idOperationMethod: number=null;
    idOperationType: number=null;
    // keyword: string=null;
    label: string=null;
    reference: string=null;
    idUserGroup: number=null;
}

export class OForTable {
    id: number=null;
    label: string=null;
    operationMethod: Select=null;
    operationType: Select=null;
    user: UserForGroup=null;
    isMandatory: boolean=null;
    isUsed: boolean=null;
    buttonDetail: TypeButtonIcon=null;
}

export class OForDetail {
    id: number=null;
    label: string=null;
    operationMethod: Select=null;
    operationType: Select=null;
    user: UserForGroup=null;
    isMandatory: boolean=null;
}
