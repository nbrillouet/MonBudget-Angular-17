import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { ChangeAsSolde } from '../../account-statement-solde/account-statement-solde.action';
import { ChangeAsMainFilterSelection } from '../as-main-filter-selection/as-main-filter-selection.action';
import { ChangeAsMainFilterSelected } from './as-main-filter-selected.action';

export class AsMainFilterSelectedStateModel extends FilterSelected<FilterAsMainSelected> {
    constructor() {
        super(FilterAsMainSelected);
    }
}

const asMainFilterSelectedStateModel = new AsMainFilterSelectedStateModel();

@State<AsMainFilterSelectedStateModel>({
    name: 'AsMainFilterSelected',
    defaults : asMainFilterSelectedStateModel
})

@Injectable()
export class AsMainFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store,
        private _helperService: HelperService
        ) {
            super();
    }


    @Selector()
    static get(state: AsMainFilterSelectedStateModel): any { return state; }


    @Action(ChangeAsMainFilterSelected)
    changeAsMainFilterSelected(context: StateContext<AsMainFilterSelectedStateModel>, action: ChangeAsMainFilterSelected): void {
        this.loading(context,'filter-selected');

        if(!this._helperService.areEquals(action.payload, context.getState().selected)) {

            context.patchState({
                selected: action.payload
            });

            this._store.dispatch(new ChangeAsMainFilterSelection(action.payload));
            this._store.dispatch(new ChangeAsSolde(action.payload));

        }

        this.loaded(context,'filter-selected');
    }
}
