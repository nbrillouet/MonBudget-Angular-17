import { ValidatorFn, Validators } from '@angular/forms';
import { CorpDataFormOption } from '@corporate/data';

const requiredDisabled: CorpDataFormOption = { validators: [ Validators.required ], defaultDisabled: true, defaultValue: null };
const disabled: CorpDataFormOption = { validators: null, defaultDisabled: true, defaultValue: null };
const required: CorpDataFormOption = { validators: [ Validators.required ], defaultDisabled: false, defaultValue: null };

export class PlanCrudForDetailFormBuilderOptions {
    operationMethod: CorpDataFormOption = required;
    operationTypeFamily: CorpDataFormOption = required;
    operationType: CorpDataFormOption = required;
    operation: CorpDataFormOption = required;
    operationDetail: OperationDetailBuilderOptions = new OperationDetailBuilderOptions();
}

export class OperationDetailBuilderOptions {
    // validators: ValidatorFn[] = [ Validators.required ];

    // operation: Select = null;
    keywordOperation: CorpDataFormOption = required;
    // keywordPlace: string = null;
    // operationLabel: string = null;
    // placeLabel: string = null;
    operationPlace: CorpDataFormOption = required;
    // gMapAddress: GMapAddress = new GMapAddress();
}
