import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { PlanApiService } from '../../plan.api.service';
import { PlanFollowUpAmountRealState } from './plan-follow-up-amount-real.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            PlanFollowUpAmountRealState
        ])
    ],
    providers:[
        PlanApiService
    ]
})

export class PlanFollowUpAmountRealStoreModule
{

}
