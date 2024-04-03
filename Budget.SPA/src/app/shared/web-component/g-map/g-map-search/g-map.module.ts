import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { AngularMaterialModule } from 'app/core/angular-material.module';
import { SharedModule } from 'app/shared/shared.module';
import { GMapDetailStoreModule } from 'app/state/g-map/g-map.store.module';
import { GMapSearchComponent } from './g-map-search.component';
import { GMapSearchService } from './g-map-search.service';
import { GoogleMapsModule } from '@angular/google-maps';
import { FuseCardComponent } from '@fuse/components/card';

@NgModule({
    imports: [
      CommonModule,
      SharedModule,
      AngularMaterialModule,
      NgxsFormPluginModule,
      GoogleMapsModule,
      GMapDetailStoreModule,
      FuseCardComponent
    ],
    declarations: [GMapSearchComponent],
    exports:      [GMapSearchComponent],
    providers :   [GMapSearchService]
  })
  export class GMapModule { }
