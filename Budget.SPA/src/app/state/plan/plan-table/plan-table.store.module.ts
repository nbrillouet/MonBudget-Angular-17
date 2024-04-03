import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { PlanApiService } from '../plan.api.service';
import { PlanTableFilterSelectedState } from './plan-table-filter-selected/plan-table-filter-selected.state';
import { PlanTableFilterSelectionState } from './plan-table-filter-selection/plan-table-filter-selection.state';
import { PlanTableState } from './plan-table.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            PlanTableFilterSelectedState,
            PlanTableFilterSelectionState,
            PlanTableState
        ])
    ],
    providers:[
        PlanApiService
    ]
})

export class PlanTableStoreModule
{

}
