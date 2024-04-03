import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { SelectCode } from '@corporate/model';
import { PlanCrudTableService } from 'app/services/plan/crud/table/plan-crud-table.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'plan-crud-table-header',
    templateUrl    : './plan-crud-table-header.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class PlanCrudTableHeaderComponent implements OnInit, OnDestroy
{
    constructor(
        public _userLoggedService: UserLoggedService,
        public _planCrudTableService: PlanCrudTableService
     )
    { }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {

    }

    accountChange($event): void {
        // this._planCrudTableService.changeFilterPlanTableSelected(x=>x.account, this._planCrudTableService.filterAsifSelection.account.find(x=>x.id===$event.id));
    }

    onAsifStateChanged(state: SelectCode): void {
        // this._planCrudTableService.changeFilterPlanTableSelected(x=>x.state, state);
    }

    // saveInAccountStatement(): void {
    //     this._planCrudTableService.saveInAccountStatement();
    // }

    changeYear(year: number): void {
        this._planCrudTableService.changeFilterPlanTableSelected(x=>x.year, year);
    }
}
