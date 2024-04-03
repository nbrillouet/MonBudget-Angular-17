import { Injectable } from '@angular/core';
import { CorpDataReadonly, LambdaExpression } from '@corporate/data';
import { FilterSelected } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangeAsMainFilterSelected } from 'app/state/account-statement/as-main/as-main-filter-selected/as-main-filter-selected.action';
import { AsMainFilterSelectedState } from 'app/state/account-statement/as-main/as-main-filter-selected/as-main-filter-selected.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AsMainFilterSelectedService extends CorpDataReadonly<FilterAsMainSelected>
{
    @Select(AsMainFilterSelectedState.get) state$: Observable<FilterSelected<FilterAsMainSelected>>;

    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService
    )
    {
        super(FilterAsMainSelected);

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['filter-selected']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.selected, this.value)) {
                    this.value = this._helperService.getDeepClone(x.selected);
                }
            }
        });
    }

    change(nameFunction: ((obj: FilterAsMainSelected) => any) | (new(...params: any[]) => FilterAsMainSelected), value: any): void {
        const param = LambdaExpression.getParameters<FilterAsMainSelected>(nameFunction.toString(), this._helperService.getDeepClone(this.value), value);
        this._store.dispatch(new ChangeAsMainFilterSelected(param));
    }

}
