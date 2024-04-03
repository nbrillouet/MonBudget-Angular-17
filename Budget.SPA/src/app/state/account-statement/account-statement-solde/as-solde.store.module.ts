import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AsApiService } from '../as-api.service';
import { AsSoldeState } from './account-statement-solde.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsSoldeState
        ])
    ],
    providers:[
        AsApiService
    ]
})

export class AsSoldeStoreModule
{

}
