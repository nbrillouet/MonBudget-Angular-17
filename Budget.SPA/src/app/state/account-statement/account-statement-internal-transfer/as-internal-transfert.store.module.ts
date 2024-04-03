import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { AsApiService } from '../as-api.service';
import { AsInternalTransfertState } from './as-internal-transfert.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsInternalTransfertState
        ])
    ],
    providers:[
        AsApiService
    ]
})

export class AsInternalTransfertStoreModule
{

}
