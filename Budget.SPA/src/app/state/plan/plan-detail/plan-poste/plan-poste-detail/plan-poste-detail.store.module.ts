import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { ReferentialService } from 'app/services/referential/referential.service';
import { PlanPosteApiService } from '../plan-poste.api.service';
import { PlanPosteDetailFilterState } from './plan-poste-detail-filter/plan-poste-detail-filter.state';
import { PlanPosteDetailState } from './plan-poste-detail.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            PlanPosteDetailState,
            PlanPosteDetailFilterState
        ])
    ],
    providers:[
        ReferentialService,
        PlanPosteApiService
    ]
})

export class PlanPosteDetailStoreModule
{

}
