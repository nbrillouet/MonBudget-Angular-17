import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { OtfForDetail } from 'app/model/referential/operation-type-family.model';
import { OtfDetailService } from 'app/services/referential/operations/operation-type-family/detail/otf-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'otf-detail-header',
    templateUrl    : './otf-detail-header.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class OtfDetailHeaderComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    isNew: boolean = false;
    property: OtfForDetail;

    constructor(
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        public _userLoggedService: UserLoggedService,
        public _otfDetailService: OtfDetailService
     )
    {
        super();
        this.property = this._otfDetailService.form.model as OtfForDetail;
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((routeParams) => {
            this.isNew = routeParams['idOtf']==='new';
        });
    }

    save(): void {
        this._otfDetailService.saveDetail();
    }

    movePrevious(): void {
        this._router.navigate(['/apps/referential/operations']);
    }

}
