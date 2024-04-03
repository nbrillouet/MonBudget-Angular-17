import { Component, OnDestroy, OnInit } from '@angular/core';
import { AsiService } from 'app/services/account-statement/account-statement-import/asi.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector       : 'account-statement-import-header',
    templateUrl    : './asi-header.component.html'
    // encapsulation  : ViewEncapsulation.None
})
export class AsiHeaderComponent implements OnInit, OnDestroy
{
    idBankAgency: number = null;

    constructor(
        public _asiService: AsiService,
        public _userLoggedService: UserLoggedService,
        private _toastrService: ToastrService
    )
    {
        // this._userLoggedService.userLoggedState$.subscribe((x)=>{
        //     const toto = x.datas.userPreference.bannerUrl;
        // });

    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        // this._asiService.state$.subscribe((x)=> {
        // });

        // this._activatedRoute.params.subscribe((routeParams) => {
        //     this.idBankAgency = routeParams['folderId'];

        //     if(!this.idBankAgency) {
        //         this._asiService.loadAsiFolderExplorer(this._authService.user.id);
        //      }
        // });
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
        // // Unsubscribe from all subscriptions
        // this._unsubscribeAll.next();
        // this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    // onFolderClick(idFolder: number): void {
    //     this._router.navigate(['/apps/account-statement-import/folders/', idFolder]);
    //     this._asiService.changeAsiFolderExplorer(this._authService.user.id, idFolder);
    // }

    // onFileClick(idFile: number): void {
    //     this._router.navigate(['/apps/account-statement-import/file/', idFile]);
    // }

    getFileError(t): void {

    }

    getFileSuccess(t): void {

    }

    getFileInProgress(t): void {

    }

    getUploadResponse(t): void {

    }

}
