import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { Pagination } from '@corporate/mat-table-filter';
import { FilterSelected } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterOtTableSelected } from 'app/model/filters/operation-type.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeOtTableFilterSelected } from 'app/state/referential/operation-type/ot-table/ot-table-filter-selected/ot-table-filter-selected.action';
import { OtTableFilterSelectedState } from 'app/state/referential/operation-type/ot-table/ot-table-filter-selected/ot-table-filter-selected.state';
import { ChangeOtTableFilterSelection } from 'app/state/referential/operation-type/ot-table/ot-table-filter-selection/ot-table-filter-selection.action';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OtTableFilterSelectedService extends CorpDataReadonly<FilterOtTableSelected>
{
    @Select(OtTableFilterSelectedState.get) state$: Observable<FilterSelected<FilterOtTableSelected>>;

    selected: FilterOtTableSelected = new FilterOtTableSelected();
    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService,
        private _authService: AuthService
    )
    {
        super(FilterOtTableSelected);

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['filter-selected']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.selected, this.value)) {
                    this.value = this._helperService.getDeepClone(x.selected);
                    this._store.dispatch(new ChangeOtTableFilterSelection(this.value));
                }
            }
        });
    }

    changeByProperty(nameFunction: ((obj: FilterOtTableSelected) => any) | (new(...params: any[]) => FilterOtTableSelected), value: any): void {
        const param = LambdaExpression.getParameters<FilterOtTableSelected>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);
        this._store.dispatch(new ChangeOtTableFilterSelected(param));
    }

    // change(filterSelected: FilterOtTableSelected): void {
    //     this._store.dispatch(new ChangeOtTableFilterSelected(filterSelected));
    // }

    public applyFilter(filterSelected: FilterOtTableSelected): void {
        this._store.dispatch(new ChangeOtTableFilterSelected(filterSelected));
    }

    // public load(): void {
    //     const filter = new FilterOtTableSelected( {user: this._authService.user, pagination: new Pagination()});
    //     // this._store.dispatch(new ChangeOtTableFilterSelection(filter));
    //     this._store.dispatch(new ChangeOtTableFilterSelected(filter));
    // }


}
