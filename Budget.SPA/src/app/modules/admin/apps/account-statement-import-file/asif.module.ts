import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { asifRoutes } from './asif.routing';
import { AsifTableModule } from './table/asif-table.module';
import { AsifDetailModule } from './detail/asif-detail.module';

@NgModule({
    declarations: [

    ],
    imports     : [
        RouterModule.forChild(asifRoutes),
        AsifTableModule,
        AsifDetailModule
     ]
})
export class AsifModule
{
}
