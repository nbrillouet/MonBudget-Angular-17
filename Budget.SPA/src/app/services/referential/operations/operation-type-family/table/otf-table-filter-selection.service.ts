import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { Pagination } from '@corporate/mat-table-filter';
import { FilterSelection } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthService } from 'app/core/auth/auth.service';
import { FilterOtfTableSelected, FilterOtfTableSelection } from 'app/model/filters/operation-type-family.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeOtfTableFilterSelected } from 'app/state/referential/operation-type-family/otf-table/otf-table-filter-selected/otf-table-filter-selected.action';
import { ChangeOtfTableFilterSelection } from 'app/state/referential/operation-type-family/otf-table/otf-table-filter-selection/otf-table-filter-selection.action';
import { OtfTableFilterSelectionState } from 'app/state/referential/operation-type-family/otf-table/otf-table-filter-selection/otf-table-filter-selection.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OtfTableFilterSelectionService extends CorpDataReadonly<FilterOtfTableSelection>
{
    @Select(OtfTableFilterSelectionState.get) state$: Observable<FilterSelection<FilterOtfTableSelection>>;

    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService,
        private _authService: AuthService
    )
    {
        super(FilterOtfTableSelection);

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['filter-selection']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.selection, this.value)) {
                    this.value = this._helperService.getDeepClone(x.selection);
                }

                // this.isStateLoaded = true;
                // if(!this._helperService.areEquals(x.selected, this.value)) {
                //     this.value = this._helperService.getDeepClone(x.selected);
                //     this._store.dispatch(new LoadAsTableFilterSelection(this.value));
                // }
            }
        });
    }

    changeByProperty(nameFunction: ((obj: FilterOtfTableSelection) => any) | (new(...params: any[]) => FilterOtfTableSelection), value: any): void {
        const param = LambdaExpression.getParameters<FilterOtfTableSelection>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);

        this._store.dispatch(new ChangeOtfTableFilterSelection(param));
    }

    public applyFilter(selected: FilterOtfTableSelected): void {
        // if(Object.keys(this.value).length !== 0){
        this._store.dispatch(new ChangeOtfTableFilterSelection(selected));
        // }
        // else{
            // const filter = new FilterOtfTableSelected( {user: this._authService.user, pagination: new Pagination()});
            // this._store.dispatch(new ChangeOtfTableFilterSelection(filter));
            // this._store.dispatch(new ChangeOtfTableFilterSelected(filter));
        // }
    }


}
