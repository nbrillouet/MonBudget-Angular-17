import { Select, SelectGroup } from '@corporate/model';
import { WidgetCardChartBar } from 'app/model/chart/widget-card-chart-bar.model';
import { FilterAccountMonthYear } from 'app/model/filters/account-month-year.filter';
import { UserForAuth } from 'app/model/referential/user/user.model';

export class AsChartEvolution {
    brut: AsChartEvolutionCdb;
    noIntTransfer: AsChartEvolutionCdb;
    customOtfs: AsChartEvolutionCustomOtf;

    constructor() {
        this.brut = new AsChartEvolutionCdb();
        this.noIntTransfer = new AsChartEvolutionCdb();
        this.customOtfs = new AsChartEvolutionCustomOtf();
    }
}

export class AsChartEvolutionCdb {
    debit: WidgetCardChartBar;
    credit: WidgetCardChartBar;
    balance: WidgetCardChartBar;
}

export class AsChartEvolutionCustomOtf {
    filter: AsChartEvolutionCustomOtfFilter=null;
    widgetCardChartBars: WidgetCardChartBar[]=null;
}

export class AsChartEvolutionCustomOtfFilter {
    selected: AsChartEvolutionCustomOtfFilterSelected;
    operationTypeFamilies: SelectGroup[]= null;

    constructor() {
        this.selected = new AsChartEvolutionCustomOtfFilterSelected();
    }
}

export class AsChartEvolutionCustomOtfFilterSelected extends FilterAccountMonthYear{
    // idAccount: number = null;
    user: UserForAuth = null;
    // monthYear: MonthYear = null;
    operationTypeFamilies: Select[] = null;
}
