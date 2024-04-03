import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';

import { PlanForDetail } from 'app/model/plan/plan.model';
import { PlanCrudDetailService } from 'app/services/plan/crud/detail/plan-crud-detail.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'plan-crud-detail-general-content',
    templateUrl    : './plan-crud-detail-content-general.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class PlanCrudDetailContentGeneralComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: PlanForDetail;

    constructor(
        public _planCrudDetailService: PlanCrudDetailService,
     )
    {
        super();
        this.property = this._planCrudDetailService.form.model as PlanForDetail;

    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
    }

    onChangeColor(color: string): void {
        this._planCrudDetailService.form.setValue(x=>x.plan.color, color);
        this._planCrudDetailService.form.getControl(x=>x.plan.color).markAsDirty();
    }



    // getProperty(property: any): string {
    //     return this._planCrudDetailService.form.getProperty(property);
    // }
}


