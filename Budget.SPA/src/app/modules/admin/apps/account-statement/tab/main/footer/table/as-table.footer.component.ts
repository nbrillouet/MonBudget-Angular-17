import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
import { AS_MODEL_2_COLUMNS } from 'app/services/account-statement/account-statement-import-file/table/constants';
import { AsTableService } from 'app/services/account-statement/account-statement/table/as-table.service';
import { MatTableFilter } from '@corporate/mat-table-filter';

@Component({
    selector       : 'as-table-footer',
    templateUrl    : './as-table.footer.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AsTableFooterComponent implements OnInit, OnDestroy {
    matTableFilter: MatTableFilter;

    constructor(
        public _asTableService: AsTableService
    )
    {
        // this.matTableFilter = {
        //     columns: AS_MODEL_2_COLUMNS,
        //     filterSelection$: this._asTableService._selectionService.state$,
        //     filterSelected$: this._asTableService._selectedService.state$,
        //     table$: this._asTableService.state$,
        //     toolbar: null
        // };
    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {

    }

    applyFilterSelected(selected: FilterAsTableSelected): void {
        this._asTableService.applyFilterSelected(selected);
    }
}
