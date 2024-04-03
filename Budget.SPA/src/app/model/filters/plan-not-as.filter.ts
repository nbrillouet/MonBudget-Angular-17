import { FilterAsTableSelected, FilterAsTableSelection } from './account-statement.filter';

export class FilterFixedPlanNotAsTableSelected {
    idPlan: number;
    idUserGroup: number;
}

export class FilterPlanNotAsTableSelected extends FilterAsTableSelected {

}

export class FilterPlanNotAsTableGroupSelected {
    filterFixedPlanNotAsTableSelected: FilterFixedPlanNotAsTableSelected;
    filterPlanNotAsTableSelected: FilterPlanNotAsTableSelected;
}

export class FilterPlanNotAsTableSelection extends FilterAsTableSelection {

    constructor() {
        super();
    }
}
