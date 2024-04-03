import { Injectable } from '@angular/core';
import { Datas, FilterSelected, FilterSelection } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { AsForTable } from 'app/model/account-statement/account-statement-table.model';
import { FilterPlanNotAsTableGroupSelected, FilterPlanNotAsTableSelected, FilterPlanNotAsTableSelection } from 'app/model/filters/plan-not-as.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeAsTableFilterSelection } from 'app/state/account-statement/as-table/as-table-filter-selection/as-table-filter-selection.action';
import { ChangePlanNotAsTableFilterSelected } from 'app/state/plan/plan-detail/plan-not-as-table/plan-not-as-table-filter-selected/plan-not-as-table-filter-selected.action';
import { PlanNotAsTableFilterSelectedState } from 'app/state/plan/plan-detail/plan-not-as-table/plan-not-as-table-filter-selected/plan-not-as-table-filter-selected.state';
import { ChangePlanNotAsTableFilterSelection } from 'app/state/plan/plan-detail/plan-not-as-table/plan-not-as-table-filter-selection/plan-not-as-table-filter-selection.action';
import { PlanNotAsTableFilterSelectionState } from 'app/state/plan/plan-detail/plan-not-as-table/plan-not-as-table-filter-selection/plan-not-as-table-filter-selection.state';
import { PlanNotAsTableState } from 'app/state/plan/plan-detail/plan-not-as-table/plan-not-as-table.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PlanNotAsTableService
{
    @Select(PlanNotAsTableFilterSelectedState.get) stateSelected$: Observable<FilterSelected<FilterPlanNotAsTableSelected>>;
    @Select(PlanNotAsTableFilterSelectionState.get) stateSelection$: Observable<FilterSelection<FilterPlanNotAsTableSelection>>;
    @Select(PlanNotAsTableState.get) stateTable$: Observable<Datas<AsForTable[]>>;

    filterSelected: FilterPlanNotAsTableSelected = null;
    filterSelection: FilterPlanNotAsTableSelection = null;
    filterPlanNotAsGroupSelected: FilterPlanNotAsTableGroupSelected = null;
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
                this.filterPlanNotAsGroupSelected.filterPlanNotAsTableSelected = result.selected;
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

        this.stateTable$.subscribe((result)=> {
            if(result?.loader['datas']?.loaded) {

            }
        });

        // this.stateSelected$.subscribe((selected)=>{
        //     if(selected?.loader['filter-selected']?.loaded) {
        //       this.filterPlanNotAsGroupSelected.filterPlanNotAsTableSelected = selected.selected;
        //     }
        //   });
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------
    public initFilterSelected(idPlan: number): void {
        this.filterPlanNotAsGroupSelected = new FilterPlanNotAsTableGroupSelected();
        this.filterPlanNotAsGroupSelected.filterFixedPlanNotAsTableSelected = {idPlan: idPlan, idUserGroup: this._authService.user.idUserGroup};

        this.filterPlanNotAsGroupSelected.filterPlanNotAsTableSelected = new FilterPlanNotAsTableSelected();
        this.filterPlanNotAsGroupSelected.filterPlanNotAsTableSelected.user = this._authService.user;

        this.applyFilterSelection(this.filterPlanNotAsGroupSelected.filterPlanNotAsTableSelected);
        this.applyFilterSelected(this.filterPlanNotAsGroupSelected.filterPlanNotAsTableSelected);
    }

    public applyFilterSelected(selected: FilterPlanNotAsTableSelected): void {
        this.filterPlanNotAsGroupSelected.filterPlanNotAsTableSelected = selected;
        this._store.dispatch(new ChangePlanNotAsTableFilterSelected(this.filterPlanNotAsGroupSelected));
    }

    public applyFilterSelection(selected: FilterPlanNotAsTableSelected): void {
        this._store.dispatch(new ChangePlanNotAsTableFilterSelection(selected));
    }

}
