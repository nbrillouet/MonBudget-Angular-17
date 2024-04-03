import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config';
import { AccountForDetail } from 'app/model/referential/account.model';
import { AccountDetailService } from 'app/services/referential/account/detail/account-detail.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'account-detail-main',
    templateUrl    : './account-detail-main.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class AccountDetailMainComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    property: AccountForDetail = null;
    // idAccountStatement: number;
    // idFile: number;
    // config: any;
    // enumOperationPlace: typeof EnumOperationPlace = EnumOperationPlace;

    constructor(
        private _activatedRoute: ActivatedRoute,

        public _userLoggedService: UserLoggedService,
        public _accountDetailService: AccountDetailService,
        public _fuseConfigService: FuseConfigService

     )
    {
        super();
        this.property = this._accountDetailService.form.model as AccountForDetail;
    }


    ngOnDestroy(): void
    {
        this._accountDetailService.destroyForm();
    }

    ngOnInit(): void {
        // this._activatedRoute.params.subscribe((routeParams) => {
        //     this.idFile = routeParams['idFile'];
        //     this.idAccountStatement = routeParams['idAccountStatement'];
        // });

        // this._fuseConfigService.config$.subscribe((config: AppConfig) => {
        //     this.config = config;
        // });
    }

    // onOperationPlaceClick(operationPlace: SelectCode): void {
    //     this._asifDetailService.asifForm.setValue(x=>x.operationDetail.operationPlace, operationPlace);
    // }

    // onChangeGMapAddress(gMapAddressFilterData: GMapAddressFilterData): void {
    //     const operationDetail = this._asifDetailService.asifForm.getValue(x=>x.operationDetail) as OperationDetail;
    //     operationDetail.gMapAddress = gMapAddressFilterData.datas;
    //     operationDetail.operationLabel = gMapAddressFilterData.filter.operationPositionSearch;
    //     operationDetail.placeLabel = gMapAddressFilterData.filter.operationPlaceSearch;

    //     this._asifDetailService.changeAsifOperationDetail(operationDetail);
    // }



    // getGMapAddressFilterData(): GMapAddressFilterData {
    //     const operationDetail = this._asifDetailService.asifForm.getValue(x=>x.operationDetail) as OperationDetail;
    //     const gMapAddressFilterData = {datas: operationDetail.gMapAddress, filter: {operationPositionSearch: operationDetail.operationLabel, operationPlaceSearch:operationDetail.placeLabel } } as GMapAddressFilterData;
    //     return gMapAddressFilterData;
    // }

    // addOperation(label: string): void {
    //     this._asifDetailService.addOperation(label);
    // }

    // addOperationTransverse(label: string): void {
    //     this._asifDetailService.addOperationTransverse(label);
    // }

    // public getValue(property: string): any {
    //     return this._asifDetailService.asifForm.getValue(property);
    // }

    // private getControl(property: string): AbstractControl {
    //     return this._asifDetailService.asifForm.getControl(property);
    // }

    // private getLastProperty(property: string): string {
    //     return property.split('.').pop();
    // }

}
