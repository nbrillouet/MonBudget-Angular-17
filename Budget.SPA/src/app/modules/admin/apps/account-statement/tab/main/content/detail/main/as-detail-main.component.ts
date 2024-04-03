import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SelectCode } from '@corporate/model';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { EnumOperationPlace } from 'app/model/enum/enum-operation-place.enum';
import { GMapAddressFilterData } from 'app/model/g-map.model.';
import { OperationDetail } from 'app/model/referential/operation-detail.model';
import { AsDetailService } from 'app/services/account-statement/account-statement/detail/as-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'as-detail-main',
    templateUrl    : './as-detail-main.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class AsDetailMainComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: AsForDetail = this._asDetailService.form.model;
    idAccountStatement: number;
    idFile: number;
    config: any;
    enumOperationPlace: typeof EnumOperationPlace = EnumOperationPlace;

    constructor(
        private _activatedRoute: ActivatedRoute,
        public _userLoggedService: UserLoggedService,
        public _asDetailService: AsDetailService,
        public _fuseConfigService: FuseConfigService
     )
    {
        super();
    }


    ngOnDestroy(): void
    {
        this._asDetailService.destroyForm();
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
        this._asDetailService.form.setValue(x=>x.operationDetail.operationPlace, operationPlace);
    }

    onChangeGMapAddress(gMapAddressFilterData: GMapAddressFilterData): void {
        const operationDetail = this._asDetailService.form.getValue(x=>x.operationDetail) as OperationDetail;
        operationDetail.gMapAddress = gMapAddressFilterData.datas;
        operationDetail.operationLabel = gMapAddressFilterData.filter.operationPositionSearch;
        operationDetail.placeLabel = gMapAddressFilterData.filter.operationPlaceSearch;

        this._asDetailService.changeAsOperationDetail(operationDetail);
    }

    // compareObjects(o1: any, o2: any): boolean {
    //     if(o1?.label === o2?.label && o1?.id === o2?.id ) {
    //         return true;
    //     }
    //     return false;
    // }

    getGMapAddressFilterData(): GMapAddressFilterData {
        const operationDetail = this._asDetailService.form.getValue(x=>x.operationDetail) as OperationDetail;
        const gMapAddressFilterData = {datas: operationDetail.gMapAddress, filter: {operationPositionSearch: operationDetail.operationLabel, operationPlaceSearch:operationDetail.placeLabel } } as GMapAddressFilterData;
        return gMapAddressFilterData;
    }

    addOperation(label: string): void {
        this._asDetailService.addOperation(label);
    }

    addOperationTransverse(label: string): void {
        this._asDetailService.addOperationTransverse(label);
    }
}
