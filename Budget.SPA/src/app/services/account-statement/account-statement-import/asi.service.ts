import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AsiFolderExplorer } from 'app/model/account-statement-import/asi-folder-explorer.model';
import { UserForAuth } from 'app/model/referential/user/user.model';
import { ChangeAsiFolderExplorer, LoadAsiFolderExplorer, LoadAsiList, UploadAsiFile } from 'app/state/account-statement-import/asi-list/asi-list.action';
import { AsiFolderExplorerState } from 'app/state/account-statement-import/asi-list/asi-list.state';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AsiService
{
    @Select(AsiFolderExplorerState.get) public state$: Observable<Datas<AsiFolderExplorer>>;

    public isStoreLoaded: boolean=false;

    /**
     * Constructor
     */
    constructor(
        public _store: Store
    )
    {
        // this.state$.subscribe((x)=> {
        //     if(x?.loader['datas']?.loaded) {
        //         this.isStoreLoaded = true;

        //     }
        //     if(x?.loader['datas']?.loading) {
        //         this.isStoreLoaded = false;

        //     }
        // });
    }

    // // -----------------------------------------------------------------------------------------------------
    // // @ Public methods
    // // -----------------------------------------------------------------------------------------------------
    loadAsiFolderExplorer(idUser: number): void {
        this._store.dispatch(new LoadAsiFolderExplorer({idUser: idUser}));
    }

    changeAsiFolderExplorer(idUser: number, idFolder: number): void {
        this._store.dispatch(new ChangeAsiFolderExplorer({idFolder: idFolder, idUser: idUser}));
    }

    uploadFile(user: UserForAuth, formData: FormData): void {
        this._store.dispatch(new UploadAsiFile({user: user, formData: formData }));
    }

}
