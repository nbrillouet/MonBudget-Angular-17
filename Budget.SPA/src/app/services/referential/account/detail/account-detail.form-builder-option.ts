/* eslint-disable id-blacklist */
import { Validators } from '@angular/forms';
import { CorpDataFormOption } from '@corporate/data';

const requiredDisabled: CorpDataFormOption = { validators: [ Validators.required ], defaultDisabled: true, defaultValue: null };
const disabled: CorpDataFormOption = { validators: null, defaultDisabled: true, defaultValue: null };
const required: CorpDataFormOption = { validators: [ Validators.required ], defaultDisabled: false, defaultValue: null };

export class AccountForDetailFormBuilderOptions {
    number: CorpDataFormOption = required;
    label: CorpDataFormOption = required;
    bankFamily: CorpDataFormOption = required;
    bankSubFamily: CorpDataFormOption = required;
    bankAgency: CorpDataFormOption = required;
    accountType: CorpDataFormOption = required;
    startAmount: CorpDataFormOption = required;
    alertThreshold: CorpDataFormOption = required;
}

