import { FormGroup } from '@angular/forms';
import { CorpFormParameter } from '@corporate/data';
import { Select } from '@corporate/model';

export class ChangeOperationListParameter extends CorpFormParameter {
    idUserGroup: number = null;
    operation: Select = null;
    operationMethod: Select = null;
    operationType: Select = null;

    constructor(formGroup: FormGroup) {
        super();

        this.initValues(this, formGroup);
        //TODO a remplacer/factoriser
        const asi = formGroup.controls['asi'].value;
        this.idUserGroup=asi?.user.idUserGroup;
    }
}
