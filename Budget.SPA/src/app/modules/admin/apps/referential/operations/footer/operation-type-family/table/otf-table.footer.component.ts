import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatTableFilter } from '@corporate/mat-table-filter';
import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';
import { OtfTableService } from 'app/services/referential/operations/operation-type-family/table/otf-table.service';

@Component({
    selector       : 'otf-table-footer',
    templateUrl    : './otf-table.footer.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class OtfTableFooterComponent implements OnInit, OnDestroy {
    matTableFilter: MatTableFilter;

    constructor(
        public _otfTableService: OtfTableService
    )
    {
        // this.matTableFilter = {
        //     columns: OTF_COLUMNS,
        //     filterSelection$: this._otfTableService._selectionService.state$,
        //     filterSelected$: this._otfTableService._selectedService.state$,
        //     table$: this._otfTableService.state$,
        //     toolbar: null
        // };
    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {

    }

    applyFilterSelected(selected: FilterOtfTableSelected): void {
        this._otfTableService.applyFilterSelected(selected);
    }
}
