// import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { UserApiService } from '../user.api.service';
import { UserLoggedState } from './user-logged.state';

@NgModule({
    declarations: [

    ],
    imports     : [
        // HttpClientModule,
        NgxsModule.forFeature([
            UserLoggedState
        ])
    ],
    providers:[
        UserApiService
    ]
})

export class UserLoggedStoreModule { }
