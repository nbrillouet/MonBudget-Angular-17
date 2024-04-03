import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SelectCode } from '@corporate/model';
import { EnumOperationsUrl } from 'app/model/enum/enum-operations.enum';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'operations-header',
    templateUrl    : './operations-header.component.html'
})
export class OperationsHeaderComponent implements OnInit, OnDestroy
{
    idBankAgency: number = null;
    routerLink: string[] = null;

    constructor(
        private _router: Router,
        public _userLoggedService: UserLoggedService
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
        const urlLast = this._router.url.split('/').pop();

        switch(urlLast) {
            case EnumOperationsUrl.operationTypeFamily:  //.'operation-type-family':
                this.routerLink=['Categorie opération'];
                break;
            case EnumOperationsUrl.operationType: //'operation-type':
                this.routerLink=['categorie opération',`/ ${this.getIdOtf(this._router.url)} /`,'type opération'];
                break;
            case EnumOperationsUrl.operation: //'operation-type':
                this.routerLink=['categorie opération',`/ ${this.getIdOtf(this._router.url)} /`,'type opération', `/ ${this.getIdOt(this._router.url)} /`, 'opération'];
                break;
        }

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
    displayFn(state: SelectCode): string {
        return state ? state.label : null;
    }

    private getIdOtf(url: string): number {
        let idOtf: string = null;

        idOtf = url.replace('operation-type-family', 'repere1');
        idOtf = idOtf.replace('operation-type', 'repere2');
        idOtf = idOtf.substring(idOtf.indexOf('repere1'));
        idOtf = idOtf.substring(0, idOtf.indexOf('repere2'));
        idOtf = idOtf.replace('repere1', '');
        idOtf = idOtf.replace('repere2', '');
        idOtf = idOtf.split('/').join('');

        return +idOtf;
    }

    private getIdOt(url: string): number {
        let idOt: string = null;

        idOt =url.replace('operation-type-family', 'repere1');
        idOt = idOt.substring(idOt.indexOf('operation-type'));
        idOt = idOt.replace('operation-type', '');
        idOt = idOt.replace('operation', '');
        idOt = idOt.split('/').join('');

        return +idOt;
    }


}
