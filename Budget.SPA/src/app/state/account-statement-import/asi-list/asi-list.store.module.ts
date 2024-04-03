import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AsifTableService } from 'app/services/account-statement/account-statement-import-file/table/asif-table.service';
import { AsifTableState } from 'app/state/account-statement-import-file/asif-table/asif-table.state';
import { UserDetailState } from 'app/state/user/user-detail/user-detail.state';
import { AsiApiService } from '../asi.api.service';
import { AsiFolderExplorerState } from './asi-list.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsiFolderExplorerState,
            AsifTableState
        ])
    ],
    providers:[
        AsiApiService,
        AsifTableService
    ],
    exports: []
})

export class AsiListStoreModule
{

}
