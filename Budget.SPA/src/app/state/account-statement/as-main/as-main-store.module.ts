import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AsApiService } from '../as-api.service';
import { AsMainFilterSelectedState } from './as-main-filter-selected/as-main-filter-selected.state';
import { AsMainFilterSelectionState } from './as-main-filter-selection/as-main-filter-selection.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsMainFilterSelectedState,
            AsMainFilterSelectionState
        ])
    ],
    providers:[
        AsApiService
    ]
})

export class AsMainStoreModule
{

}
