import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAsMainSelection } from 'app/model/filters/account-statement.filter';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsApiService } from '../../as-api.service';
import { ChangeAsMainFilterSelected } from '../as-main-filter-selected/as-main-filter-selected.action';
import { ChangeAsMainFilterSelection } from './as-main-filter-selection.action';

export class AsMainFilterSelectionStateModel extends FilterSelection<FilterAsMainSelection> {
    constructor() {
        super(FilterAsMainSelection);
    }
}

const asMainFilterSelectionStateModel = new AsMainFilterSelectionStateModel();

@State<AsMainFilterSelectionStateModel>({
    name: 'AsMainFilterSelection',
    defaults : asMainFilterSelectionStateModel
})

@Injectable()
export class AsMainFilterSelectionState extends LoaderState {

    constructor(
        private _store: Store,
        private _asApiService: AsApiService,
        private _helperService: HelperService
        ) {
            super();
    }

    @Selector()
    static get(state: AsMainFilterSelectionStateModel): any { return state; }

    @Action(ChangeAsMainFilterSelection)
    changeAsMainFilterSelection(context: StateContext<AsMainFilterSelectionStateModel>, action: ChangeAsMainFilterSelection): void {

        this.loading(context,'filter-selection');

        //obligation presence idUser et idAccount
        if(action.payload?.idAccount && action.payload?.user) {
            this._asApiService.getAsMainFilterSelection(action.payload)
                .pipe(finalize(()=> {this.loaded(context,'filter-selection');}))
                .subscribe(
                    (res) => {
                        context.patchState({
                            selection: res
                        });
                        //initialisation du selected apres remplissage selection
                        if(!action.payload.monthYear.year) {
                            const payload = this._helperService.getDeepClone(action.payload);
                            payload.monthYear = {month: res.month[0], year: res.year[0]};
                            this._store.dispatch(new ChangeAsMainFilterSelected(payload));
                        }
                    }
                );
        }
    }

}
