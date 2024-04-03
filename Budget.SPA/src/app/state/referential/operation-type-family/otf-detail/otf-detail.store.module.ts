import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { OtfDetailFilterState } from './otf-detail-filter/otf-detail-filter.state';
import { OtfDetailState } from './otf-detail.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            OtfDetailFilterState,
            OtfDetailState
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

export class OtfDetailStoreModule
{

}
