import { Injectable } from '@angular/core';
import { LambdaExpression } from '@corporate/data';
import { Datas, FilterSelected, FilterSelection, Select as SelectModel, SelectCode } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { AsifForTable } from 'app/model/account-statement-import/account-statement-import-file.model';
import { FilterAsifTableSelected, FilterAsifTableSelection } from 'app/model/filters/account-statement-import-file.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeAsifTableFilterSelected } from 'app/state/account-statement-import-file/asif-table/asif-table-filter-selected/asif-table-filter-selected.action';
import { AsifTableFilterSelectedState } from 'app/state/account-statement-import-file/asif-table/asif-table-filter-selected/asif-table-filter-selected.state';
import { LoadAsifTableFilterSelection } from 'app/state/account-statement-import-file/asif-table/asif-table-filter-selection/asif-table-filter-selection.action';
import { AsifTableFilterSelectionState } from 'app/state/account-statement-import-file/asif-table/asif-table-filter-selection/asif-table-filter-selection.state';
import { SaveAsifTableInAs } from 'app/state/account-statement-import-file/asif-table/asif-table.action';
import { AsifTableState } from 'app/state/account-statement-import-file/asif-table/asif-table.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AsifTableService
{
    @Select(AsifTableFilterSelectedState.get) stateSelected$: Observable<FilterSelected<FilterAsifTableSelected>>;
    @Select(AsifTableFilterSelectionState.get) stateSelection$: Observable<FilterSelection<FilterAsifTableSelection>>;
    @Select(AsifTableState.get) stateTable$: Observable<Datas<AsifForTable[]>>;

    filterAsifSelected: FilterAsifTableSelected = null;
    filterAsifSelection: FilterAsifTableSelection = null;

    /**
     * Constructor
     */
    constructor(
        public _store: Store,
        private _authService: AuthService,
        private _helperService: HelperService
    )
    {


        this.stateSelected$.subscribe((result)=> {
            if(result?.loader['filter-selected']?.loaded) {
                this.filterAsifSelected = result.selected;
            }
        });

        this.stateSelection$.subscribe((result)=> {
            if(result?.loader['filter-selection']?.loaded) {
                this.filterAsifSelection = this._helperService.getDeepClone(result.selection);
                if(this.filterAsifSelected) {
                    if(!this.filterAsifSelected?.account) {
                        this.changeFilterAsifTableSelected(x=>x.account, result.selection.account[0]);
                    }
                    if(!this.filterAsifSelected?.state) {
                        this.changeFilterAsifTableSelected(x=>x.state, result.selection.state[0]);
                    }
                }
            }
        });
    }


    // // -----------------------------------------------------------------------------------------------------
    // // @ Public methods
    // // -----------------------------------------------------------------------------------------------------
    public applyFilterSelected(selected: FilterAsifTableSelected): void {
        this._store.dispatch(new ChangeAsifTableFilterSelected(selected));
    }

    public applyFilterSelection(selected: FilterAsifTableSelected): void {
        this._store.dispatch(new LoadAsifTableFilterSelection(selected));
    }

    public changeFilterAsifTableSelected(nameFunction: ((obj: FilterAsifTableSelected) => any) | (new(...params: any[]) => FilterAsifTableSelected), value: string | Date | boolean | number | SelectCode | SelectModel): void {
        this.filterAsifSelected = LambdaExpression.getParameters<FilterAsifTableSelected>(nameFunction.toString(), this._helperService.getDeepClone(this.filterAsifSelected), this._helperService.getDeepClone(value)) as FilterAsifTableSelected;
        this.applyFilterSelected(this.filterAsifSelected);
    }

    public initFilterAsifTableSelected(idImport: number): void {
        this.filterAsifSelected = new FilterAsifTableSelected();
        this.filterAsifSelected.idImport = idImport;
        this.filterAsifSelected.user = this._helperService.getDeepClone(this._authService.user);

        this.applyFilterSelection(this.filterAsifSelected);
        this.applyFilterSelected(this.filterAsifSelected);
    }

    public saveInAccountStatement(): void {
        this._store.dispatch(new SaveAsifTableInAs({ idImport: this.filterAsifSelected.idImport }));
    }

}
