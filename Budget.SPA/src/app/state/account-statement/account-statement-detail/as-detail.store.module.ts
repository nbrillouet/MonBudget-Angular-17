import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { OperationTransverseService } from 'app/services/referential/operation-tranverse.service';
import { ReferentialService } from 'app/services/referential/referential.service';
import { OtfApiService } from 'app/state/referential/operation-type-family/otf-api.service';
import { OtApiService } from 'app/state/referential/operation-type/ot.api.service';
import { OApiService } from 'app/state/referential/operation/o.api.service';
import { AsApiService } from '../as-api.service';
import { AsDetailFilterState } from './as-detail-filter/as-detail-filter.state';
import { AsDetailState } from './as-detail.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsDetailFilterState,
            AsDetailState
        ])
    ],
    providers:[
        AsApiService,
        ReferentialService,
        OApiService,
        OperationTransverseService,
        OtApiService,
        OtfApiService
    ],
    exports: []
})

export class AsDetailStoreModule
{

}
