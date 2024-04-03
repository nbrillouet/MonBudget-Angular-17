import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterOTableSelected } from 'app/model/filters/operation.filter';
import { OForTable } from 'app/model/referential/operation.model';
import { DeleteOTable } from 'app/state/referential/operation/operation-table/operation-table.action';
import { OTableState } from 'app/state/referential/operation/operation-table/operation-table.state';
import { Observable } from 'rxjs';
import { OTableFilterSelectedService } from './o-table-filter-selected.service';
import { OTableFilterSelectionService } from './o-table-filter-selection.service';

@Injectable({ providedIn: 'root' })
export class OTableService
{
    @Select(OTableState.get) state$: Observable<Datas<OForTable[]>>;
    isDeleted: boolean = null;
    filterSelected: FilterOTableSelected;
    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        public _selectedService: OTableFilterSelectedService,
        public _selectionService: OTableFilterSelectionService
    )
    {
        this.state$.subscribe((x) => {
            if(x?.loader['datas-delete']?.loaded) {
                console.log('isDeleted', this.isDeleted);
                this.isDeleted=this.isDeleted===true ? false : true;
            }
        });

        this._selectedService.state$.subscribe((result)=> {
            if(result?.loader['filter-selected']?.loaded) {
                this.filterSelected = result.selected;
            }
        });
    }

    public applyFilterSelected(selected: FilterOTableSelected): void {
        this._selectedService.applyFilter(selected);
    }

    public applyFilterSelection(selected: FilterOTableSelected): void {
        this._selectionService.applyFilter(selected);
    }

    public delete(idOtfList: number[]): void {
        this._store.dispatch(new DeleteOTable({idOtfList: idOtfList, filterSelected: this.filterSelected}));
    }
}
