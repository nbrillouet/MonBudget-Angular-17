import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { fuseAnimations } from '@fuse/animations';
import { AccountForDetail } from 'app/model/referential/account.model';
import { AccountDetailService } from 'app/services/referential/account/detail/account-detail.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'account-detail-content',
    templateUrl    : './account-detail-content.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class AccountDetailContentComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: AccountForDetail;

    constructor(
        public _accountDetailService: AccountDetailService
     )
    {
        super();
        this.property = this._accountDetailService.form.model as AccountForDetail;
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {

    }

    getValue(property: any): any {
        return this._accountDetailService.form.getValue(property);
    }

    getControl(property: any): AbstractControl {
        return this._accountDetailService.form.getControl(property);
    }

    getProperty(property): any {
        return this._accountDetailService.form.getProperty(property);
    }

}
