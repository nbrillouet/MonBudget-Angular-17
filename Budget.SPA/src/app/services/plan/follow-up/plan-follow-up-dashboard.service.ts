import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { Datas, FilterSelected, FilterSelection, SelectCode, Select as SelectModel, MonthYear } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterPlanFollowUpSelected, FilterPlanFollowUpSelection } from 'app/model/filters/plan-follow-up.filter';
import { PlanForFollowUp } from 'app/model/plan/plan-follow-up/plan-follow-up.model';
import { Plan } from 'app/model/plan/plan.model';
import { HelperService } from 'app/services/helper.service';
import { ChangePlanFollowUpFilterSelected } from 'app/state/plan/plan-follow-up/plan-follow-up-filter-selected/plan-follow-up-filter-selected.action';
import { PlanFollowUpFilterSelectedState } from 'app/state/plan/plan-follow-up/plan-follow-up-filter-selected/plan-follow-up-filter-selected.state';
import { LoadPlanFollowUpFilterSelection } from 'app/state/plan/plan-follow-up/plan-follow-up-filter-selection/plan-follow-up-filter-selection.action';
import { PlanFollowUpFilterSelectionState } from 'app/state/plan/plan-follow-up/plan-follow-up-filter-selection/plan-follow-up-filter-selection.state';
import { PlanFollowUpState } from 'app/state/plan/plan-follow-up/plan-follow-up.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PlanFollowUpDashboardService extends CorpDataReadonly<PlanForFollowUp>
{
    @Select(PlanFollowUpFilterSelectedState.get) stateSelected$: Observable<FilterSelected<FilterPlanFollowUpSelected>>;
    @Select(PlanFollowUpFilterSelectionState.get) stateSelection$: Observable<FilterSelection<FilterPlanFollowUpSelection>>;
    @Select(PlanFollowUpState.get) stateTable$: Observable<Datas<PlanForFollowUp[]>>;

    filterSelected: FilterPlanFollowUpSelected = null;
    filterSelection: FilterPlanFollowUpSelection = null;

    /**
     * Constructor
     */
    constructor(
        public _store: Store,
        private _authService: AuthService,
        private _helperService: HelperService
    )
    {
        super(PlanForFollowUp);

        this.stateTable$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['datas']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.datas, this.value)) {
                    this.value = this._helperService.getDeepClone(x.datas);
                }
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
                    if(!this.filterSelected?.monthYear) {
                        this.changeFilterPlanFollowUpSelected(x=>x.monthYear, {month: result.selection.month[12], year: result.selection.year[0] } as MonthYear);
                    }

                    // if(!this.filterSelected?.year) {
                    //     this.changeFilterPlanFollowUpSelected(x=>x.year, result.selection.year[0]);
                    // }

                    if(!this.filterSelected?.plan) {
                        const filterPlan = result.selection.plan.filter(x=>x.year===this.filterSelected?.monthYear?.year);
                        this.changeFilterPlanFollowUpSelected(x=>x.plan, filterPlan[0]);
                    }
                }
            }
        });
    }

    // // -----------------------------------------------------------------------------------------------------
    // // @ Public methods
    // // -----------------------------------------------------------------------------------------------------
    public changeYearFilterSelected(year: number): void {
        const filterSelected = this._helperService.getDeepClone(this.filterSelected) as FilterPlanFollowUpSelected;
        filterSelected.monthYear.year = year;
        filterSelected.plan = null;

        this.applyFilterSelected(filterSelected);
        this.applyFilterSelection(filterSelected);
    }

    public changeMonthFilterSelected(month: SelectModel): void {
        // this.changeFilterPlanFollowUpSelected(x=>x.month, month);
        const filterSelected = this._helperService.getDeepClone(this.filterSelected) as FilterPlanFollowUpSelected;
        filterSelected.monthYear.month = month;

        this.applyFilterSelected(filterSelected);
        this.applyFilterSelection(filterSelected);
    }

    public changePlanFilterSelected(plan: Plan): void {

        const filterSelected = this._helperService.getDeepClone(this.filterSelected) as FilterPlanFollowUpSelected;
        filterSelected.plan = plan;

        this.applyFilterSelected(filterSelected);
        this.applyFilterSelection(filterSelected);
    }

    public applyFilterSelected(selected: FilterPlanFollowUpSelected): void {
        this._store.dispatch(new ChangePlanFollowUpFilterSelected(selected));
    }

    public applyFilterSelection(selected: FilterPlanFollowUpSelected): void {
        this._store.dispatch(new LoadPlanFollowUpFilterSelection(selected));
    }

    public changeFilterPlanFollowUpSelected(nameFunction: ((obj: FilterPlanFollowUpSelected) => any) | (new(...params: any[]) => FilterPlanFollowUpSelected), value: string | Date | boolean | number | SelectCode | any ): void {
        this.filterSelected = LambdaExpression.getParameters<FilterPlanFollowUpSelected>(nameFunction.toString(), this._helperService.getDeepClone(this.filterSelected), this._helperService.getDeepClone(value)) as FilterPlanFollowUpSelected;
        this.applyFilterSelected(this.filterSelected);
    }

    public changePlanFollowUpSelected(): void {
        if(!this.filterSelected) {
            this.filterSelected = new FilterPlanFollowUpSelected();
            this.filterSelected.user = this._helperService.getDeepClone(this._authService.user);
        }

        this.applyFilterSelection(this.filterSelected);
        this.applyFilterSelected(this.filterSelected);
    }



}
