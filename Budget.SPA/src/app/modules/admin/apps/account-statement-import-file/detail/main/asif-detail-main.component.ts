import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config';
import { SelectCode } from '@corporate/model';
import { AsifForDetail } from 'app/model/account-statement-import/account-statement-import-file.model';
import { EnumOperationPlace } from 'app/model/enum/enum-operation-place.enum';
import { GMapAddressFilterData } from 'app/model/g-map.model.';
import { OperationDetail } from 'app/model/referential/operation-detail.model';
import { AsifDetailService } from 'app/services/account-statement/account-statement-import-file/detail/asif-detail.service';
import { HelperService } from 'app/services/helper.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'asif-detail-main',
    templateUrl    : './asif-detail-main.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class AsifDetailMainComponent implements OnInit, OnDestroy
{
    property: AsifForDetail = this._asifDetailService.form.model; // null;
    idAccountStatement: number;
    idFile: number;
    config: any;
    enumOperationPlace: typeof EnumOperationPlace = EnumOperationPlace;

    constructor(
        private _activatedRoute: ActivatedRoute,
        private _helperService: HelperService,
        public _userLoggedService: UserLoggedService,
        public _asifDetailService: AsifDetailService,
        public _fuseConfigService: FuseConfigService
     )
    {
        // this.property = this._asifDetailService.form.model as AsifForDetail;
    }


    ngOnDestroy(): void
    {
        this._asifDetailService.destroyForm(); //asifForm=new CorpForm<AsifForDetail,AsifForDetailFormBuilderOptions>(AsifForDetail, AsifForDetailFormBuilderOptions);;
        // // Unsubscribe from all subscriptions
        // this._asifDetailService._unsubscribeAll.next(null);
        // this._asifDetailService._unsubscribeAll.complete();
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((routeParams) => {
            this.idFile = routeParams['idFile'];
            this.idAccountStatement = routeParams['idAccountStatement'];
        });

        this._fuseConfigService.config$.subscribe((config) => {
            this.config = config;
        });
    }

    onOperationPlaceClick(operationPlace: SelectCode): void {
        this._asifDetailService.form.setValue(x=>x.operationDetail.operationPlace, operationPlace);
    }

    onChangeGMapAddress(gMapAddressFilterData: GMapAddressFilterData): void {
        const operationDetail = this._asifDetailService.form.getValue(x=>x.operationDetail) as OperationDetail;
        operationDetail.gMapAddress = gMapAddressFilterData.datas;
        operationDetail.operationLabel = gMapAddressFilterData.filter.operationPositionSearch;
        operationDetail.placeLabel = gMapAddressFilterData.filter.operationPlaceSearch;

        this._asifDetailService.changeAsifOperationDetail(operationDetail);
    }

    compareObjects(o1: any, o2: any): boolean {
        if(o1?.label === o2?.label && o1?.id === o2?.id ) {
            return true;
        }
        return false;
    }

    getGMapAddressFilterData(): GMapAddressFilterData {
        const operationDetail = this._asifDetailService.form.getValue(x=>x.operationDetail) as OperationDetail;
        const gMapAddressFilterData = {datas: operationDetail.gMapAddress, filter: {operationPositionSearch: operationDetail.operationLabel, operationPlaceSearch:operationDetail.placeLabel } } as GMapAddressFilterData;
        return gMapAddressFilterData;
    }

    addOperation(label: string): void {
        this._asifDetailService.addOperation(label);
    }

    addOperationTransverse(label: string): void {
        this._asifDetailService.addOperationTransverse(label);
    }

    public getValue(property: string): any {
        return this._asifDetailService.form.getValue(property);
    }

    public getControl(property: string): AbstractControl {
        return this._asifDetailService.form.getControl(property);
    }

    public getProperty(property: string): string {
        return this._asifDetailService.form.getProperty(property);
    }

}
