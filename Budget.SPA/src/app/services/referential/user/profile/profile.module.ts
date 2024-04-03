import { NgModule } from '@angular/core';
import { UserDetailStoreModule } from 'app/state/user/user-detail/user-detail.store.module';
import { ProfileService } from 'app/services/referential/user/profile/profile.service';
import { UserDetailModule } from 'app/services/referential/user/user-detail/user-detail.module';

@NgModule({
    imports  : [
        UserDetailStoreModule,
        UserDetailModule
    ],
    providers: [
        ProfileService
    ]
})
export class ProfileCommonModule { }
