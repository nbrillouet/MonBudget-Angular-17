import { MonthYear, Select } from '@corporate/model';
import { Plan } from '../plan/plan.model';
import { UserForAuth } from '../referential/user/user.model';

export class FilterPlanFollowUpSelected {
    user: UserForAuth = null;
    plan: Plan = null;
    monthYear: MonthYear = null;
    // month: Select = null;
    // year: number = null;
}

export class FilterPlanFollowUpSelection {
    month: Select[] = null;
    year: number[] = null;
    plan: Plan[] = null;
}
