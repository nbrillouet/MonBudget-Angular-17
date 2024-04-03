import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { FilterSelection } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterOTableSelected, FilterOTableSelection } from 'app/model/filters/operation.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeOTableFilterSelection } from 'app/state/referential/operation/operation-table/operation-table-filter-selection/operation-table-filter-selection.action';
import { OTableFilterSelectionState } from 'app/state/referential/operation/operation-table/operation-table-filter-selection/operation-table-filter-selection.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OTableFilterSelectionService extends CorpDataReadonly<FilterOTableSelection>
{
    @Select(OTableFilterSelectionState.get) state$: Observable<FilterSelection<FilterOTableSelection>>;

    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService,
        private _authService: AuthService
    )
    {
        super(FilterOTableSelection);

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['filter-selection']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.selection, this.value)) {
                    this.value = this._helperService.getDeepClone(x.selection);
                }
            }
        });
    }

    changeByProperty(nameFunction: ((obj: FilterOTableSelection) => any) | (new(...params: any[]) => FilterOTableSelection), value: any): void {
        const param = LambdaExpression.getParameters<FilterOTableSelection>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);

        this._store.dispatch(new ChangeOTableFilterSelection(param));
    }

    public applyFilter(selected: FilterOTableSelected): void {
        this._store.dispatch(new ChangeOTableFilterSelection(selected));
    }



}
