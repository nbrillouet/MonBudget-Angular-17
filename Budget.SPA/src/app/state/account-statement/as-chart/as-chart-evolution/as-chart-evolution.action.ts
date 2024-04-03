import { AsChartEvolutionCustomOtfFilterSelected } from 'app/model/account-statement/as-chart/as-chart-evolution.model';
import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';

export const AS_CHART_EVOLUTION_LOAD = 'as-chart-evolution-load';
export const AS_CHART_EVOLUTION_BRUT_LOAD = 'as-chart-evolution-brut-load';
export const AS_CHART_EVOLUTION_NO_INT_TRANSFER_LOAD = 'as-chart-evolution-no-int-transfer-load';
export const AS_CHART_EVOLUTION_CUSTOM_OTF_LOAD = 'as-chart-evolution-custom-otf-load';
// export const AS_CHART_EVOLUTION_CUSTOM_OTF_FILTER_LOAD = 'as-chart-evolution-custom-otf-filter-load';
export const AS_CHART_EVOLUTION_CUSTOM_OTF_FILTER_CHANGE = 'as-chart-evolution-custom-otf-filter-change';
export const AS_CHART_EVOLUTION_CUSTOM_OTF_FILTER_UPDATE = 'as-chart-evolution-custom-otf-filter-update';

export class LoadAsChartEvolution {
    static readonly type = AS_CHART_EVOLUTION_LOAD;

    constructor(public payload: FilterAsMainSelected) { }
}

export class LoadAsChartEvolutionBrut {
    static readonly type = AS_CHART_EVOLUTION_BRUT_LOAD;

    constructor(public payload: FilterAsMainSelected) { }
}

export class LoadAsChartEvolutionNoIntTransfer {
    static readonly type = AS_CHART_EVOLUTION_NO_INT_TRANSFER_LOAD;

    constructor(public payload: FilterAsMainSelected) { }
}

export class LoadAsChartEvolutionCustomOtf {
    static readonly type = AS_CHART_EVOLUTION_CUSTOM_OTF_LOAD;

    constructor(public payload: FilterAsMainSelected) { }
}

// export class LoadAsChartEvolutionCustomOtfFilter {
//     static readonly type = AS_CHART_EVOLUTION_CUSTOM_OTF_FILTER_LOAD;

//     constructor(public payload: FilterAsMainSelected) { }
// }

export class ChangeAsChartEvolutionCustomOtfFilter {
    static readonly type = AS_CHART_EVOLUTION_CUSTOM_OTF_FILTER_CHANGE;

    constructor(public payload: FilterAsMainSelected) { }
}

export class UpdateAsChartEvolutionCustomOtfFilter {
    static readonly type = AS_CHART_EVOLUTION_CUSTOM_OTF_FILTER_UPDATE;

    constructor(public payload: AsChartEvolutionCustomOtfFilterSelected) { }
}
// AsChartEvolutionCustomOtfFilterSelected
