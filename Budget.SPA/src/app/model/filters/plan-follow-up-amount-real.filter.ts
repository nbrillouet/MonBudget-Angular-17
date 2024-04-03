import { MonthYear } from '@corporate/model';
import { assign } from 'lodash';

export class PlanFollowUpAmountRealFilter {
    monthYear: MonthYear=null;
    idPlanPoste: number=null;
    idPlan: number=null;
    idPoste: number=null;

    constructor(planPosteDetailFilter?: Partial<PlanFollowUpAmountRealFilter>) {
        assign(this, planPosteDetailFilter);
    }
}
