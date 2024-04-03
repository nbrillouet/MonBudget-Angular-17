import { Injectable } from '@angular/core';
import { DataInfo } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { FilterAccountDetail } from 'app/model/filters/account.filter';
import { FilterPlanPosteDetail } from 'app/model/filters/plan-poste.filter';
import { ReferentialService } from 'app/services/referential/referential.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { finalize } from 'rxjs';
import { PlanPosteApiService } from '../../plan-poste.api.service';
import { ChangePlanPostePlanPosteReference } from '../plan-poste-detail.action';
import { ClearPlanPosteDetailFilter, LoadPlanPosteDetailFilter, PlanPosteDetailFilterChangePlanPosteReference } from './plan-poste-detail-filter.action';

export class PlanPosteDetailFilterStateModel extends DataInfo<FilterPlanPosteDetail> {
    constructor() {
        super();
    }
}

const planPosteDetailFilterStateModel = new PlanPosteDetailFilterStateModel();
@State<PlanPosteDetailFilterStateModel>({
    name: 'PlanPosteDetailFilter',
    defaults: planPosteDetailFilterStateModel
})

@Injectable()
export class PlanPosteDetailFilterState extends LoaderState {
    constructor(
        private _planPosteApiService: PlanPosteApiService,
        private _referentialService: ReferentialService,
        private _store: Store
    ) {
        super();
    }

    @Selector() static get(state: PlanPosteDetailFilterStateModel): any { return state; }

    @Action(LoadPlanPosteDetailFilter)
    loadPlanPosteDetailFilter(context: StateContext<PlanPosteDetailFilterStateModel>, action: LoadPlanPosteDetailFilter): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._planPosteApiService.getForDetailFilter(action.payload.idUserGroup, action.payload.planPosteForDetail)
            .pipe(finalize(()=> {this.loaded(context,'datas');}))
            .subscribe((result) => {
                context.patchState({
                    datas: result
                });
            });
    }

    @Action(ClearPlanPosteDetailFilter)
    clearPlanPosteDetailFilter(context: StateContext<PlanPosteDetailFilterStateModel>): void {
        context.setState(new PlanPosteDetailFilterStateModel());
    }


    //====================================
    //          Plan Poste Reference
    //====================================
    // changement PlanPosteReference list
    @Action(PlanPosteDetailFilterChangePlanPosteReference)
    planPosteDetailFilterChangePlanPosteReference(context: StateContext<PlanPosteDetailFilterStateModel>, action: PlanPosteDetailFilterChangePlanPosteReference): void {
        this.loading(context,'plan-poste-reference-list');
        context.patchState({
            datas: {
                ...context.getState().datas,
                planPosteReference: []
            }
        });

        this._planPosteApiService.getPlanPosteReferenceList(action.payload)
            .pipe(finalize(()=> {this.loaded(context,'plan-poste-reference-list');}))
            .subscribe((result)=> {
                context.patchState({
                    datas: {
                        ...context.getState().datas,
                        planPosteReference: result
                    }
                });
                this._store.dispatch(new ChangePlanPostePlanPosteReference(null));
            });
    }

    // //====================================
    // //          Bank agency
    // //====================================
    // // changement bank agency list
    // @Action(AccountDetailFilterChangeBankAgency)
    // accountDetailFilterChangeBankAgency(context: StateContext<AccountDetailFilterStateModel>, action: AccountDetailFilterChangeBankAgency): void {
    //     this.loading(context,'bank-agency-list');

    //     context.patchState({
    //         datas: {
    //             ...context.getState().datas,
    //             bankAgency: []
    //         }
    //     });
    //     this._store.dispatch(new AccountDetailChangeBankAgency( { bankAgency: null }));

    //     if(action.payload.bankSubFamily?.id) {
    //         this._referentialService.bankAgencyService.getSelectList(action.payload.bankSubFamily?.id)
    //         .pipe(finalize(()=> { this.loaded(context,'bank-agency-list'); }))
    //         .subscribe((result)=> {
    //             context.patchState({
    //                 datas: {
    //                     ...context.getState().datas,
    //                     bankAgency: result
    //                 }
    //             });
    //         });
    //     }

    // }
}
