import { Pagination } from '@corporate/mat-table-filter';
import { ComboMultiple, ComboSimple, Select, SelectGroup } from '@corporate/model';
import { assign } from 'lodash';
import { PlanPosteFrequencyForDetail, PlanPosteUserForDetail } from '../plan/plan-poste/plan-poste.model';

export class FilterPlanPosteTableSelected {
    idPlan: number;
    idPoste: number;
    label: string;
    pagination: Pagination;

    constructor(filterPlanPosteTableSelected?: Partial<FilterPlanPosteTableSelected>) {
        assign(this, filterPlanPosteTableSelected);
        this.pagination=new Pagination();
    }

    // constructor() {
    //     this.pagination = new Pagination();
    // }
    // constructor(idPlan: number, idPoste: number) {
    // }
}

export class FilterPlanPosteTableSelection {

    constructor() {  }
}

export class PlanPosteDetailFilter {
    id: number = null;
    idPlan: number = null;
    idPoste: number = null;
    idUserGroup: number = null;

    constructor(planPosteDetailFilter?: Partial<PlanPosteDetailFilter>) {
        assign(this, planPosteDetailFilter);
    }
}

export class FilterPlanPosteDetail {
    // poste: Select=null;
    referenceTable: Select[]=null;
    // planPosteUser: PlanPosteUserForDetail[]=null;
    planPosteReference: SelectGroup[]=null;
//     accounts: ComboMultiple<SelectGroup>=null;
//     planPosteFrequencies: PlanPosteFrequencyForDetail[]=null;
}

export class PlanPosteReferenceFilter {
    // idPlanPoste: number;
    idReferenceTable: number;
    idPoste: number;
    idUserGroup: number;
}
