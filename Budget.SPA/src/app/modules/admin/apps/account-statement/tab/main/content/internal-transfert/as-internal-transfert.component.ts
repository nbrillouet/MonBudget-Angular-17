import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AsInternalTransfertService } from 'app/services/account-statement/account-statement/internal-transfert/as-internal-transfert.service';

@Component({
    selector       : 'as-internal-transfert',
    templateUrl    : './as-internal-transfert.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AsInternalTransfertComponent implements OnInit, OnDestroy {

    constructor(
        // private _asMainService: AsMainService,
        public _asInternalTransfertService: AsInternalTransfertService,
        // private _authService: AuthService,
        // private _activatedRoute: ActivatedRoute
    )
    {

    }

    ngOnInit(): void {

    }

    ngOnDestroy(): void {

    }

}
