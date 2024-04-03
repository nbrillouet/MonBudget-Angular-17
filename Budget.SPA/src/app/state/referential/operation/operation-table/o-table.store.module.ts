import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { OApiService } from '../o.api.service';
import { OTableFilterSelectedState } from './operation-table-filter-selected/operation-table-filter-selected.state';
import { OTableFilterSelectionState } from './operation-table-filter-selection/operation-table-filter-selection.state';
import { OTableState } from './operation-table.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            OTableFilterSelectedState,
            OTableFilterSelectionState,
            OTableState
        ])
    ],
    providers:[
        OApiService
    ]
})
export class OTableStoreModule
{

}
