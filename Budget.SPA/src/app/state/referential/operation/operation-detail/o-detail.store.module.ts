import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { ODetailState } from './o-detail.state';
import { ODetailFilterState } from './operation-detail-filter/o-detail-filter.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            ODetailFilterState,
            ODetailState
        ])
    ],
    providers:[],
    exports: []
})

export class ODetailStoreModule
{

}
