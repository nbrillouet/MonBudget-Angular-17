import { ComboMultiple, Select, SelectGroup } from '@corporate/model';

export class Plan {
    id: number = null;
    label: string = null;
    year: number = null;
    color: string = null;
}

export class PlanForTable extends Plan {
    // datas : Plan[];
    // comboYear: ComboSimple<ISelect>;
}

export class PlanForDetail {
    plan: Plan = new Plan();
    users: ComboMultiple<Select> = new ComboMultiple<Select>();
    accounts: ComboMultiple<SelectGroup> = new ComboMultiple<SelectGroup>();
    planNotAsCount: number = null;
}
