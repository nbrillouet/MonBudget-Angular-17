import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { InternalTransfertCouple } from 'app/model/account-statement/account-statement-internal-transfer.model';
import { FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { AsApiService } from '../as-api.service';
import { LoadAsInternalTransfertCouple } from './as-internal-transfert.action';

export class AsInternalTransfertStateModel extends Datas<InternalTransfertCouple[]> {
    constructor() {
        super();
    }
}

const detailInfo = new AsInternalTransfertStateModel();

@State<AsInternalTransfertStateModel>({

    name: 'asInternalTransfert',
    defaults : detailInfo
})

@Injectable()
export class AsInternalTransfertState extends LoaderState {
    constructor(
        private _asApiService: AsApiService
    ) {
        super();
    }

    @Selector()
    static get(state: AsInternalTransfertStateModel): any { return state; }

    @Selector()
    static getFilter(state: FilterAsTableSelected): any { return state;  }

    @Action(LoadAsInternalTransfertCouple)
    loadAsInternalTransfertCouple(context: StateContext<AsInternalTransfertStateModel>, action: LoadAsInternalTransfertCouple): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._asApiService.getAsInternalTransfertCouple(action.payload).subscribe((result)=> {
            context.patchState({
                datas: result
            });

            this.loaded(context,'datas');
        });
    }

}
