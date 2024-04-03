import { Component, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config';
import { AsifForDetail } from 'app/model/account-statement-import/account-statement-import-file.model';
import { AsifDetailService } from 'app/services/account-statement/account-statement-import-file/detail/asif-detail.service';
import { HelperService } from 'app/services/helper.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { Location } from '@angular/common';
import { Store } from '@ngxs/store';

@Component({
    selector       : 'asif-detail-header',
    templateUrl    : './asif-detail-header.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class AsifDetailHeaderComponent implements OnInit, OnDestroy
{
    // @Input()  property: AsifForDetail;
    property: AsifForDetail;
    config: any;

    constructor(
        private _activatedRoute: ActivatedRoute,
        private _location: Location,
        private _store: Store,
        private _helperService: HelperService,
        public _userLoggedService: UserLoggedService,
        public _asifDetailService: AsifDetailService,
        public _fuseConfigService: FuseConfigService
     )
    {
        this.property = this._asifDetailService.form.model as AsifForDetail;
    }

    ngOnDestroy(): void {
        // throw new Error('Method not implemented.');
    }

    ngOnInit(): void {
        // this._activatedRoute.params.subscribe((routeParams) => {

        //     this.idAccountStatement = routeParams['idAccountStatement'];

        //     this._asifDetailService.loadAsifDetail({ id: this.idAccountStatement});
        // });

        this._fuseConfigService.config$.subscribe((config) => {
            this.config = config;
        });
    }

    save(): void {
        this._asifDetailService.saveAsifDetail();
    }

    movePrevious(): void {
        this._location.back();
        // const route = this._activatedRoute.snapshot;

    }

    compareObjects(o1: any, o2: any): boolean {
        if(o1.label === o2.label && o1.id === o2.id ) {
            return true;
        }
        return false;
    }

    getValue(property: any): any {
        if(typeof property === 'object') {
            property = (Object.values(property)[0] as string).split('.')[0];
        }
        return this._asifDetailService.form.getValue(property);
    }

    getControl(property: string): AbstractControl {
        return this._asifDetailService.form.getControl(property);
    }

    getAsset(): string {
        if(!this.config) {
            return null;
        }
        let assetUrl: string = this._helperService.getDeepClone(this._asifDetailService.form.getValue(x=>x.operationTypeFamily)?.code);

        if(!assetUrl){
            return null;
        }
        assetUrl = assetUrl.replace('[theme]', this.config.theme);

        return assetUrl;
    }

}
