/* eslint-disable id-blacklist */
import { ComboMultiple, ComboSimple, Select, SelectGroup } from '@corporate/model';
import { EnumFrequency } from 'app/model/enum/enum-frequency.enum';
import { UserForLabel } from 'app/model/referential/user/user.model';
import { assign } from 'lodash';

export class PlanPostes {
    recettes: PlanPoste;
    depenseFixes: PlanPoste;
    depenseVariables: PlanPoste;
}

export class PlanPoste {
    poste: Select;
    list: PlanPosteForTable[];
}

export class PlanPosteForTable {
    id: number;
    idPlan: number;
    idPoste: number;
    label: string;
}

export class PlanPosteForDetail {
    id: number=null;
    idPlan: number=null;
    idPoste: number=null;
    label: string=null;
    poste: Select=null;
    referenceTable: Select=null;
    planPosteUser: PlanPosteUserForDetail[]=null;
    planPosteReference: SelectGroup[]=null;
    planPosteFrequencies: PlanPosteFrequencies = new PlanPosteFrequencies(); // PlanPosteFrequencyForDetail[]=null;

    //working
    currentAmount: number = null;
    // constructor(planPosteForDetail?: Partial<PlanPosteForDetail>) {
    //     assign(this, planPosteForDetail);
    // }
}

export class PlanPosteFrequencies {
    isYearly: boolean = null;
    yearly: PlanPosteFrequencyForDetail[]=null;
    monthly: PlanPosteFrequencyForDetail[]=null;
}

export class PlanPosteForDetailSave {
    id: number;
    idPlan: number;
    idPoste: number;
    label: string;
    referenceTable: Select[];
    planPosteUser: PlanPosteUserForDetail[];
    planPosteReference: Select[];
    planPosteFrequencies: PlanPosteFrequencyForDetail[];
}

export class PlanPosteUserForDetail {
    id: number;
    idPlanUser: number;
    user: UserForLabel;
    isSalaryEstimatedPart: boolean;
    percentagePart: number;
}

export class PlanPosteFrequencyForDetail {
    id: number;
    frequency: Frequency;
    previewAmount: number;
}

export class Frequency {
    id: number;
    number: string;
    labelLong: string;
    labelShort: string;
    languageCode: string;
    // monthNumber: number;
    // monthLabel: string;
    // monthLabelShort: string;
}

export class PlanPosteFrequencyFilter {
    idPlanPoste: number;
    isAnnualEstimation: boolean;
}


