import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'app/core/auth/auth.service';
import { AsifTableService } from 'app/services/account-statement/account-statement-import-file/table/asif-table.service';
import { AsiService } from 'app/services/account-statement/account-statement-import/asi.service';
import { GenericFormComponent } from 'app/shared/generic-form/generic-form.component';

@Component({
    selector       : 'account-statement-import-list',
    templateUrl    : './asi-list.component.html'
    // encapsulation  : ViewEncapsulation.None
})
export class AsiListComponent extends GenericFormComponent implements OnInit, OnDestroy
{
    idBankAgency: number = null;

    constructor(
        public _asiService: AsiService,
        private _asifTableService: AsifTableService,
        private _authService: AuthService,
        private _router: Router,
    )
    {
        super();
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

    onFolderClick(idFolder: number): void {
        this._router.navigate(['/apps/account-statement-import/folders/', idFolder]);
        this._asiService.changeAsiFolderExplorer(this._authService.user.id, idFolder);
    }

    onFileClick(idFile: number): void {
        this._asifTableService.initFilterAsifTableSelected(idFile);
        this._router.navigate(['/apps/account-statement-import/file/', idFile]);
    }

}
