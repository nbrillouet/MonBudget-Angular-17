import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FilterAsifTableSelected } from 'app/model/filters/account-statement-import-file.filter';
import { AsifDetailService } from 'app/services/account-statement/account-statement-import-file/detail/asif-detail.service';
import { AsifTableService } from 'app/services/account-statement/account-statement-import-file/table/asif-table.service';
import { AS_MODEL_2_COLUMNS } from 'app/services/account-statement/account-statement-import-file/table/constants';
import { HelperService } from 'app/services/helper.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { MatTableFilter } from '@corporate/mat-table-filter';

@Component({
    selector       : 'asif-table-main',
    templateUrl    : './asif-table-main.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AsifTableMainComponent implements OnInit, OnDestroy
{
    matTableFilter: MatTableFilter;
    idFile: number;

    constructor(
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
        private _asifDetailService: AsifDetailService,
        public _userLoggedService: UserLoggedService,
        public _asifTableService: AsifTableService,
        public _helperService: HelperService
     )
    {
        this.matTableFilter = {
            columns: AS_MODEL_2_COLUMNS,
            filterSelection$: this._asifTableService.stateSelection$,
            filterSelected$: this._asifTableService.stateSelected$,
            table$: this._asifTableService.stateTable$,
            toolbar: null,
            clickOnRow: true
        };
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        // this._activatedRoute.params.subscribe((routeParams) => {
        //     this.idFile = routeParams['idFile'];
        //     this._asifTableService.initFilterAsifTableSelected(this.idFile);
        // });
    }

    onRowClick($event): void {
        this._asifDetailService.loadAsifDetail({ id: $event.id});

        const url = this._activatedRoute['_routerState'].snapshot.url;

        this._router.navigate([`${url}/detail/`, $event.id]);
    }

    applyFilterSelected(selected: FilterAsifTableSelected): void {
        this._asifTableService.applyFilterSelected(selected);
    }

    applyFilterSelection(selected: FilterAsifTableSelected): void {
        this._asifTableService.applyFilterSelection(selected);
    }

}
