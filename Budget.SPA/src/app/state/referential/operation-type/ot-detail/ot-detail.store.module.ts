import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { OtDetailFilterState } from './ot-detail-filter/ot-detail-filter.state';
import { OtDetailState } from './ot-detail.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            OtDetailFilterState,
            OtDetailState
        ])
    ],
    providers:[
        // AccountApiService,
        // ReferentialService,
        // BankSubFamilyService,
        // BankAgencyService
    ],
    exports: []
})

export class OtDetailStoreModule
{

}
