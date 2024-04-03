import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FuseScrollResetDirective } from '@fuse/directives/scroll-reset';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { OtfModule } from './content/operation-type-family/otf.module';
import { OtModule } from './content/operation-type/ot.module';
import { OModule } from './content/operation/o.module';
import { OperationsHeaderComponent } from './header/operations-header.component';
import { OperationsComponent } from './operations.component';
import { operationsRoutes } from './operations.routing';
import { OperationsService } from 'app/services/referential/operations/operations.service';

@NgModule({
    declarations: [
        OperationsHeaderComponent,
        OperationsComponent
    ],
    imports     : [
        RouterModule.forChild(operationsRoutes),

        AngularMaterialModule,
        SharedModule,
        FuseScrollbarDirective,
        FuseScrollResetDirective,

        OtfModule,
        OtModule,
        OModule
        // OtTableModule
    ],
    providers: [
        OperationsService
    ]
})

export class OperationsModule
{
}
