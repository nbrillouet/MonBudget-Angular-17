import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { OtForDetail } from 'app/model/referential/operation-type.model';
import { OtDetailService } from 'app/services/referential/operations/operation-type/detail/ot-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'ot-detail-header',
    templateUrl    : './ot-detail-header.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class OtDetailHeaderComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: OtForDetail;
    isNew: boolean = false;

    constructor(
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        public _userLoggedService: UserLoggedService,
        public _otDetailService: OtDetailService
     )
    {
        super();
        this.property = this._otDetailService.form.model as OtForDetail;
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((routeParams) => {
            this.isNew = routeParams['idOt']==='new';
        });
    }

    save(): void {
        this._otDetailService.saveDetail();
    }

    movePrevious(): void {
        this._router.navigate(['/apps/referential/operations']);
    }

}
