import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';
import { OtfForTable } from 'app/model/referential/operation-type-family.model';
import { DeleteOtfTable } from 'app/state/referential/operation-type-family/otf-table/otf-table.action';
import { OtfTableState } from 'app/state/referential/operation-type-family/otf-table/otf-table.state';
import { Observable } from 'rxjs';
import { OtfTableFilterSelectedService } from './otf-table-filter-selected.service';
import { OtfTableFilterSelectionService } from './otf-table-filter-selection.service';


@Injectable({ providedIn: 'root' })
export class OtfTableService
{
    @Select(OtfTableState.get) state$: Observable<Datas<OtfForTable[]>>;
    isDeleted: boolean = null;
    filterSelected: FilterOtfTableSelected;
    /**
     * Constructor
     */
    constructor(
        public _selectedService: OtfTableFilterSelectedService,
        public _selectionService: OtfTableFilterSelectionService,
        private _store: Store
    )
    {
        this.state$.subscribe((result)=> {
            if(result?.loader['datas-delete']?.loaded) {
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

    public applyFilterSelected(selected: FilterOtfTableSelected): void {
        this._selectedService.applyFilter(selected);
    }

    public applyFilterSelection(selected: FilterOtfTableSelected): void {
        this._selectionService.applyFilter(selected);
    }

    public delete(idOtfList: number[]): void {
        this._store.dispatch(new DeleteOtfTable({idOtfList: idOtfList, filterSelected: this.filterSelected}));
    }

}
