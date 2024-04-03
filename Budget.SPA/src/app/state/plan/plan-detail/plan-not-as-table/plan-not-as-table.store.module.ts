import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { PlanApiService } from '../../plan.api.service';
import { PlanNotAsTableFilterSelectedState } from './plan-not-as-table-filter-selected/plan-not-as-table-filter-selected.state';
import { PlanNotAsTableFilterSelectionState } from './plan-not-as-table-filter-selection/plan-not-as-table-filter-selection.state';
import { PlanNotAsTableState } from './plan-not-as-table.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            PlanNotAsTableFilterSelectedState,
            PlanNotAsTableFilterSelectionState,
            PlanNotAsTableState
        ])
    ],
    providers:[
        PlanApiService
    ],
    exports: []
})

export class PlanNotAsTableStoreModule
{

}
