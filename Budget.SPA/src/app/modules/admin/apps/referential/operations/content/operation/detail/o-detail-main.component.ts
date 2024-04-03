import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config';
import { OForDetail } from 'app/model/referential/operation.model';
import { ODetailService } from 'app/services/referential/operations/operation/detail/o-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'o-detail-main',
    templateUrl    : './o-detail-main.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class ODetailMainComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: OForDetail = null;

    constructor(
        private _activatedRoute: ActivatedRoute,
        public _userLoggedService: UserLoggedService,
        public _oDetailService: ODetailService,
        public _fuseConfigService: FuseConfigService

     )
    {
        super();
        this.property = this._oDetailService.form.model as OForDetail;
    }

    ngOnDestroy(): void
    {
        this._oDetailService.destroyForm();
    }

    ngOnInit(): void {

    }
}
