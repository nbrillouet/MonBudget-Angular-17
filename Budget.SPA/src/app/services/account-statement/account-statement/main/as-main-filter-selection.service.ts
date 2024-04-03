import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { FilterSelection } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterAsMainSelection } from 'app/model/filters/account-statement.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeAsMainFilterSelection } from 'app/state/account-statement/as-main/as-main-filter-selection/as-main-filter-selection.action';
import { AsMainFilterSelectionState } from 'app/state/account-statement/as-main/as-main-filter-selection/as-main-filter-selection.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AsMainFilterSelectionService extends CorpDataReadonly<FilterAsMainSelection>
{
    @Select(AsMainFilterSelectionState.get) state$: Observable<FilterSelection<FilterAsMainSelection>>;

    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService
    )
    {
        super(FilterAsMainSelection);

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

    change(nameFunction: ((obj: FilterAsMainSelection) => any) | (new(...params: any[]) => FilterAsMainSelection), value: any): void {
        const param = LambdaExpression.getParameters<FilterAsMainSelection>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);

        this._store.dispatch(new ChangeAsMainFilterSelection(param));
    }

}
