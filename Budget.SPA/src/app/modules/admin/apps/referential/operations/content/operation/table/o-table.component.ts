import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableFilter, TypeButtonInfo } from '@corporate/mat-table-filter';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { Store } from '@ngxs/store';
import { OTableService } from 'app/services/referential/operations/operation/table/o-table.service';
import { O_COLUMNS } from 'app/services/referential/operations/operation/table/o-columns';
import { LoadODetail } from 'app/state/referential/operation/operation-detail/o-detail.action';

@Component({
    selector       : 'o-table',
    templateUrl    : './o-table.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class OTableComponent implements OnInit, OnDestroy {
    matTableFilter: MatTableFilter;

    constructor(
        private _store: Store,
        private _router: Router,
        private _fuseConfirmationService: FuseConfirmationService,
        private _activatedRoute: ActivatedRoute,
        public _oTableService: OTableService

    )
    {
        this.matTableFilter = {
            columns: O_COLUMNS,
            filterSelection$: this._oTableService._selectionService.state$,
            filterSelected$: this._oTableService._selectedService.state$,
            table$: this._oTableService.state$,
            toolbar: { buttonAdd: {enabled: false }, buttonDelete: {enabled:true}, buttonFullscreen: {enabled:false} },
            clickOnRow: false
        };

    }

    ngOnInit(): void {

    }

    ngOnDestroy(): void {

    }

    onRowClick($event): void {

    }

    addItem($event): void {
        this._store.dispatch(new LoadODetail({id: null}));
        this._router.navigate(['new'], {relativeTo: this._activatedRoute});
    }

    deleteItems($event): void {
        // Open the confirmation dialog
        const confirmation = this._fuseConfirmationService.open({
            title  : 'Suppression ',
            message: 'Etes vous sur de vouloir supprimer ces enregistrements?',
            actions: {
                confirm: {
                    label: 'Suppression'
                },
                cancel: {
                    label: 'Annulation'
                }
            }
        });
        confirmation.afterClosed().subscribe((result) => {
            if (result && result==='confirmed')
            {
                this._oTableService.delete($event);
            }
        });
    }

    onButtonClick(typeButtonInfo: TypeButtonInfo): void {
        switch(typeButtonInfo.fieldName) {
            case 'buttonDetail':
                this._store.dispatch(new LoadODetail({id: typeButtonInfo.row.id}));
                this._router.navigate([`${typeButtonInfo.row.id}`], {relativeTo: this._activatedRoute});
                break;
        }
    }

}
