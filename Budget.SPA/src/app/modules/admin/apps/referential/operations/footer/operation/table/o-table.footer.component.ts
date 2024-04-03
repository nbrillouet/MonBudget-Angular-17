import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatTableFilter } from '@corporate/mat-table-filter';
import { FilterOTableSelected } from 'app/model/filters/operation.filter';
import { OTableService } from 'app/services/referential/operations/operation/table/o-table.service';

@Component({
    selector       : 'o-table-footer',
    templateUrl    : './o-table.footer.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class OTableFooterComponent implements OnInit, OnDestroy {
    matTableFilter: MatTableFilter;

    constructor(
        public _oTableService: OTableService
    )
    {

    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {
    }

    applyFilterSelected(selected: FilterOTableSelected): void {
        this._oTableService.applyFilterSelected(selected);
    }
}
