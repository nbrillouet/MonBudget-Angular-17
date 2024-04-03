import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { AccountForDetail } from 'app/model/referential/account.model';
import { AccountDetailService } from 'app/services/referential/account/detail/account-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'account-detail-header',
    templateUrl    : './account-detail-header.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class AccountDetailHeaderComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: AccountForDetail;
    // config: any;

    constructor(
        private _router: Router,
        public _userLoggedService: UserLoggedService,
        public _accountDetailService: AccountDetailService
     )
    {
        super();
        this.property = this._accountDetailService.form.model as AccountForDetail;
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        // this._fuseConfigService.config$.subscribe((config: AppConfig) => {
        //     this.config = config;
        // });
    }

    save(): void {
        this._accountDetailService.saveDetail();

    }

    movePrevious(): void {
        // /apps/account-statement-import/file/8
        this._router.navigate(['/apps/referential/accounts']);
    }



    getValue(property: any): any {
        // if(typeof property === 'object') {
        //     property = (Object.values(property)[0] as string).split('.')[0];
        // }
        return this._accountDetailService.form.getValue(property);
    }

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
