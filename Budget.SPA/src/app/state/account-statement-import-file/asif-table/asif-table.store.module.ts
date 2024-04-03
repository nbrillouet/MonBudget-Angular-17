import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AsifApiService } from '../asif.api.service';
import { AsifTableFilterSelectedState } from './asif-table-filter-selected/asif-table-filter-selected.state';
import { AsifTableFilterSelectionState } from './asif-table-filter-selection/asif-table-filter-selection.state';
import { AsifTableState } from './asif-table.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsifTableFilterSelectedState,
            AsifTableFilterSelectionState,
            AsifTableState
        ])
    ],
    providers:[
        AsifApiService
    ]
})

export class AsifTableStoreModule
{

}
