import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Select } from '@ngxs/store';
import { AsForTable } from 'app/model/account-statement/account-statement-table.model';
import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
import { AsTableState } from 'app/state/account-statement/as-table/as-table.state';
import { Observable } from 'rxjs';
import { AsTableFilterSelectedService } from './as-table-filter-selected.service';
import { AsTableFilterSelectionService } from './as-table-filter-selection.service';

@Injectable({ providedIn: 'root' })
export class AsTableService
{
    @Select(AsTableState.get) state$: Observable<Datas<AsForTable[]>>;

    /**
     * Constructor
     */
    constructor(
        public _selectedService: AsTableFilterSelectedService,
        public _selectionService: AsTableFilterSelectionService
    )
    {
    }

    public applyFilterSelected(selected: FilterAsTableSelected): void {
        this._selectedService.applyFilter(selected);
    }

    public applyFilterSelection(selected: FilterAsTableSelected): void {
        this._selectionService.applyFilter(selected);
    }
}
