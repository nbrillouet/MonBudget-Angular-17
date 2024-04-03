import { NgModule } from '@angular/core';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { NgxsModule } from '@ngxs/store';
import { GMapApiService } from './g-map.api.service';
import { GMapDetailState } from './g-map.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            GMapDetailState
        ])
        // NgxsFormPluginModule
    ],
    providers:[
        GMapApiService
    ]
})

export class GMapDetailStoreModule
{

}
