import { Injectable } from '@angular/core';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAsiTableSelected } from 'app/model/filters/account-statement-import.filter';
import { FilterSelected } from 'app/model/generics/filter.info.model';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadAsiTable } from '../asi-table.action';
import { UpdateAsiTableFilterSelected, UpdateAsiTableFilterSelectedByProperties } from './asi-table-filter-selected.action';


export class AsiTableFilterSelectedStateModel extends FilterSelected<FilterAsiTableSelected> {
    constructor() {
        super(FilterAsiTableSelected);
    }
}

const asiTableFilterSelectedStateModel = new AsiTableFilterSelectedStateModel();

@State<AsiTableFilterSelectedStateModel>({
    name: 'AsiTableFilterSelected',
    defaults : asiTableFilterSelectedStateModel
})

@Injectable()
export class AsiTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store
        // private _helperService: HelperService
        ) {
            super();
    }

    @Selector()
    static get(state: AsiTableFilterSelectedStateModel): any { return state; }

    @Action(UpdateAsiTableFilterSelectedByProperties)
    updateAsiTableFilterSelectedByProperties(context: StateContext<AsiTableFilterSelectedStateModel>, action: UpdateAsiTableFilterSelectedByProperties): void {
        this.loading(context,'filter-selected');

        // let selected: FilterAsiTableSelected;

        // selected = this._helperService.getDeepClone(context.getState().selected);
        // selected.isPaginationUpdate = false;

        // action.payload.properties.forEach( (property) => {
        //     selected = this._helperService.setDeepProperty(selected,property.name,property.value);
        //     if(property.name==='pagination'){
        //         selected.isPaginationUpdate=true;
        //     }

        // });

        // this.updateAsiTableFilterSelectedCommon(selected, context);
    }

    @Action(UpdateAsiTableFilterSelected)
    updateAsiTableFilterSelected(context: StateContext<AsiTableFilterSelectedStateModel>, action: UpdateAsiTableFilterSelected): void {
        this.loading(context,'filter-selected');

        const selected: FilterAsiTableSelected = action.payload;

        selected.isPaginationUpdate = false;

        this.updateAsiTableFilterSelectedCommon(selected, context);

    }

    updateAsiTableFilterSelectedCommon(selected: FilterAsiTableSelected, context: StateContext<AsiTableFilterSelectedStateModel>): void {
        //user
        // selected.user = selected.user == null ? this._helperService.getUserForGroupFromStorage() : selected.user;

        context.patchState({ selected: selected });

        this.loaded(context,'filter-selected');

        //Pagination est donnée par la table
        if(!selected.isPaginationUpdate) { this._store.dispatch(new LoadAsiTable(context.getState().selected)); }
    }

}
