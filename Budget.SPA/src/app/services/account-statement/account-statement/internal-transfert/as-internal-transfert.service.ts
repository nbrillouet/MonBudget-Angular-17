import { Injectable } from '@angular/core';
import { CorpDataReadonly } from '@corporate/data';
import { Datas } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { InternalTransfertCouple } from 'app/model/account-statement/account-statement-internal-transfer.model';
import { FilterAsMainSelected } from 'app/model/filters/account-statement.filter';
import { HelperService } from 'app/services/helper.service';
import { LoadAsInternalTransfertCouple } from 'app/state/account-statement/account-statement-internal-transfer/as-internal-transfert.action';
import { AsInternalTransfertState } from 'app/state/account-statement/account-statement-internal-transfer/as-internal-transfert.state';
import { Observable } from 'rxjs';
import { AsMainFilterSelectedService } from '../main/as-main-filter-selected.service';

@Injectable()
export class AsInternalTransfertService extends CorpDataReadonly<InternalTransfertCouple>
{
    // @Select(AsTableFilterSelectedState.get) asTableFilterSelected$: Observable<FilterSelected<FilterAsTableSelected>>;
    @Select(AsInternalTransfertState.get) state$: Observable<Datas<InternalTransfertCouple[]>>;

    /**
     * Constructor
     */
    constructor(
        private _helperService: HelperService,
        private _store: Store,
        // private _formBuilder: FormBuilder,
        public _selectedService: AsMainFilterSelectedService,
    )
    {
        super(InternalTransfertCouple);

        this._selectedService.state$.subscribe((x)=> {
            if(x?.loader['filter-selected']?.loaded) {
                this.changeGlobal(x.selected);
            }
        });

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['datas']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.datas, this.value)) {
                    this.value = this._helperService.getDeepClone(x.datas);
                }
            }

            // if(x?.loader['asChartEvolutionBrut']?.loaded) {
            //     this.asChartEvolutionBrutDebit = x.datas.brut.debit;
            //     this.asChartEvolutionBrutCredit = x.datas.brut.credit;
            //     this.asChartEvolutionBrutBalance = x.datas.brut.balance;
            // }

            // if(x?.loader['asChartEvolutionNoIntTransfer']?.loaded) {
            //     this.asChartEvolutionNoIntTransferDebit = x.datas.noIntTransfer.debit;
            //     this.asChartEvolutionNoIntTransferCredit = x.datas.noIntTransfer.credit;
            //     this.asChartEvolutionNoIntTransferBalance = x.datas.noIntTransfer.balance;
            // }

            // if(x?.loader['asChartEvolutionCustomOtf']?.loaded) {
            //     this.asChartEvolutionCustomOtfs = x.datas.customOtfs.widgetCardChartBars;
            // }

            // if(x?.loader['asChartEvolutionCustomOtfFilter']?.loaded) {
            //     this.asChartEvolutionCustomOtfFilter = x.datas.customOtfs.filter;

            //     this.customOtfForm = this._formBuilder.group({
            //         operationTypeFamilies: [this.asChartEvolutionCustomOtfFilter.selected.operationTypeFamilies,[Validators.required]]
            //     });

            //     this.customOtfForm.valueChanges.subscribe((value)=> {
            //         const filter =  {
            //             idAccount : x.datas.customOtfs.filter.selected.idAccount,
            //             user: x.datas.customOtfs.filter.selected.user,
            //             monthYear: x.datas.customOtfs.filter.selected.monthYear,
            //             operationTypeFamilies:value.operationTypeFamilies
            //             } as AsChartEvolutionCustomOtfFilterSelected;
            //         this._store.dispatch(new UpdateAsChartEvolutionCustomOtfFilter(filter));
            //     });
            // }
        });
    }

    changeGlobal(filterAsMainSelected: FilterAsMainSelected): void {
        this._store.dispatch(new LoadAsInternalTransfertCouple(filterAsMainSelected));
    }
}
