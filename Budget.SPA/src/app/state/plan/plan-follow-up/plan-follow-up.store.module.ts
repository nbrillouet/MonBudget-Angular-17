import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { PlanApiService } from '../plan.api.service';
import { PlanFollowUpFilterSelectedState } from './plan-follow-up-filter-selected/plan-follow-up-filter-selected.state';
import { PlanFollowUpFilterSelectionState } from './plan-follow-up-filter-selection/plan-follow-up-filter-selection.state';
import { PlanFollowUpState } from './plan-follow-up.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            PlanFollowUpFilterSelectedState,
            PlanFollowUpFilterSelectionState,
            PlanFollowUpState
        ])
    ],
    providers:[
        PlanApiService
    ]
})

export class PlanFollowUpStoreModule
{

}
