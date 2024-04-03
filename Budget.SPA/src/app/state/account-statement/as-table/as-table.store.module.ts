import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AsApiService } from '../as-api.service';
import { AsTableFilterSelectedState } from './as-table-filter-selected/as-table-filter-selected.state';
import { AsTableFilterSelectionState } from './as-table-filter-selection/as-table-filter-selection.state';
import { AsTableState } from './as-table.state';
import { HelperFilterService } from 'app/services/helper-filter.service';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsTableFilterSelectedState,
            AsTableFilterSelectionState,
            AsTableState
        ])
    ],
    providers:[
        HelperFilterService,
        AsApiService
    ]
})

export class AsTableStoreModule
{

}
