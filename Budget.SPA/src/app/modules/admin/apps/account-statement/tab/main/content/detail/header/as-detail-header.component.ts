import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { AsDetailService } from 'app/services/account-statement/account-statement/detail/as-detail.service';
import { HelperService } from 'app/services/helper.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';
import { Location } from '@angular/common';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'as-detail-header',
    templateUrl    : './as-detail-header.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class AsDetailHeaderComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: AsForDetail;
    config: any;

    constructor(
        private _location: Location,
        private _helperService: HelperService,
        public _userLoggedService: UserLoggedService,
        public _asDetailService: AsDetailService,
        public _fuseConfigService: FuseConfigService
     )
    {
        super();
        this.property = this._asDetailService.form.model as AsForDetail;
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        this._fuseConfigService.config$.subscribe((config) => {
            this.config = config;
        });
    }

    save(): void {
        this._asDetailService.saveAsDetail();
    }

    movePrevious(): void {
        this._location.back();
        // const route = this._activatedRoute.snapshot;

    }

    getAsset(): string {
        if(!this.config) {
            return null;
        }
        let assetUrl: string = this._helperService.getDeepClone(this._asDetailService.form.getValue(x=>x.operationTypeFamily)?.code);

        if(!assetUrl){
            return null;
        }
        assetUrl = assetUrl.replace('[theme]', this.config.theme);

        return assetUrl;
    }

}
