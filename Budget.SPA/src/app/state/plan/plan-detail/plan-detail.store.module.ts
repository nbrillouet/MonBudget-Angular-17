import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { PlanApiService } from '../plan.api.service';
import { PlanDetailState } from './plan-detail.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            PlanDetailState
            // AsifDetailState
        ])
    ],
    providers:[
        PlanApiService,
        // ReferentialService,
        // OperationService,
        // OperationTransverseService,
        // OtService,
        // OtfService
    ],
    exports: []
})

export class PlanDetailStoreModule
{

}
