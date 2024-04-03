import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pagination } from '@corporate/mat-table-filter';
import { AuthService } from 'app/core/auth/auth.service';
import { EnumOperationsUrl } from 'app/model/enum/enum-operations.enum';
import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';
import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';
import { FilterOTableSelected } from 'app/model/filters/operation.filter';
import { OtTableService } from 'app/services/referential/operations/operation-type/table/ot-table.service';
import { OTableService } from 'app/services/referential/operations/operation/table/o-table.service';
import { OtfTableService } from 'app/services/referential/operations/operation-type-family/table/otf-table.service';

@Component({
    selector       : 'operations',
    templateUrl    : './operations.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class OperationsComponent implements OnInit, OnDestroy
{
    enumOperationsUrl: EnumOperationsUrl;
    enumOperationsUrlList: typeof EnumOperationsUrl = EnumOperationsUrl;

    /**
     * Constructor
     */
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
        private _authService: AuthService,
        private _otfTableService: OtfTableService,
        private _otTableService: OtTableService,
        private _oTableService: OTableService
    )
    {


    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        const urlSplit = this._router.url.split('/');

        switch(urlSplit.pop()) {
            case EnumOperationsUrl.operations:
                this._router.navigate([EnumOperationsUrl.operationTypeFamily], {relativeTo: this._activatedRoute});
                break;
            case EnumOperationsUrl.operationTypeFamily:
                const selectedOtf = new FilterOtfTableSelected({ user: this._authService.user, pagination: new Pagination() });
                this._otfTableService.applyFilterSelected(selectedOtf);
                this.enumOperationsUrl = EnumOperationsUrl.operationTypeFamily;
                break;
            case EnumOperationsUrl.operationType:
                const idOtf: number = +urlSplit[urlSplit.length-1].toString();
                const selectedOt = new FilterOtTableSelected({ user: this._authService.user, pagination: new Pagination(), operationTypeFamily: {id: idOtf, label: null } });
                this._otTableService.applyFilterSelected(selectedOt);
                this.enumOperationsUrl = EnumOperationsUrl.operationType;
                break;
            case EnumOperationsUrl.operation:
                const idOt: number = +urlSplit[urlSplit.length-1].toString();
                const selectedO = new FilterOTableSelected({ user: this._authService.user, pagination: new Pagination(), operationType: {id: idOt, label: null } });
                this._oTableService.applyFilterSelected(selectedO);
                this.enumOperationsUrl = EnumOperationsUrl.operation;
                break;
        }
        // if(urlLast==='operation-type-family') {
        //     this._otfTableService.load();
        //     this.currentPage = 'otf';
        // }
        // if(urlLast==='operation-type') {
        //     this._otTableService.load();
        //     this.currentPage = 'ot';
        // }
        // if(urlLast==='operations') {
        //     this._router.navigate(['operation-type-family'], {relativeTo: this._activatedRoute});
        // }
        // if(this._router.url)
        // console.log('route', this._router.url);


        // this._router.navigateByUrl('/operation-type-family');
        // this._activatedRoute.params.subscribe((routeParams) => {
        //     this._asMainService._selectedService.change(x=>x.idAccount, routeParams['idAccount']);
        // });

        //this._otfTableService.applyFilterSelection(null);
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {

    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

}
