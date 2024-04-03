import { Validators } from '@angular/forms';
import { CorpDataFormOption } from '@corporate/data';

const requiredDisabled: CorpDataFormOption = { validators: [ Validators.required ], defaultDisabled: true, defaultValue: null };
const disabled: CorpDataFormOption = { validators: null, defaultDisabled: true, defaultValue: null };
const required: CorpDataFormOption = { validators: [ Validators.required ], defaultDisabled: false, defaultValue: null };

export class OtForDetailFormBuilderOptions {
    // id: number=null;
    label:                  CorpDataFormOption = required;
    operationTypeFamily:    CorpDataFormOption = required;
    user:                   CorpDataFormOption = required;
    // isMandatory: boolean=null;
}
