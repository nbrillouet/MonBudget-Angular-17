import { Injectable } from '@angular/core';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { BankFamilyForList } from 'app/model/referential/bank-family.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { AccountApiService } from '../account.api.service';
import { LoadAccountList } from './account-list.action';

export class AccountListStateModel extends Datas<BankFamilyForList[]> {
    constructor() {
        super();
    }
}

const listInfo = new AccountListStateModel();
@State<AccountListStateModel>({
    name: 'AccountList',
    defaults : listInfo
})

@Injectable()
export class AccountListState extends LoaderState {
    constructor(
        private _accountApiService: AccountApiService,
        // private _router: Router,
        // private _helperService: HelperService,
        // private _store: Store,
        // private _asifTableService: AsifTableService,
        // public _notificationsService: NotificationsService
        ) {
            super();
    }

    @Selector()
    static get(state: AccountListStateModel): any { return state; }


    @Action(LoadAccountList)
    loadAccountList(context: StateContext<AccountListStateModel>, action: LoadAccountList): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._accountApiService.getForList(action.payload.idUser).subscribe((result)=> {

            // const asiFolderExplorer: AsiFolderExplorer = this.getAsiFolderExplorer(result);

            context.patchState({
                datas: result
            });

            this.loaded(context,'datas');
        });
    }

    // @Action(ChangeAsiFolderExplorer)
    // changeAsiFolderExplorer(context: StateContext<AsiFolderExplorerStateModel>, action: ChangeAsiFolderExplorer): void {
    //     this.loading(context,'datas');

    //     context.patchState({
    //         datas: null
    //     });

    //     this._asiApiService.getAsiForList(action.payload.idUser).subscribe((result)=> {
    //         const asiFolderExplorer: AsiFolderExplorer = this.getAsiFolderExplorerByIdFolder(action.payload.idFolder, result);

    //         context.patchState({
    //             datas: asiFolderExplorer
    //         });

    //         this.loaded(context,'datas');
    //     });
    // }

    // @Action(UploadAsiFile)
    // uploadAsiFile(context: StateContext<AsiFolderExplorerStateModel>, action: UploadAsiFile): void {
    //     this.loading(context, 'upload-file');

    //     this._asiApiService.uploadFile(action.payload.user, action.payload.formData).subscribe((result) => {
    //         this._asifTableService.initFilterAsifTableSelected(result.idImport);
    //         this._router.navigate(['/apps/account-statement-import/file/', result.idImport]);
    //          this.loaded(context, 'upload-file');
    //     }, (err) => {
    //         this.loaded(context, 'upload-file');
    //         this.loaded(context, 'upload-file-error');
    //     });
    // }

    // private getAsiFolderExplorer(asiForList: AsiForList): AsiFolderExplorer {

    //     const asiFolderExplorer: AsiFolderExplorer = new AsiFolderExplorer();
    //     asiForList.asiByBankAgencyList.forEach((x) =>{
    //         const folder: AsiFolder = new AsiFolder();
    //         folder.id = x.bankAgency.id;
    //         folder.label = x.bankAgency.label;
    //         folder.image = x.bankAgency.bankFamily.url;
    //         folder.countFile = x.asiForList.length;

    //         asiFolderExplorer.folders.push(folder);

    //         x.asiForList.forEach((f)=> {
    //             const file: AsiFile = new AsiFile();
    //             file.id = f.id;
    //             file.dateImport = f.dateImport;
    //             file.fileImport = f.fileImport;

    //             asiFolderExplorer.files.push(file);
    //         });


    //     });
    //     asiFolderExplorer.countFile = asiFolderExplorer.files.length;
    //     asiFolderExplorer.countFolder = asiFolderExplorer.folders.length;

    //     return asiFolderExplorer;
    // }

    // private getAsiFolderExplorerByIdFolder(idFolder: number, asiForList: AsiForList): AsiFolderExplorer {
    //     const asiFolderExplorer: AsiFolderExplorer = new AsiFolderExplorer();

    //     const asiListByBankAgency = asiForList.asiByBankAgencyList.find(x=>x.bankAgency.id===idFolder) as AsiListByBankAgency;
    //     const folder: AsiFolder = new AsiFolder();
    //     folder.id = asiListByBankAgency.bankAgency.id;
    //     folder.label = asiListByBankAgency.bankAgency.label;
    //     folder.image = asiListByBankAgency.bankAgency.bankFamily.url;
    //     folder.countFile = asiListByBankAgency.asiForList.length;

    //     asiFolderExplorer.folders.push(folder);
    //     asiFolderExplorer.idFolder = idFolder;
    //     asiFolderExplorer.countFolder = asiFolderExplorer.folders.length;
    //     asiFolderExplorer.countFile = asiListByBankAgency.asiForList.length;

    //     asiListByBankAgency.asiForList.forEach((f)=> {
    //         const file: AsiFile = new AsiFile();
    //         file.id = f.id;
    //         file.dateImport = f.dateImport;
    //         file.fileImport = f.fileImport;

    //         asiFolderExplorer.files.push(file);
    //     });

    //     return asiFolderExplorer;
    // }
}
