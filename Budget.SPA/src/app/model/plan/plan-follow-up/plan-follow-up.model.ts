import { SelectCode, SelectYear } from '@corporate/model';

export class PlanForFollowUpValue {
    amountReal: number = null;
    amountPreview: number = null;
    gaugeValue: number = null;
}

export class PlanForFollowUpPlanPosteValue extends PlanForFollowUpValue{
    isAnnualPreview: boolean;
}

export class PlanForFollowUp extends PlanForFollowUpValue {
    plan: SelectYear = null;
    postes: PosteForFollowUp[] = null;
}

export class PosteForFollowUp extends PlanForFollowUpValue {
    poste: SelectCode =  null;
    planPostes: PlanPosteForFollowUp[] = null;
}

export class PlanPosteForFollowUp extends PlanForFollowUpPlanPosteValue {
    idPlanPoste: number = null;
    label: string = null;
    planPostesUsers: PlanPosteUserForFollowUp[] = null;
}

export class PlanPosteUserForFollowUp extends PlanForFollowUpValue {
    firstName: string = null;
    percentage: number = null;
}

