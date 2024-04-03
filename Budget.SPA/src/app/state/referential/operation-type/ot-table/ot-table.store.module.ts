import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { OtApiService } from '../ot.api.service';
import { OtTableFilterSelectedState } from './ot-table-filter-selected/ot-table-filter-selected.state';
import { OtTableFilterSelectionState } from './ot-table-filter-selection/ot-table-filter-selection.state';
import { OtTableState } from './ot-table.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            OtTableFilterSelectedState,
            OtTableFilterSelectionState,
            OtTableState
        ])
    ],
    providers:[
        OtApiService,
        // AssetService
    ]
})

export class OtTableStoreModule
{

}
