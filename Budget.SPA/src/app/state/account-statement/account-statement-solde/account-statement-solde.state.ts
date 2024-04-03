import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { AsSolde } from 'app/model/account-statement/account-statement-solde.model';
import { FilterAsMainSelected, FilterAsTableSelected } from 'app/model/filters/account-statement.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsApiService } from '../as-api.service';
import { ChangeAsSolde } from './account-statement-solde.action';


export class AsSoldeStateModel extends Datas<AsSolde> {
    constructor() {
        super();
    }
}

const detailInfo = new AsSoldeStateModel();

@State<AsSoldeStateModel>({

    name: 'asSolde',
    defaults : detailInfo
})

@Injectable()
export class AsSoldeState extends LoaderState {
    constructor(
        private _asApiService: AsApiService
    ) {
        super();
    }

    @Selector()
    static get(state: AsSoldeStateModel): any { return state; }

    @Selector()
    static getFilter(state: FilterAsTableSelected): any { return state; }

    @Action(ChangeAsSolde)
    loadAsSolde(context: StateContext<AsSoldeStateModel>, action: ChangeAsSolde): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        if(action.payload?.idAccount && action.payload?.user && action.payload?.monthYear?.month && action.payload?.monthYear?.year) {
            this._asApiService.getAsSolde(action.payload)
                .pipe(finalize(()=> {this.loaded(context,'datas');}))
                .subscribe(
                    (result) => {
                        context.patchState({
                            datas: result
                        });
                    }
                );
        }
        this.loading(context,'datas');
    }
}
