import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { Select } from '@corporate/model';
import { AsSolde } from 'app/model/account-statement/account-statement-solde.model';
import { FilterAsMainSelected, FilterAsMainSelection } from 'app/model/filters/account-statement.filter';
import { AsMainService } from 'app/services/account-statement/account-statement/main/as-main.service';
import { AsSoldeService } from 'app/services/account-statement/account-statement/solde/as-solde.service';
import { EnumService } from 'app/services/enum.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'as-tab-header',
    templateUrl    : './as-tab-header.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations     : fuseAnimations
})
export class AsTabHeaderComponent implements OnInit, OnDestroy
{
    config: any;
    asMainSelectedProperty: FilterAsMainSelected;
    asMainSelectionProperty: FilterAsMainSelection;
    asSoldeProperty: AsSolde;

    constructor(
        public _userLoggedService: UserLoggedService,
        public _asMainService: AsMainService,
        public _asSoldeService: AsSoldeService,
        public _enumService: EnumService
    )
    {
        this.asMainSelectedProperty = this._asMainService._selectedService.model;
        this.asMainSelectionProperty= this._asMainService._selectionService.model;
        this.asSoldeProperty = this._asSoldeService.model;
    }

    ngOnDestroy(): void {
    }

    ngOnInit(): void {
    }

    save(): void {

    }

    changeMonth(month: Select): void {
        this._asMainService._selectedService.change(x=>x.monthYear.month, month);
    }

    changeYear(year: Select): void {
        this._asMainService._selectedService.change(x=>x.monthYear.year, year);
    }

    changeTabIndex(index: number): void {
        this._asMainService._selectedService.change(x=>x.tabIndex, index);
    }

}
