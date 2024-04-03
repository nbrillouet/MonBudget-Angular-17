import { Component, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatTableFilter } from '@corporate/mat-table-filter';
import { FilterPlanNotAsTableSelected } from 'app/model/filters/plan-not-as.filter';
import { HelperService } from 'app/services/helper.service';
import { AS_MODEL_PNAS_COLUMNS } from 'app/services/plan/crud/detail/plan-not-as/table/plan-not-as-table.constants';
import { PlanNotAsTableService } from 'app/services/plan/crud/detail/plan-not-as/table/plan-not-as-table.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';


@Component({
    selector       : 'plan-not-as-table',
    templateUrl    : './plan-not-as-table.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class PlanNotAsTableComponent implements OnInit, OnDestroy
{
    @Input() idPlan: number;
    matTableFilter: MatTableFilter;

    constructor(
        public _userLoggedService: UserLoggedService,
        public _planNotAsTableService: PlanNotAsTableService,
        public _helperService: HelperService
     )
    {
        this.matTableFilter = {
            columns: AS_MODEL_PNAS_COLUMNS,
            filterSelection$: this._planNotAsTableService.stateSelection$,
            filterSelected$: this._planNotAsTableService.stateSelected$,
            table$: this._planNotAsTableService.stateTable$
        };
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        this._planNotAsTableService.initFilterSelected(this.idPlan);
    }

    applyFilterSelected(selected: FilterPlanNotAsTableSelected): void {
        this._planNotAsTableService.applyFilterSelected(selected);
    }

    applyFilterSelection(selected: FilterPlanNotAsTableSelected): void {
        this._planNotAsTableService.applyFilterSelection(selected);
    }

    onRowClick($event): void {

    }
}
