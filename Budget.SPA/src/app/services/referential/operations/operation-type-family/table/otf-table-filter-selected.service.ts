import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { FilterSelected } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterOtfTableSelected } from 'app/model/filters/operation-type-family.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeOtfTableFilterSelected } from 'app/state/referential/operation-type-family/otf-table/otf-table-filter-selected/otf-table-filter-selected.action';
import { OtfTableFilterSelectedState } from 'app/state/referential/operation-type-family/otf-table/otf-table-filter-selected/otf-table-filter-selected.state';
import { ChangeOtfTableFilterSelection } from 'app/state/referential/operation-type-family/otf-table/otf-table-filter-selection/otf-table-filter-selection.action';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OtfTableFilterSelectedService extends CorpDataReadonly<FilterOtfTableSelected>
{
    @Select(OtfTableFilterSelectedState.get) state$: Observable<FilterSelected<FilterOtfTableSelected>>;

    selected: FilterOtfTableSelected = new FilterOtfTableSelected();
    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService,
        private _authService: AuthService
    )
    {
        super(FilterOtfTableSelected);

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['filter-selected']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.selected, this.value)) {
                    this.value = this._helperService.getDeepClone(x.selected);
                    this._store.dispatch(new ChangeOtfTableFilterSelection(this.value));
                }
            }
        });
    }

    changeByProperty(nameFunction: ((obj: FilterOtfTableSelected) => any) | (new(...params: any[]) => FilterOtfTableSelected), value: any): void {
        const param = LambdaExpression.getParameters<FilterOtfTableSelected>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);
        this._store.dispatch(new ChangeOtfTableFilterSelected(param));
    }

    public applyFilter(filterSelected: FilterOtfTableSelected): void {
        this._store.dispatch(new ChangeOtfTableFilterSelected(filterSelected));
    }

}
