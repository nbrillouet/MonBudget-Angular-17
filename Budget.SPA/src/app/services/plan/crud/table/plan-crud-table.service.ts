import { Injectable } from '@angular/core';
import { LambdaExpression } from '@corporate/data';
import { Datas, FilterSelected, FilterSelection, Select as SelectModel, SelectCode } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterPlanTableSelected, FilterPlanTableSelection } from 'app/model/filters/plan.filter';
import { PlanForTable } from 'app/model/plan/plan.model';
import { HelperService } from 'app/services/helper.service';
import { ChangePlanTableFilterSelected } from 'app/state/plan/plan-table/plan-table-filter-selected/plan-table-filter-selected.action';
import { PlanTableFilterSelectedState } from 'app/state/plan/plan-table/plan-table-filter-selected/plan-table-filter-selected.state';
import { LoadPlanTableFilterSelection } from 'app/state/plan/plan-table/plan-table-filter-selection/plan-table-filter-selection.action';
import { PlanTableFilterSelectionState } from 'app/state/plan/plan-table/plan-table-filter-selection/plan-table-filter-selection.state';
import { PlanTableState } from 'app/state/plan/plan-table/plan-table.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PlanCrudTableService
{
    @Select(PlanTableFilterSelectedState.get) stateSelected$: Observable<FilterSelected<FilterPlanTableSelected>>;
    @Select(PlanTableFilterSelectionState.get) stateSelection$: Observable<FilterSelection<FilterPlanTableSelection>>;
    @Select(PlanTableState.get) stateTable$: Observable<Datas<PlanForTable[]>>;

    filterSelected: FilterPlanTableSelected = null;
    filterSelection: FilterPlanTableSelection = null;

    /**
     * Constructor
     */
    constructor(
        public _store: Store,
        private _authService: AuthService,
        private _helperService: HelperService
    )
    {
        this.stateSelected$.subscribe((result)=> {
            if(result?.loader['filter-selected']?.loaded) {
                this.filterSelected = result.selected;
            }
        });

        this.stateSelection$.subscribe((result)=> {
            if(result?.loader['filter-selection']?.loaded) {
                this.filterSelection = this._helperService.getDeepClone(result.selection);
                if(this.filterSelected) {
                    // if(!this.filterSelected?.account) {
                    //     this.changeFilterPlanTableSelected(x=>x.account, result.selection.account[0]);
                    // }
                    // if(!this.filterSelected?.state) {
                    //     this.changeFilterPlanTableSelected(x=>x.state, result.selection.state[0]);
                    // }
                }
            }
        });
    }

    // // -----------------------------------------------------------------------------------------------------
    // // @ Public methods
    // // -----------------------------------------------------------------------------------------------------
    public applyFilterSelected(selected: FilterPlanTableSelected): void {
        this._store.dispatch(new ChangePlanTableFilterSelected(selected));
    }

    public applyFilterSelection(selected: FilterPlanTableSelected): void {
        this._store.dispatch(new LoadPlanTableFilterSelection(selected));
    }

    public changeFilterPlanTableSelected(nameFunction: ((obj: FilterPlanTableSelected) => any) | (new(...params: any[]) => FilterPlanTableSelected), value: string | Date | boolean | number | SelectCode | SelectModel): void {
        this.filterSelected = LambdaExpression.getParameters<FilterPlanTableSelected>(nameFunction.toString(), this._helperService.getDeepClone(this.filterSelected), this._helperService.getDeepClone(value)) as FilterPlanTableSelected;
        this.applyFilterSelected(this.filterSelected);
    }

    public initFilterPlanTableSelected(): void {
        this.filterSelected = new FilterPlanTableSelected();
        this.filterSelected.user = this._helperService.getDeepClone(this._authService.user);
        this.filterSelected.year = new Date().getFullYear();

        this.applyFilterSelection(this.filterSelected);
        this.applyFilterSelected(this.filterSelected);
    }

    // public saveInAccountStatement(): void {
    //     this._store.dispatch(new SavePlanTable({ idImport: this.filterAsifSelected.idImport }));
    // }

}
