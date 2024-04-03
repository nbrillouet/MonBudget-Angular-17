import { Injectable } from '@angular/core';
import { Datas, FilterSelected, FilterSelection } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterPlanPosteTableSelected, FilterPlanPosteTableSelection } from 'app/model/filters/plan-poste.filter';
import { FilterPlanTableSelected, FilterPlanTableSelection } from 'app/model/filters/plan.filter';
import { PlanPosteForTable } from 'app/model/plan/plan-poste/plan-poste.model';
import { HelperService } from 'app/services/helper.service';
import { ChangePlanPosteTableFilterSelected } from 'app/state/plan/plan-detail/plan-poste/plan-poste-table/plan-poste-filter-selected/plan-poste-filter-selected.action';
import { PlanPosteTableFilterSelectedState } from 'app/state/plan/plan-detail/plan-poste/plan-poste-table/plan-poste-filter-selected/plan-poste-filter-selected.state';
import { LoadPlanPosteTableFilterSelection } from 'app/state/plan/plan-detail/plan-poste/plan-poste-table/plan-poste-filter-selection/plan-poste-filter-selection.action';
import { PlanPosteTableFilterSelectionState } from 'app/state/plan/plan-detail/plan-poste/plan-poste-table/plan-poste-filter-selection/plan-poste-filter-selection.state';
import { DeletePlanPosteTable } from 'app/state/plan/plan-detail/plan-poste/plan-poste-table/plan-poste-table.action';
import { PlanPosteTableState } from 'app/state/plan/plan-detail/plan-poste/plan-poste-table/plan-poste-table.state';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({ providedIn: 'root' })
export class PlanPosteTableService
{
    @Select(PlanPosteTableFilterSelectedState.get) stateSelected$: Observable<FilterSelected<FilterPlanPosteTableSelected>>;
    @Select(PlanPosteTableFilterSelectionState.get) stateSelection$: Observable<FilterSelection<FilterPlanPosteTableSelection>>;
    @Select(PlanPosteTableState.get) stateTable$: Observable<Datas<PlanPosteForTable[]>>;

    filterSelected: FilterPlanPosteTableSelected = null;
    filterSelection: FilterPlanPosteTableSelection = null;
    isDeleted: boolean= null;

    /**
     * Constructor
     */
    constructor(
        public _store: Store,
        private _authService: AuthService,
        private _helperService: HelperService
    )
    {
        this.stateTable$.subscribe((result)=> {
            if(result?.loader['datas-delete']?.loaded) {
                this.isDeleted=true;
            }
        });

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

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------
    public initFilterSelected(idPlan: number, idPoste: number): void {
        this.filterSelected = new FilterPlanPosteTableSelected(
            {idPlan: idPlan, idPoste: idPoste}
        );

        this.applyFilterSelection(this.filterSelected);
        this.applyFilterSelected(this.filterSelected);
    }

    public applyFilterSelected(selected: FilterPlanPosteTableSelected): void {
        this._store.dispatch(new ChangePlanPosteTableFilterSelected(selected));
    }

    public applyFilterSelection(selected: FilterPlanPosteTableSelected): void {
        this._store.dispatch(new LoadPlanPosteTableFilterSelection(selected));
    }

    public delete(idPlanPosteList: number[]): void {
        this._store.dispatch(new DeletePlanPosteTable({idPlanPosteList: idPlanPosteList, filterSelected: this.filterSelected}));
    }

    public reloadTable(): void {
        this.applyFilterSelected(this.filterSelected);
    }


}


