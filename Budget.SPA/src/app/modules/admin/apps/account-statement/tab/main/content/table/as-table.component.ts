import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'app/core/auth/auth.service';
import { AS_MODEL_2_COLUMNS } from 'app/services/account-statement/account-statement-import-file/table/constants';
import { AsMainService } from 'app/services/account-statement/account-statement/main/as-main.service';
import { AsTableService } from 'app/services/account-statement/account-statement/table/as-table.service';
import { MatTableFilter } from '@corporate/mat-table-filter';
import { AsifDetailService } from 'app/services/account-statement/account-statement-import-file/detail/asif-detail.service';
import { AsDetailService } from 'app/services/account-statement/account-statement/detail/as-detail.service';

@Component({
    selector       : 'as-table',
    templateUrl    : './as-table.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AsTableComponent implements OnInit, OnDestroy {
    matTableFilter: MatTableFilter;

    constructor(
        private _asMainService: AsMainService,
        public _asTableService: AsTableService,
        private _asDetailService: AsDetailService,
        private _authService: AuthService,
        private _activatedRoute: ActivatedRoute,
        private _router: Router
    )
    {
        this.matTableFilter = {
            columns: AS_MODEL_2_COLUMNS,
            filterSelection$: this._asTableService._selectionService.state$,
            filterSelected$: this._asTableService._selectedService.state$,
            table$: this._asTableService.state$,
            toolbar: null,
            clickOnRow: true
        };
    }

    ngOnInit(): void {
        // this._activatedRoute.params.subscribe((routeParams) => {
        //     this._asMainService._selectedService.change(x=>x.idAccount, routeParams['idAccount']);
        // });
    }

    ngOnDestroy(): void {

    }

    onRowClick($event): void {
        this._asDetailService.loadAsDetail({id: $event.id});
        this._router.navigate([`detail/${$event.id}`], {relativeTo: this._activatedRoute});
    }

}
