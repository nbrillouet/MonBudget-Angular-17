import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterForDetail } from '@corporate/model';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { InternalTransfertCouple } from 'app/model/account-statement/account-statement-internal-transfer.model';
import { AsSolde } from 'app/model/account-statement/account-statement-solde.model';
import { AsForTable } from 'app/model/account-statement/account-statement-table.model';
import { AsChartCategorisationSelect } from 'app/model/account-statement/as-chart/as-chart-categorisation.model';
import { AsChartEvolutionCdb, AsChartEvolutionCustomOtfFilter, AsChartEvolutionCustomOtfFilterSelected } from 'app/model/account-statement/as-chart/as-chart-evolution.model';
import { WidgetCardChartBar } from 'app/model/chart/widget-card-chart-bar.model';
import { FilterAsDetail, FilterAsMainSelected, FilterAsMainSelection, FilterAsTableSelected, FilterAsTableSelection } from 'app/model/filters/account-statement.filter';
import { environment } from 'environments/environment';
import { PagedList } from '@corporate/mat-table-filter';
import { Observable } from 'rxjs';

@Injectable()
export class AsApiService {

    baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) {

    }
    getAsMainFilterSelection(filter: FilterAsMainSelected): Observable<FilterAsMainSelection> {
        return this._httpClient
            .post<FilterAsMainSelection>(`${this.baseUrl}account-statements/as-main-filter-selection`,filter);
    }


    getAsTableFilterSelection(filter: FilterAsTableSelected): Observable<FilterAsTableSelection> {
        return this._httpClient
            .post<FilterAsTableSelection>(`${this.baseUrl}account-statements/as-table-filter-selection`,filter);
    }

    getAsTable(filter: FilterAsTableSelected): Observable<PagedList<AsForTable>> {
        return this._httpClient
            .post<PagedList<AsForTable>>(`${this.baseUrl}tables/datas`,filter);
    }

    getDetailFilter(filter: AsForDetail): Observable<FilterAsDetail> {

        return this._httpClient
            .post<FilterAsDetail>(`${this.baseUrl}account-statements/as-detail-filter`,filter);
    }

    getForDetail(filter: FilterForDetail): Observable<AsForDetail> {
        return this._httpClient
            .get<AsForDetail>(`${this.baseUrl}account-statements/${filter.id}/as-detail`);
    }

    getAsSolde(filter: FilterAsMainSelected): Observable<AsSolde> {
        return this._httpClient
            .post<AsSolde>(`${this.baseUrl}account-statements/as-solde`,filter);
    }

    getAsInternalTransfertCouple(filter: FilterAsMainSelected): Observable<InternalTransfertCouple[]> {
        return this._httpClient
            .post<InternalTransfertCouple[]>(`${this.baseUrl}account-statement-internal-transfers/list-filter`,filter);
    }

    update(asForDetail: AsForDetail): Observable<boolean> {
        return this._httpClient
            .post<boolean>(`${this.baseUrl}account-statements/update`,asForDetail);
    }

    getAsChartEvolutionBrut(filter: FilterAsMainSelected): Observable<AsChartEvolutionCdb> {
        return this._httpClient
            .post<AsChartEvolutionCdb>(`${this.baseUrl}account-statement-charts/chart-evolution-brut`,filter);
    }

    getAsChartEvolutionNoIntTransfer(filter: FilterAsMainSelected): Observable<AsChartEvolutionCdb> {
        return this._httpClient
            .post<AsChartEvolutionCdb>(`${this.baseUrl}account-statement-charts/chart-evolution-no-int-transfer`,filter);
    }

    getAsChartEvolutionCustomOtf(filter: FilterAsMainSelected): Observable<WidgetCardChartBar[]> {
        return this._httpClient
            .post<WidgetCardChartBar[]>(`${this.baseUrl}account-statement-charts/chart-evolution-custom-otf`,filter);
    }

    getAsChartEvolutionCustomOtfFilter(filter: FilterAsMainSelected): Observable<AsChartEvolutionCustomOtfFilter> {
        return this._httpClient
            .post<AsChartEvolutionCustomOtfFilter>(`${this.baseUrl}account-statement-charts/chart-evolution-custom-otf-filter`,filter);
    }

    updateAsChartEvolutionCustomOtfFilter(filter: AsChartEvolutionCustomOtfFilterSelected): Observable<any>{
        return this._httpClient
            .post<any>(`${this.baseUrl}account-statement-charts/chart-evolution-custom-otf-filter/update`,filter);
    }

    getAsChartCategorisationDebit(filter: FilterAsMainSelected): Observable<AsChartCategorisationSelect> {
        // filter.user=this.userForGroup;
        return this._httpClient
            .post<AsChartCategorisationSelect>(`${this.baseUrl}account-statement-charts/chart-categorisation-debit`,filter);
    }

    saveAsDetail(asDetail: AsForDetail): Observable<boolean> {
        return this._httpClient
            .post<boolean>(`${this.baseUrl}account-statements/save-as-detail`,asDetail);
    }

}
