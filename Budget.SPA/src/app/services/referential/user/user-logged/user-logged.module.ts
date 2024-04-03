import { NgModule } from '@angular/core';
import { NavigationModule } from 'app/core/navigation/navigation.module';
import { UserLoggedService } from './user-logged.service';
import { UserLoggedStoreModule } from 'app/state/user/user-logged/user-logged.store.module';

@NgModule({
    imports  : [
        UserLoggedStoreModule,

        NavigationModule
    ],
    providers: [
        UserLoggedService
    ]
})
export class UserLoggedModule { }
