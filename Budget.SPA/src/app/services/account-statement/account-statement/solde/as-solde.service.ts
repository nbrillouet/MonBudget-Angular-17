import { Injectable } from '@angular/core';
import { CorpDataReadonly } from '@corporate/data';
import { Datas } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AsSolde } from 'app/model/account-statement/account-statement-solde.model';
import { HelperService } from 'app/services/helper.service';
import { AsSoldeState } from 'app/state/account-statement/account-statement-solde/account-statement-solde.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AsSoldeService extends CorpDataReadonly<AsSolde>
{
    @Select(AsSoldeState.get) state$: Observable<Datas<AsSolde>>;

    constructor(
        private _helperService: HelperService
    )
    {
        super(AsSolde);

        this.state$.subscribe((x) => {
            this.isStateLoaded = false;
            if(x?.loader['datas']?.loaded) {
                this.isStateLoaded = true;
                if(!this._helperService.areEquals(x.datas, this.value)) {
                    this.value = this._helperService.getDeepClone(x.datas);
                }
            }
        });
    }
}

