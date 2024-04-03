import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';
import { OtForTable } from 'app/model/referential/operation-type.model';
import { DeleteOtTable } from 'app/state/referential/operation-type/ot-table/ot-table.action';
import { OtTableState } from 'app/state/referential/operation-type/ot-table/ot-table.state';
import { Observable } from 'rxjs';
import { OtTableFilterSelectedService } from './ot-table-filter-selected.service';
import { OtTableFilterSelectionService } from './ot-table-filter-selection.service';

@Injectable({ providedIn: 'root' })
export class OtTableService
{
    @Select(OtTableState.get) state$: Observable<Datas<OtForTable[]>>;
    isDeleted: boolean = null;
    filterSelected: FilterOtTableSelected;
    /**
     * Constructor
     */
    constructor(
        public _selectedService: OtTableFilterSelectedService,
        public _selectionService: OtTableFilterSelectionService,
        private _store: Store
    )
    {
        this.state$.subscribe((x) => {
            if(x?.loader['datas-delete']?.loaded) {
                this.isDeleted=this.isDeleted===true ? false : true;
            }
        });

        this._selectedService.state$.subscribe((result)=> {
            if(result?.loader['filter-selected']?.loaded) {
                this.filterSelected = result.selected;
            }
        });
    }

    public applyFilterSelected(selected: FilterOtTableSelected): void {
        this._selectedService.applyFilter(selected);
    }

    public applyFilterSelection(selected: FilterOtTableSelected): void {
        this._selectionService.applyFilter(selected);
    }

    public delete(idOtfList: number[]): void {
        this._store.dispatch(new DeleteOtTable({idOtfList: idOtfList, filterSelected: this.filterSelected}));
    }
}
