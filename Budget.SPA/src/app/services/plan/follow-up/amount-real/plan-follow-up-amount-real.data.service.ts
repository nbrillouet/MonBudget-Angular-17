import { Injectable } from '@angular/core';
import { CorpDataReadonly } from '@corporate/data';
import { DatasFilter } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AsForTable } from 'app/model/account-statement/account-statement-table.model';
import { PlanFollowUpAmountRealFilter } from 'app/model/filters/plan-follow-up-amount-real.filter';
import { HelperService } from 'app/services/helper.service';
import { ChangePlanFollowUpAmountRealFilter } from 'app/state/plan/plan-follow-up/amount-real/plan-follow-up-amount-real.action';
import { PlanFollowUpAmountRealState } from 'app/state/plan/plan-follow-up/amount-real/plan-follow-up-amount-real.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PlanFollowUpAmountRealService extends CorpDataReadonly<AsForTable>
{
    @Select(PlanFollowUpAmountRealState.get) stateTable$: Observable<DatasFilter<AsForTable[], PlanFollowUpAmountRealFilter>>;

    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _helperService: HelperService
    )
    {
        super(AsForTable);

        this.stateTable$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['datas']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.datas, this.value)) {
                    this.value = this._helperService.getDeepClone(x.datas);
                }
            }
        });
    }

    load(filter: PlanFollowUpAmountRealFilter): void {
        this._store.dispatch(new ChangePlanFollowUpAmountRealFilter(filter));
    }



}
