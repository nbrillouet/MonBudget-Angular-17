import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AccountApiService } from '../account.api.service';
import { AccountListState } from './account-list.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AccountListState
        ])
    ],
    providers:[
        AccountApiService

    ],
    exports: []
})

export class AccountListStoreModule
{

}
