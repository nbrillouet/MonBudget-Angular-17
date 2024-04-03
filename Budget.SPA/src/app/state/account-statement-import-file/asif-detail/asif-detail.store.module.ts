import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { OperationTransverseService } from 'app/services/referential/operation-tranverse.service';
import { ReferentialService } from 'app/services/referential/referential.service';
import { OtfApiService } from 'app/state/referential/operation-type-family/otf-api.service';
import { OtApiService } from 'app/state/referential/operation-type/ot.api.service';
import { OApiService } from 'app/state/referential/operation/o.api.service';
import { AsifApiService } from '../asif.api.service';
import { AsifDetailFilterState } from './asif-detail-filter/asif-detail-filter.state';
import { AsifDetailState } from './asif-detail.state';

@NgModule({
    declarations: [],
    imports     : [
        NgxsModule.forFeature([
            AsifDetailFilterState,
            AsifDetailState
        ])
    ],
    providers:[
        AsifApiService,
        ReferentialService,
        OApiService,
        OperationTransverseService,
        OtApiService,
        OtfApiService
    ],
    exports: []
})

export class AsifDetailStoreModule
{

}
