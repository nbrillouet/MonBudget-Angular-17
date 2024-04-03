import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableFilter } from '@corporate/mat-table-filter';
import { FilterPlanTableSelected } from 'app/model/filters/plan.filter';
import { HelperService } from 'app/services/helper.service';
import { PLAN_COLUMNS } from 'app/services/plan/crud/table/constants';
import { PlanCrudTableService } from 'app/services/plan/crud/table/plan-crud-table.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'plan-crud-table-main',
    templateUrl    : './plan-crud-table-main.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class PlanCrudTableMainComponent implements OnInit, OnDestroy
{
    matTableFilter: MatTableFilter = new MatTableFilter();
    idFile: number;

    constructor(
        private _router: Router,
        public _userLoggedService: UserLoggedService,
        public _planCrudTableService: PlanCrudTableService,
        public _helperService: HelperService
     )
    {
        this.matTableFilter = {
            columns: PLAN_COLUMNS,
            filterSelection$: this._planCrudTableService.stateSelection$,
            filterSelected$: this._planCrudTableService.stateSelected$,
            table$: this._planCrudTableService.stateTable$,
            toolbar: { buttonAdd: {enabled: true }, buttonDelete: {enabled:true}, buttonFullscreen: {enabled:false} },
            clickOnRow: true
        };

    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        this._planCrudTableService.initFilterPlanTableSelected();
        // this._activatedRoute.params.subscribe((routeParams) => {
        //     this.idFile = routeParams['idFile'];
        //     this._asifTableService.initFilterAsifTableSelected(this.idFile);
        // });
    }

    addItem($event): void {
        this._router.navigate(['apps/plans/create/detail']);
    }

    deleteItems($event): void {

    }

    onRowClick(row): void {
        this._router.navigate([`apps/plans/${row.id}/detail`]);
    }

    applyFilterSelected(selected: FilterPlanTableSelected): void {
        this._planCrudTableService.applyFilterSelected(selected);
    }

    applyFilterSelection(selected: FilterPlanTableSelected): void {
        this._planCrudTableService.applyFilterSelection(selected);
    }

}
