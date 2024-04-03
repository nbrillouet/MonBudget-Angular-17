import { ValidatorFn, Validators } from '@angular/forms';
import { CorpDataFormOption } from '@corporate/data';

const requiredDisabled: CorpDataFormOption = { validators: [ Validators.required ], defaultDisabled: true, defaultValue: null };
const disabled: CorpDataFormOption = { validators: null, defaultDisabled: true, defaultValue: null };
const required: CorpDataFormOption = { validators: [ Validators.required ], defaultDisabled: false, defaultValue: null };

export class PlanPosteFrequenciesBuilderOption {
    isYearly: CorpDataFormOption = required;
    yearly: CorpDataFormOption = required;
    monthly: CorpDataFormOption = required;
}

export class PlanPosteForDetailFormBuilderOptions {
    label: CorpDataFormOption = required;
    poste: CorpDataFormOption = required;
    referenceTable: CorpDataFormOption = required;
    // planPosteUser: PlanPosteUserForDetail[];
    planPosteReference: CorpDataFormOption = required;
    accounts: CorpDataFormOption = required;
    planPosteFrequencies: PlanPosteFrequenciesBuilderOption = new PlanPosteFrequenciesBuilderOption();

}
// PlanPosteFrequencyForDetail[];
// export class OperationDetailBuilderOptions {
//     // validators: ValidatorFn[] = [ Validators.required ];

//     // operation: Select = null;
//     keywordOperation: CorpDataFormOption = required;
//     // keywordPlace: string = null;
//     // operationLabel: string = null;
//     // placeLabel: string = null;
//     operationPlace: CorpDataFormOption = required;
//     // gMapAddress: GMapAddress = new GMapAddress();
// }
