import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { Pagination } from '@corporate/mat-table-filter';
import { FilterSelection } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterOtTableSelected, FilterOtTableSelection } from 'app/model/filters/operation-type.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeOtTableFilterSelected } from 'app/state/referential/operation-type/ot-table/ot-table-filter-selected/ot-table-filter-selected.action';
import { ChangeOtTableFilterSelection } from 'app/state/referential/operation-type/ot-table/ot-table-filter-selection/ot-table-filter-selection.action';
import { OtTableFilterSelectionState } from 'app/state/referential/operation-type/ot-table/ot-table-filter-selection/ot-table-filter-selection.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OtTableFilterSelectionService extends CorpDataReadonly<FilterOtTableSelection>
{
    @Select(OtTableFilterSelectionState.get) state$: Observable<FilterSelection<FilterOtTableSelection>>;

    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService,
        private _authService: AuthService
    )
    {
        super(FilterOtTableSelection);

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

    changeByProperty(nameFunction: ((obj: FilterOtTableSelection) => any) | (new(...params: any[]) => FilterOtTableSelection), value: any): void {
        const param = LambdaExpression.getParameters<FilterOtTableSelection>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);

        this._store.dispatch(new ChangeOtTableFilterSelection(param));
    }

    public applyFilter(selected: FilterOtTableSelected): void {
        // if(Object.keys(this.value).length !== 0){
            this._store.dispatch(new ChangeOtTableFilterSelection(selected));
        // }
        // else{
        //     const filter = new FilterOtTableSelected( {user: this._authService.user, pagination: new Pagination()});
        //     this._store.dispatch(new ChangeOtTableFilterSelection(filter));
        //     this._store.dispatch(new ChangeOtTableFilterSelected(filter));
        // }

    }



}
