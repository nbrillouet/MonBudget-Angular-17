import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { asRoutes } from './as.routing';
import { AsTabModule } from './tab/as-tab.module';

@NgModule({
    declarations: [

    ],
    imports     : [
        RouterModule.forChild(asRoutes),

        AsTabModule
    ],
    exports     : [

    ]
})
export class AsModule
{
}
