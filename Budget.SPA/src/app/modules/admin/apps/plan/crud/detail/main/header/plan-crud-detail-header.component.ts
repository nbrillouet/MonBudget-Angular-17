import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { PlanForDetail } from 'app/model/plan/plan.model';
import { PlanCrudDetailService } from 'app/services/plan/crud/detail/plan-crud-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'plan-crud-detail-header',
    templateUrl    : './plan-crud-detail-header.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class PlanCrudDetailHeaderComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: PlanForDetail;
    // config: any;

    constructor(
        private _router: Router,
        public _userLoggedService: UserLoggedService,
        public _planCrudDetailService: PlanCrudDetailService
     )
    {
        super();
        this.property = this._planCrudDetailService.form.model as PlanForDetail;
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        // this._fuseConfigService.config$.subscribe((config: AppConfig) => {
        //     this.config = config;
        // });
    }

    save(): void {
        this._planCrudDetailService.saveDetail();
    }

    movePrevious(): void {
        // /apps/account-statement-import/file/8
        this._router.navigate(['/apps/plans']);
    }

    // getValue(property: any): any {

    //     return this._planCrudDetailService.form.getValue(property);
    // }

    // getControl(property: string): AbstractControl {
    //     return this._asifDetailService.asifForm.getControl(property);
    // }

    // getAsset(): string {
    //     if(!this.config) {
    //         return null;
    //     }
    //     let assetUrl: string = this._helperService.getDeepClone(this._asifDetailService.asifForm.getValue(x=>x.operationTypeFamily)?.code);

    //     if(!assetUrl){
    //         return null;
    //     }
    //     assetUrl = assetUrl.replace('[theme]', this.config.theme);

    //     return assetUrl;
    // }

}
