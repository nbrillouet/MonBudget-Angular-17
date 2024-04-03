import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AuthApiService } from './auth.api.service';
import { AuthState } from './auth.state';

@NgModule({
    declarations: [

    ],
    imports     : [
        NgxsModule.forFeature([
            AuthState
        ])
    ],
    providers:[
        AuthApiService
    ]
})

export class AuthStoreModule
{

}
