import { Injectable } from '@angular/core';
import { CorpDataReadonly } from '@corporate/data';
import { Datas } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { BankFamilyForList } from 'app/model/referential/bank-family.model';
import { HelperService } from 'app/services/helper.service';
import { LoadAccountList } from 'app/state/referential/account/account-list/account-list.action';
import { AccountListState } from 'app/state/referential/account/account-list/account-list.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AccountListService extends CorpDataReadonly<BankFamilyForList>
{
    @Select(AccountListState.get) public state$: Observable<Datas<BankFamilyForList[]>>;

    public isStoreLoaded: boolean=false;

    /**
     * Constructor
     */
    constructor(
        public _store: Store,
        private _helperService: HelperService
    )
    {
        super(BankFamilyForList);

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

    // // -----------------------------------------------------------------------------------------------------
    // // @ Public methods
    // // -----------------------------------------------------------------------------------------------------
    loadAccountList(idUser: number): void {
        this._store.dispatch(new LoadAccountList({idUser: idUser}));
    }

    // changeAsiFolderExplorer(idUser: number, idFolder: number): void {
    //     this._store.dispatch(new ChangeAsiFolderExplorer({idFolder: idFolder, idUser: idUser}));
    // }

    // uploadFile(user: UserForAuth, formData: FormData): void {
    //     this._store.dispatch(new UploadAsiFile({user: user, formData: formData }));
    // }
}
