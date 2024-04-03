import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableFilter, TypeButtonInfo } from '@corporate/mat-table-filter';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { Store } from '@ngxs/store';
import { EnumOperationsUrl } from 'app/model/enum/enum-operations.enum';
import { OTF_COLUMNS } from 'app/services/referential/operations/operation-type-family/table/otf-columns';
import { OtfTableService } from 'app/services/referential/operations/operation-type-family/table/otf-table.service';
import { LoadOtfDetail } from 'app/state/referential/operation-type-family/otf-detail/otf-detail.action';

@Component({
    selector       : 'otf-table',
    templateUrl    : './otf-table.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class OtfTableComponent implements OnInit, OnDestroy {
    matTableFilter: MatTableFilter;

    constructor(
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _fuseConfirmationService: FuseConfirmationService,
        private _store: Store,
        public _otfTableService: OtfTableService,

    )
    {
        this.matTableFilter = {
            columns: OTF_COLUMNS,
            filterSelection$: this._otfTableService._selectionService.state$,
            filterSelected$: this._otfTableService._selectedService.state$,
            table$: this._otfTableService.state$,
            toolbar: { buttonAdd: {enabled: true }, buttonDelete: {enabled:true}, buttonFullscreen: {enabled:false} },
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
        this._store.dispatch(new LoadOtfDetail({id: null}));
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
                this._otfTableService.delete($event);
            }
        });
    }

    onButtonClick(typeButtonInfo: TypeButtonInfo): void {
        switch(typeButtonInfo.fieldName) {
            case 'buttonOt':
                this._router.navigate([`${typeButtonInfo.row.id}/${EnumOperationsUrl.operationType}`], {relativeTo: this._activatedRoute});
                break;
            case 'buttonDetail':
                this._store.dispatch(new LoadOtfDetail({id: typeButtonInfo.row.id}));
                this._router.navigate([`${typeButtonInfo.row.id}`], {relativeTo: this._activatedRoute});
                break;
        }
    }

}
