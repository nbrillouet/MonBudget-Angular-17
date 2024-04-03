import { Validators } from '@angular/forms';
import { TypeButtonIcon } from '@corporate/mat-table-filter';
import { Select, SelectCode } from '@corporate/model';
import { UserForGroup } from './user/user.model';

export class OtfForTable {
    id: number=null;
    label: string=null;
    asset: SelectCode=null;
    movement: Select=null;
    user: UserForGroup=null;
    isMandatory: boolean=null;
    isUsed: boolean=null;
    buttonOt: TypeButtonIcon=null;
    buttonDetail: TypeButtonIcon=null;
}

export class OtfForDetail {
    id:             number=null;
    label:          string=null;
    asset:          SelectCode=null;
    movement:       Select=null;
    user:           UserForGroup=null;
    isMandatory:    boolean=null;
}

// export class OtfForDetailValidators {
//     id:             Validators = Validators.required;
//     label:          Validators = Validators.required;
//     asset:          Validators = Validators.required;
//     movement:       Validators = Validators.required;
//     user:           Validators = Validators.required;
//     isMandatory:    Validators = Validators.required;
// }
