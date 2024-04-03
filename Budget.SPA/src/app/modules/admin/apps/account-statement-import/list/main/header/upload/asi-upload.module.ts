import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { SharedModule } from 'app/shared/shared.module';
import { AsiUploadComponent } from './asi-upload.component';
import { AsiUploadService } from './asi-upload.service';

@NgModule({
    imports:        [SharedModule, MatIconModule],
    declarations:   [AsiUploadComponent],
    exports:        [AsiUploadComponent],
    providers:      [AsiUploadService]
})

export class AsiUploadModule {}
