// import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { UserApiService } from '../user.api.service';
import { UserDetailState } from './user-detail.state';

@NgModule({
    declarations: [

    ],
    imports     : [
        NgxsModule.forFeature([
            UserDetailState
        ])
    ],
    providers:[
        UserApiService
    ]
})

export class UserDetailStoreModule { }
