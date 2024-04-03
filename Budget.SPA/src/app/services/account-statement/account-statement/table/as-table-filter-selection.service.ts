import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { FilterSelection } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterAsTableSelected, FilterAsTableSelection } from 'app/model/filters/account-statement.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeAsTableFilterSelection } from 'app/state/account-statement/as-table/as-table-filter-selection/as-table-filter-selection.action';
import { AsTableFilterSelectionState } from 'app/state/account-statement/as-table/as-table-filter-selection/as-table-filter-selection.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AsTableFilterSelectionService extends CorpDataReadonly<FilterAsTableSelection>
{
    @Select(AsTableFilterSelectionState.get) state$: Observable<FilterSelection<FilterAsTableSelection>>;

    // corp: CorpStateReadonly<FilterAsTableSelected> = new CorpStateReadonly<FilterAsTableSelected>(FilterAsTableSelected);
    // value: FilterAsTableSelected = new FilterAsTableSelected();
    // model: CorpReadonly<FilterAsTableSelected> = new CorpReadonly<FilterAsTableSelected>(FilterAsTableSelected);
    // isStateLoaded: boolean = false;

    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService
    )
    {
        super(FilterAsTableSelection);

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



    // public getValue(property: string): any {

    //     return this._asifDetailService.asifForm.getValue(property);
    // }

    change(nameFunction: ((obj: FilterAsTableSelection) => any) | (new(...params: any[]) => FilterAsTableSelection), value: any): void {
        const param = LambdaExpression.getParameters<FilterAsTableSelection>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);

        this._store.dispatch(new ChangeAsTableFilterSelection(param));
    }

    public applyFilter(selected: FilterAsTableSelected): void {
        this._store.dispatch(new ChangeAsTableFilterSelection(selected));
    }



}
