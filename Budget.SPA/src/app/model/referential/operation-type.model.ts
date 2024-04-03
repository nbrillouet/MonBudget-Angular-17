
import { TypeButtonIcon } from '@corporate/mat-table-filter';
import { Select } from '@corporate/model';
import { UserForGroup } from './user/user.model';

export class OtForTable {
    id: number=null;
    label: string=null;
    operationTypeFamily: Select=null;
    user: UserForGroup=null;
    isMandatory: boolean=null;
    isUsed: boolean=null;
    buttonO: TypeButtonIcon=null;
    buttonDetail: TypeButtonIcon=null;
}

export class OtForDetail {
    id: number=null;
    label: string=null;
    operationTypeFamily: Select=null;
    user: UserForGroup=null;
    isMandatory: boolean=null;
}
