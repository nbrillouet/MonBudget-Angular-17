import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config';
import { PlanForDetail } from 'app/model/plan/plan.model';
import { PlanCrudDetailService } from 'app/services/plan/crud/detail/plan-crud-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'plan-crud-detail-main',
    templateUrl    : './plan-crud-detail-main.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class PlanCrudDetailMainComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: PlanForDetail = null;

    constructor(
        private _activatedRoute: ActivatedRoute,

        public _userLoggedService: UserLoggedService,
        public _planCrudDetailService: PlanCrudDetailService,
        public _fuseConfigService: FuseConfigService

     )
    {
        super();
        this.property = this._planCrudDetailService.form.model as PlanForDetail;
    }


    ngOnDestroy(): void
    {
        this._planCrudDetailService.destroyForm();
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((routeParams) => {
            this._planCrudDetailService.loadDetail({id: routeParams['idPlan']==='create' ? 0 : routeParams['idPlan'] });
        });
    }
}
