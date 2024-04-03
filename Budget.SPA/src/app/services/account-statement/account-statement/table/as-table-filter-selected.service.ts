import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { FilterSelected } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeAsTableFilterSelected } from 'app/state/account-statement/as-table/as-table-filter-selected/as-table-filter-selected.action';
import { AsTableFilterSelectedState } from 'app/state/account-statement/as-table/as-table-filter-selected/as-table-filter-selected.state';
import { ChangeAsTableFilterSelection } from 'app/state/account-statement/as-table/as-table-filter-selection/as-table-filter-selection.action';
import { Observable } from 'rxjs';
import { AsMainFilterSelectedService } from '../main/as-main-filter-selected.service';

@Injectable({ providedIn: 'root' })
export class AsTableFilterSelectedService extends CorpDataReadonly<FilterAsTableSelected>
{
    @Select(AsTableFilterSelectedState.get) state$: Observable<FilterSelected<FilterAsTableSelected>>;

    selected: FilterAsTableSelected = new FilterAsTableSelected();
    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService,
        private _asMainFilterSelectedService: AsMainFilterSelectedService
    )
    {
        super(FilterAsTableSelected);

        this._asMainFilterSelectedService.state$.subscribe((x)=> {
            if(x?.loader['filter-selected']?.loaded) {
                this.value = {...this.value,
                    idAccount: x.selected.idAccount,
                    isWithItTransfer: x.selected.isWithItTransfer,
                    monthYear: x.selected.monthYear,
                    user: x.selected.user };

                this.changeGlobal(this.value);
            }
        });

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['filter-selected']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.selected, this.value)) {
                    this.value = this._helperService.getDeepClone(x.selected);
                    this._store.dispatch(new ChangeAsTableFilterSelection(this.value));
                }
            }
        });
    }

    change(nameFunction: ((obj: FilterAsTableSelected) => any) | (new(...params: any[]) => FilterAsTableSelected), value: any): void {
        const param = LambdaExpression.getParameters<FilterAsTableSelected>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);
        this._store.dispatch(new ChangeAsTableFilterSelected(param));
    }

    changeGlobal(filterAsTableSelected: FilterAsTableSelected): void {
        this._store.dispatch(new ChangeAsTableFilterSelected(filterAsTableSelected));
    }

    public applyFilter(selected: FilterAsTableSelected): void {
        this._store.dispatch(new ChangeAsTableFilterSelected(selected));
    }

}
