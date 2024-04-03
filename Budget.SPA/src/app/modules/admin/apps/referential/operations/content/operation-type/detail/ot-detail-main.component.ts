import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config';
import { OtForDetail } from 'app/model/referential/operation-type.model';
import { OtDetailService } from 'app/services/referential/operations/operation-type/detail/ot-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'ot-detail-main',
    templateUrl    : './ot-detail-main.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class OtDetailMainComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: OtForDetail = null;

    constructor(
        private _activatedRoute: ActivatedRoute,
        public _userLoggedService: UserLoggedService,
        public _otDetailService: OtDetailService,
        public _fuseConfigService: FuseConfigService

     )
    {
        super();
        this.property = this._otDetailService.form.model as OtForDetail;
    }

    ngOnDestroy(): void
    {
        this._otDetailService.destroyForm();
    }

    ngOnInit(): void {

    }
}
