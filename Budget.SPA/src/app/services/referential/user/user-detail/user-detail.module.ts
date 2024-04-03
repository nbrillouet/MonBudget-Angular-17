import { NgModule } from '@angular/core';
import { UserDetailStoreModule } from 'app/state/user/user-detail/user-detail.store.module';
import { UserDetailService } from './user-detail.service';

@NgModule({
    imports  : [
        UserDetailStoreModule
    ],
    providers: [
        UserDetailService
    ]
})
export class UserDetailModule { }
