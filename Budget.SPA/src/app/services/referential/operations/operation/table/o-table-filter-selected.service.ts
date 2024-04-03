import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { FilterSelected } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterOTableSelected } from 'app/model/filters/operation.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeOTableFilterSelected } from 'app/state/referential/operation/operation-table/operation-table-filter-selected/operation-table-filter-selected.action';
import { OTableFilterSelectedState } from 'app/state/referential/operation/operation-table/operation-table-filter-selected/operation-table-filter-selected.state';
import { ChangeOTableFilterSelection } from 'app/state/referential/operation/operation-table/operation-table-filter-selection/operation-table-filter-selection.action';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OTableFilterSelectedService extends CorpDataReadonly<FilterOTableSelected>
{
    @Select(OTableFilterSelectedState.get) state$: Observable<FilterSelected<FilterOTableSelected>>;

    selected: FilterOTableSelected = new FilterOTableSelected();
    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService,
        private _authService: AuthService
    )
    {
        super(FilterOTableSelected);

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['filter-selected']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.selected, this.value)) {
                    this.value = this._helperService.getDeepClone(x.selected);
                    this._store.dispatch(new ChangeOTableFilterSelection(this.value));
                }
            }
        });
    }

    changeByProperty(nameFunction: ((obj: FilterOTableSelected) => any) | (new(...params: any[]) => FilterOTableSelected), value: any): void {
        const param = LambdaExpression.getParameters<FilterOTableSelected>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);
        this._store.dispatch(new ChangeOTableFilterSelected(param));
    }

    public applyFilter(filterSelected: FilterOTableSelected): void {
        this._store.dispatch(new ChangeOTableFilterSelected(filterSelected));
    }

}
