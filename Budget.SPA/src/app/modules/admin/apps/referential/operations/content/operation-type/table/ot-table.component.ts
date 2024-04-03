import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableFilter, TypeButtonInfo } from '@corporate/mat-table-filter';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { Store } from '@ngxs/store';
import { EnumOperationsUrl } from 'app/model/enum/enum-operations.enum';
import { OT_COLUMNS } from 'app/services/referential/operations/operation-type/table/ot-columns';
import { OtTableService } from 'app/services/referential/operations/operation-type/table/ot-table.service';
import { LoadOtDetail } from 'app/state/referential/operation-type/ot-detail/ot-detail.action';

@Component({
    selector       : 'ot-table',
    templateUrl    : './ot-table.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class OtTableComponent implements OnInit, OnDestroy {
    matTableFilter: MatTableFilter;

    constructor(
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _store: Store,
        private _fuseConfirmationService: FuseConfirmationService,
        public _otTableService: OtTableService
    )
    {
        this.matTableFilter = {
            columns: OT_COLUMNS,
            filterSelection$: this._otTableService._selectionService.state$,
            filterSelected$: this._otTableService._selectedService.state$,
            table$: this._otTableService.state$,
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
        this._store.dispatch(new LoadOtDetail({id: null}));
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
                this._otTableService.delete($event);
            }
        });
    }

    onButtonClick(typeButtonInfo: TypeButtonInfo): void {
        switch(typeButtonInfo.fieldName) {
            case 'buttonO':
                this._router.navigate([`${typeButtonInfo.row.id}/${EnumOperationsUrl.operation}`], {relativeTo: this._activatedRoute});
                break;
            case 'buttonDetail':
                this._store.dispatch(new LoadOtDetail({id: typeButtonInfo.row.id}));
                this._router.navigate([`${typeButtonInfo.row.id}`], {relativeTo: this._activatedRoute});
                break;
        }
    }

    // onButtonClick(typeButtonInfo: TypeButtonInfo): void {
    //     this._router.navigate([`${typeButtonInfo.row.id}/${EnumOperationsUrl.operation}`], {relativeTo: this._activatedRoute});
    // }

}
