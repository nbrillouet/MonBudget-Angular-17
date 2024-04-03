import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';
import { AsMainService } from 'app/services/account-statement/account-statement/main/as-main.service';
import { AsTableService } from 'app/services/account-statement/account-statement/table/as-table.service';
import { EnumService } from 'app/services/enum.service';
import { HelperService } from 'app/services/helper.service';

@Component({
    selector       : 'as-tab-main',
    templateUrl    : './as-tab-main.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AsTabMainComponent implements OnInit, OnDestroy {

    asMainSelectedProperty: FilterAsMainSelected;

    constructor(
        private _authService: AuthService,
        private _activatedRoute: ActivatedRoute,
        private _helperService: HelperService,
        public _asMainService: AsMainService,
        public _enumService: EnumService
    )
    {
        this.asMainSelectedProperty = this._asMainService._selectedService.model;
        this._asMainService._selectedService.change(x=>x.user, this._authService.user);
        this._asMainService._selectedService.change(x=>x.monthYear, this._helperService.getMonthYear());
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((routeParams) => {
            this._asMainService._selectedService.change(x=>x.idAccount, routeParams['idAccount']);
        });
    }

    ngOnDestroy(): void {

    }
}
