import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'app/shared/shared.module';
import { MatSidenavModule } from '@angular/material/sidenav';
import { asiRoutes } from './asi.routing';
import { NgModule } from '@angular/core';
import { AsiDataModule } from 'app/services/account-statement/account-statement-import/asi.data.module';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { AsiListComponent } from './list/main/content/asi-list.component';
import { AsiMainComponent } from './list/main/asi-main.component';
import { AsiHeaderComponent } from './list/main/header/asi-header.component';
import { AsiUploadModule } from './list/main/header/upload/asi-upload.module';
import { FuseScrollbarDirective } from '@fuse/directives/scrollbar';

@NgModule({
    declarations: [
        AsiHeaderComponent,
        AsiListComponent,
        AsiMainComponent
    ],
    imports     : [
        RouterModule.forChild(asiRoutes),
        MatButtonModule,
        MatIconModule,
        MatSidenavModule,
        MatTooltipModule,
        MatProgressBarModule,
        MatTabsModule,
        SharedModule,
        FuseScrollbarDirective,

        AsiDataModule,
        AsiUploadModule
    ],
    exports     : [

    ]
})
export class AsiModule
{
}
