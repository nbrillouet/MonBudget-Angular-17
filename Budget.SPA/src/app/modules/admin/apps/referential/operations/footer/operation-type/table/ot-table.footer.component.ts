import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatTableFilter } from '@corporate/mat-table-filter';
import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';
import { OtTableService } from 'app/services/referential/operations/operation-type/table/ot-table.service';

@Component({
    selector       : 'ot-table-footer',
    templateUrl    : './ot-table.footer.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class OtTableFooterComponent implements OnInit, OnDestroy {
    matTableFilter: MatTableFilter;

    constructor(
        public _otTableService: OtTableService
    )
    {

    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {
    }

    applyFilterSelected(selected: FilterOtTableSelected): void {
        this._otTableService.applyFilterSelected(selected);
    }
}
