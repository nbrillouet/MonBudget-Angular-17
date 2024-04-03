import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { OForDetail } from 'app/model/referential/operation.model';
import { ODetailService } from 'app/services/referential/operations/operation/detail/o-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'o-detail-header',
    templateUrl    : './o-detail-header.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class ODetailHeaderComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: OForDetail;

    constructor(
        private _router: Router,
        public _userLoggedService: UserLoggedService,
        public _oDetailService: ODetailService
     )
    {
        super();
        this.property = this._oDetailService.form.model as OForDetail;
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {

    }

    save(): void {
        this._oDetailService.saveDetail();
    }

    movePrevious(): void {
        this._router.navigate(['/apps/referential/operations']);
    }

}
