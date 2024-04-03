import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { PlanPosteApiService } from '../plan-poste.api.service';
import { PlanPosteTableFilterSelectedState } from './plan-poste-filter-selected/plan-poste-filter-selected.state';
import { PlanPosteTableFilterSelectionState } from './plan-poste-filter-selection/plan-poste-filter-selection.state';
import { PlanPosteTableState } from './plan-poste-table.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            PlanPosteTableFilterSelectedState,
            PlanPosteTableFilterSelectionState,
            PlanPosteTableState
        ])
    ],
    providers:[
        PlanPosteApiService
    ]
})

export class PlanPosteTableStoreModule
{

}
