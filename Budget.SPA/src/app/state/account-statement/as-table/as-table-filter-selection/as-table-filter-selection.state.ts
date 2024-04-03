import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAsTableSelection } from 'app/model/filters/account-statement.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { AsApiService } from '../../as-api.service';
import { ChangeAsTableFilterSelected } from '../as-table-filter-selected/as-table-filter-selected.action';
import { ChangeAsTableFilterSelection } from './as-table-filter-selection.action';

export class AsTableFilterSelectionStateModel extends FilterSelection<FilterAsTableSelection> {
    constructor() {
        super(FilterAsTableSelection);
    }
}

const asTableFilterSelectionStateModel = new AsTableFilterSelectionStateModel();

@State<AsTableFilterSelectionStateModel>({
    name: 'AsTableFilterSelection',
    defaults : asTableFilterSelectionStateModel
})

@Injectable()
export class AsTableFilterSelectionState extends LoaderState {

    constructor(
        private _store: Store,
        private _asApiService: AsApiService
        ) {
            super();
    }

    @Selector()
    static get(state: AsTableFilterSelectionStateModel): any { return state; }

    @Action(ChangeAsTableFilterSelection)
    changeAsTableFilterSelection(context: StateContext<AsTableFilterSelectionStateModel>, action: ChangeAsTableFilterSelection): void {

        this.loading(context,'filter-selection');

        //obligation presence idUser et idAccount
        if(action.payload?.idAccount && action.payload?.user) {
            this._asApiService.getAsTableFilterSelection(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'filter-selection');}))
            .subscribe(
                (res) => {
                    context.patchState({
                        selection: res
                    });
                    //initialisation du selected apres remplissage selection
                    if(!action.payload.monthYear.year) {
                        action.payload.monthYear = {month: res.month[0], year: res.year[0]};
                        this._store.dispatch(new ChangeAsTableFilterSelected(action.payload));
                    }
                }
            );
        }
    }

}

