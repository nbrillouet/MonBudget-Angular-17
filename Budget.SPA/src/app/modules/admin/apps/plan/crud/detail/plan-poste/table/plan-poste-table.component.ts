import { Component, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableFilter } from '@corporate/mat-table-filter';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { FilterPlanPosteTableSelected, PlanPosteDetailFilter } from 'app/model/filters/plan-poste.filter';
import { HelperService } from 'app/services/helper.service';
import { PlanPosteDetailComponent } from '../detail/plan-poste-detail.component';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { PlanPosteTableService } from 'app/services/plan/crud/detail/plan-poste/table/plan-poste-table.service';
import { PLAN_COLUMNS } from 'app/services/plan/crud/table/constants';

@Component({
    selector       : 'plan-poste-table',
    templateUrl    : './plan-poste-table.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class PlanPosteTableComponent implements OnInit, OnDestroy
{
    @Input() idPlan: number;
    @Input() idPoste: number;

    matTableFilter: MatTableFilter;
    idFile: number;


    constructor(
        private _dialog: MatDialog,
        private _fuseConfirmationService: FuseConfirmationService,
        public _userLoggedService: UserLoggedService,
        public _planPosteTableService: PlanPosteTableService,
        public _helperService: HelperService

     )
    {
        this.matTableFilter = {
            columns: PLAN_COLUMNS,
            filterSelection$: this._planPosteTableService.stateSelection$,
            filterSelected$: this._planPosteTableService.stateSelected$,
            table$: this._planPosteTableService.stateTable$,
            toolbar: { buttonAdd: {enabled: true }, buttonDelete: {enabled:true}, buttonFullscreen: {enabled:false} },
            clickOnRow: true
        };
    }

    ngOnDestroy(): void {

    }

    ngOnInit(): void {
        this._planPosteTableService.initFilterSelected(this.idPlan, this.idPoste);
    }

    addItem($event): void {
        this.openDetail(null);
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
                this._planPosteTableService.delete($event);
            }
        });
    }

    applyFilterSelected(selected: FilterPlanPosteTableSelected): void {
        this._planPosteTableService.applyFilterSelected(selected);
    }

    applyFilterSelection(selected: FilterPlanPosteTableSelected): void {
        this._planPosteTableService.applyFilterSelection(selected);
    }

    onRowClick($event): void {
        this.openDetail($event.id);
    }

    openDetail(idPlanPoste: number): void {
        this._dialog.open(PlanPosteDetailComponent,
            {
                autoFocus: false,
                disableClose: true,
                width: '35%',
                // height: '400px',
                data: new PlanPosteDetailFilter(
                    {
                        id: idPlanPoste,
                        idPlan: this.idPlan,
                        idPoste: this.idPoste,
                        idUserGroup: this._userLoggedService.userForInfo.idUserGroup
                    }
                )
            })
            .afterClosed()
            .subscribe(() => {
                this._planPosteTableService.reloadTable();
            });
      }

}
