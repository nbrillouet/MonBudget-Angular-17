import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { SelectCode } from '@corporate/model';
import { AsifTableService } from 'app/services/account-statement/account-statement-import-file/table/asif-table.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';

@Component({
    selector       : 'asif-table-header',
    templateUrl    : './asif-table-header.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AsifTableHeaderComponent implements OnInit, OnDestroy
{
    constructor(

        public _userLoggedService: UserLoggedService,
        public _asifTableService: AsifTableService
     )
    { }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {

    }

    accountChange($event): void {
        this._asifTableService.changeFilterAsifTableSelected(x=>x.account, this._asifTableService.filterAsifSelection.account.find(x=>x.id===$event.id));
    }

    onAsifStateChanged(state: SelectCode): void {
        this._asifTableService.changeFilterAsifTableSelected(x=>x.state, state);
    }

    saveInAccountStatement(): void {
        this._asifTableService.saveInAccountStatement();
    }
}
