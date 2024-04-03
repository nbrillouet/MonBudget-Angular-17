
import { Injectable } from '@angular/core';
import { FilterSelected } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAsifTableSelected } from 'app/model/filters/account-statement-import-file.filter';
import { AsiApiService } from 'app/state/account-statement-import/asi.api.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { LoadAsifTable } from '../asif-table.action';
import { LoadAsifTableFilterSelected, ChangeAsifTableFilterSelected, UpdatePaginationAsifTableFilterSelected } from './asif-table-filter-selected.action';

export class AsifTableFilterSelectedStateModel extends FilterSelected<FilterAsifTableSelected> {
    constructor() {
        super(FilterAsifTableSelected);
    }
}

const asifTableFilterSelectedStateModel = new AsifTableFilterSelectedStateModel();
@State<AsifTableFilterSelectedStateModel>({
    name: 'AsifTableFilterSelected',
    defaults : asifTableFilterSelectedStateModel
})

@Injectable()
export class AsifTableFilterSelectedState extends LoaderState {
    constructor(
        private _store: Store,
        private _asiApiService: AsiApiService
        ) {
            super();
    }

    @Selector()
    static get(state: AsifTableFilterSelectedStateModel): any { return state; }


    @Action(UpdatePaginationAsifTableFilterSelected)
    updatePaginationAsifTableFilterSelected(context: StateContext<AsifTableFilterSelectedStateModel>, action: UpdatePaginationAsifTableFilterSelected): void {
        context.patchState({
            selected: {
                ...context.getState().selected,
                pagination: action.payload
            }
        });
    }

    @Action(ChangeAsifTableFilterSelected)
    changeAsifTableFilterSelected(context: StateContext<AsifTableFilterSelectedStateModel>, action: ChangeAsifTableFilterSelected): void {
        this.loading(context,'filter-selected');

        //chargement des données complémentaire provenant de asi (si idImport est modifié)
        if(action.payload.idImport!==context.getState().selected.idImport) {
            this._asiApiService.getById(action.payload.idImport).subscribe((result)=> {
                context.patchState({
                    selected: {
                        ...action.payload,
                        asiBankAgencyLabel: result.bankAgency.label,
                        asiDateImport: result.dateImport
                    }
                });

                this.loaded(context,'filter-selected');
            });
        }
        else {
            context.patchState({
                selected: action.payload
            });
            this.loaded(context,'filter-selected');
        }

        this._store.dispatch(new LoadAsifTable(action.payload));
    }

    @Action(LoadAsifTableFilterSelected)
    loadAsifTableFilterSelected(context: StateContext<AsifTableFilterSelectedStateModel>, action: LoadAsifTableFilterSelected): void {
        // this.loading(context,'filter-selected');
        // const state = context.getState();
        // state.selected = action.payload;
        // context.patchState(state);

        // //chargement des données complémentaire provenant de asi
        // this._asiApiService.getById(action.payload.idImport).subscribe((result)=> {
        //         // const state = context.getState();
        //         // state.selected.asiBankAgencyLabel = result.bankAgency.label;
        //         // state.selected.asiDateImport = result.dateImport;
        //         // context.patchState(state);

        //         // this.loaded(context,'filter-selected');
        //     });
    }

}

