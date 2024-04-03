import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Datas } from '@corporate/model';
import { Action, Selector, State, StateContext, Store } from '@ngxs/store';
import { AsiForList, AsiListByBankAgency } from 'app/model/account-statement-import/account-statement-import.model';
import { AsiFile, AsiFolder, AsiFolderExplorer } from 'app/model/account-statement-import/asi-folder-explorer.model';
import { AsifTableService } from 'app/services/account-statement/account-statement-import-file/table/asif-table.service';
import { HelperService } from 'app/services/helper.service';
import { LoaderState } from 'app/state/_base/loader-state';
import { AsiApiService } from '../asi.api.service';
import { ChangeAsiFolderExplorer, LoadAsiFolderExplorer, UploadAsiFile } from './asi-list.action';
import { ToastrService } from 'ngx-toastr';

export class AsiFolderExplorerStateModel extends Datas<AsiFolderExplorer> {
    constructor() {
        super();
    }
}

const listInfo = new AsiFolderExplorerStateModel();
@State<AsiFolderExplorerStateModel>({
    name: 'AsiFolderExplorer',
    defaults : listInfo
})

@Injectable()
export class AsiFolderExplorerState extends LoaderState {
    constructor(
        private _asiApiService: AsiApiService,
        private _router: Router,
        private _asifTableService: AsifTableService
        ) {
            super();
    }

    @Selector()
    static get(state: AsiFolderExplorerStateModel): any { return state; }

    // @Action(LoadAsiList)
    // loadAsiList(context: StateContext<AsiListStateModel>, action: LoadAsiList): void {
    //     this.loading(context,'datas');

    //     context.patchState({
    //         datas: null
    //     });

    //     this._asiApiService.getAsiForList(action.payload.idUser).subscribe((result)=> {
    //         context.patchState({
    //             datas: result
    //         });

    //         this.loaded(context,'datas');
    //     });
    // }

    @Action(LoadAsiFolderExplorer)
    loadAsiFolderExplorer(context: StateContext<AsiFolderExplorerStateModel>, action: LoadAsiFolderExplorer): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._asiApiService.getAsiForList(action.payload.idUser).subscribe((result)=> {

            const asiFolderExplorer: AsiFolderExplorer = this.getAsiFolderExplorer(result);

            context.patchState({
                datas: asiFolderExplorer
            });

            this.loaded(context,'datas');
        });
    }

    @Action(ChangeAsiFolderExplorer)
    changeAsiFolderExplorer(context: StateContext<AsiFolderExplorerStateModel>, action: ChangeAsiFolderExplorer): void {
        this.loading(context,'datas');

        context.patchState({
            datas: null
        });

        this._asiApiService.getAsiForList(action.payload.idUser).subscribe((result)=> {
            const asiFolderExplorer: AsiFolderExplorer = this.getAsiFolderExplorerByIdFolder(action.payload.idFolder, result);

            context.patchState({
                datas: asiFolderExplorer
            });

            this.loaded(context,'datas');
        });
    }

    @Action(UploadAsiFile)
    uploadAsiFile(context: StateContext<AsiFolderExplorerStateModel>, action: UploadAsiFile): void {
        this.loading(context, 'upload-file');

        this._asiApiService.uploadFile(action.payload.user, action.payload.formData).subscribe((result) => {
            this._asifTableService.initFilterAsifTableSelected(result.idImport);
            this._router.navigate(['/apps/account-statement-import/file/', result.idImport]);
             this.loaded(context, 'upload-file');
        }, (err) => {
            this.loaded(context, 'upload-file');
            this.loaded(context, 'upload-file-error');
        });
    }

    private getAsiFolderExplorer(asiForList: AsiForList): AsiFolderExplorer {

        const asiFolderExplorer: AsiFolderExplorer = new AsiFolderExplorer();
        asiForList.asiByBankAgencyList.forEach((x) =>{
            const folder: AsiFolder = new AsiFolder();
            folder.id = x.bankAgency.id;
            folder.label = x.bankAgency.label;
            folder.image = x.bankAgency.bankFamily.url;
            folder.countFile = x.asiForList.length;

            asiFolderExplorer.folders.push(folder);

            x.asiForList.forEach((f)=> {
                const file: AsiFile = new AsiFile();
                file.id = f.id;
                file.dateImport = f.dateImport;
                file.fileImport = f.fileImport;

                asiFolderExplorer.files.push(file);
            });


        });
        asiFolderExplorer.countFile = asiFolderExplorer.files.length;
        asiFolderExplorer.countFolder = asiFolderExplorer.folders.length;

        return asiFolderExplorer;
    }

    private getAsiFolderExplorerByIdFolder(idFolder: number, asiForList: AsiForList): AsiFolderExplorer {
        const asiFolderExplorer: AsiFolderExplorer = new AsiFolderExplorer();

        const asiListByBankAgency = asiForList.asiByBankAgencyList.find(x=>x.bankAgency.id===idFolder) as AsiListByBankAgency;
        const folder: AsiFolder = new AsiFolder();
        folder.id = asiListByBankAgency.bankAgency.id;
        folder.label = asiListByBankAgency.bankAgency.label;
        folder.image = asiListByBankAgency.bankAgency.bankFamily.url;
        folder.countFile = asiListByBankAgency.asiForList.length;

        asiFolderExplorer.folders.push(folder);
        asiFolderExplorer.idFolder = idFolder;
        asiFolderExplorer.countFolder = asiFolderExplorer.folders.length;
        asiFolderExplorer.countFile = asiListByBankAgency.asiForList.length;

        asiListByBankAgency.asiForList.forEach((f)=> {
            const file: AsiFile = new AsiFile();
            file.id = f.id;
            file.dateImport = f.dateImport;
            file.fileImport = f.fileImport;

            asiFolderExplorer.files.push(file);
        });

        return asiFolderExplorer;
    }
}
