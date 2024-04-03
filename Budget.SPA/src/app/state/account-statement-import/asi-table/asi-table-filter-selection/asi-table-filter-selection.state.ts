import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { FilterAsiTableSelection } from 'app/model/filters/account-statement-import.filter';
import { FilterSelection } from 'app/model/generics/filter.info.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadAsiTableFilterSelection } from './asi-table-filter-selection.action';


export class AsiTableFilterSelectionStateModel extends FilterSelection<FilterAsiTableSelection> {
    constructor() {
        super(FilterAsiTableSelection);
    }
}

const asiTableFilterSelectionStateModel = new AsiTableFilterSelectionStateModel();

@State<AsiTableFilterSelectionStateModel>({
    name: 'AsiTableFilterSelection',
    defaults : asiTableFilterSelectionStateModel
})

@Injectable()
export class AsiTableFilterSelectionState extends LoaderState {

    constructor(
        private _asiService: AsiService
        ) {
            super();
    }

    @Selector()
    static get(state: AsiTableFilterSelectionStateModel): any { return state; }

    @Action(LoadAsiTableFilterSelection)
    loadAsiTableFilterSelection(context: StateContext<AsiTableFilterSelectionStateModel>, action: LoadAsiTableFilterSelection): void {
        this.loading(context,'filter-selection');

        context.patchState({
            selection: null
        });

        this._asiService.getAsiTableFilter(action.payload).subscribe((result)=> {
            context.patchState({
                selection: result
            });

            this.loaded(context,'filter-selection');
        });

    }

}
