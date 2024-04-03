import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Select } from '@corporate/model';
import { AsChartEvolutionService } from 'app/services/account-statement/account-statement/chart-evolution/as-chart-evolution.service';

@Component({
    selector       : 'as-chart-evolution',
    templateUrl    : './as-chart-evolution.component.html',
    encapsulation  : ViewEncapsulation.None
})
export class AsChartEvolutionComponent implements OnInit, OnDestroy {

    constructor(
        // private _asMainService: AsMainService,
        public _asChartEvolutionService: AsChartEvolutionService
        // private _authService: AuthService,
        // private _activatedRoute: ActivatedRoute
    )
    {
        // this._asChartEvolutionService._selectedService.change(x=>x.)
    }

    ngOnInit(): void {

    }

    ngOnDestroy(): void {

    }

    compareObjects(o1: Select, o2: Select): boolean {
        return o1 && o2 ? o1.id === o2.id : o1 === o2;
    }

}
