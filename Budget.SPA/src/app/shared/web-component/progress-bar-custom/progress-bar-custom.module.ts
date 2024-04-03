import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { ProgressBarCustomComponent } from './progress-bar-custom.component';

@NgModule({
    imports: [
      CommonModule,
    //   SharedModule,
      AngularMaterialModule
    ],
    declarations: [ProgressBarCustomComponent],
    exports:      [ProgressBarCustomComponent],
    providers :   []
  })
  export class ProgressBarCustomModule { }
