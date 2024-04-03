import { Injectable } from '@angular/core';
import { FilterSelection } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterAsifTableSelection } from 'app/model/filters/account-statement-import-file.filter';
import { LoaderState } from 'app/state/_base/loader-state';
import { AsifApiService } from '../../asif.api.service';
import { LoadAsifTableFilterSelection } from './asif-table-filter-selection.action';

export class AsifTableFilterSelectionStateModel extends FilterSelection<FilterAsifTableSelection> {
    constructor() {
        super(FilterAsifTableSelection);
    }
}

const asifTableFilterSelectionStateModel = new AsifTableFilterSelectionStateModel();

@State<AsifTableFilterSelectionStateModel>({
    name: 'AsifTableFilterSelection',
    defaults : asifTableFilterSelectionStateModel
})

@Injectable()
export class AsifTableFilterSelectionState extends LoaderState {

    constructor(
        private _asifApiService: AsifApiService
        ) {
            super();
    }

    @Selector()
    static get(state: AsifTableFilterSelectionStateModel): any { return state; }

    @Action(LoadAsifTableFilterSelection)
    loadAsifTableFilterSelection(context: StateContext<AsifTableFilterSelectionStateModel>, action: LoadAsifTableFilterSelection): void {

        this.loading(context,'filter-selection');

        context.patchState({
            selection: null
        });

        this._asifApiService.getAsifTableFilter(action.payload).subscribe((result)=> {
            context.patchState({
                selection: result
            });

            this.loaded(context,'filter-selection');
        });
    }
}
