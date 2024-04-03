/* eslint-disable max-len */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterPlanPosteDetail, FilterPlanPosteTableSelected, FilterPlanPosteTableSelection, PlanPosteReferenceFilter } from 'app/model/filters/plan-poste.filter';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { PagedList } from '@corporate/mat-table-filter';
import { PlanPosteForDetail, PlanPosteForTable, PlanPosteFrequencyFilter, PlanPosteFrequencyForDetail } from 'app/model/plan/plan-poste/plan-poste.model';
import { ComboMultiple, SelectGroup } from '@corporate/model';
// import { environment } from "environments/environment";
// import { Injectable } from "@angular/core";
// import { IUserForGroup, UserForDetail, UserForAuth } from "app/main/_models/user.model";
// import { HttpClient } from "@angular/common/http";
// import { FilterPlanPosteTableSelected, FilterPlanPosteTableSelection, PlanPosteReferenceFilter } from "app/main/_models/filters/plan-poste.filter";
// import { PlanPosteForDetail, PlanPosteFrequencyFilter, PlanPosteFrequencyForDetail } from "app/main/_models/plan.model";
// import { ComboMultiple } from "app/main/_models/generics/combo.model";
// import { ISelectGroup } from "app/main/_models/generics/select.model";

@Injectable()
export class PlanPosteApiService {
baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) {  }

    getPlanPosteTableFilter(filter: FilterPlanPosteTableSelected): Observable<FilterPlanPosteTableSelection> {
        return this._httpClient
            .post<FilterPlanPosteTableSelection>(`${this.baseUrl}plan-postes/plan-poste-table-filter`,filter);
    }

    getPlanPosteTable(filter: FilterPlanPosteTableSelected): Observable<PagedList<PlanPosteForTable>> {
        return this._httpClient
            .post<PagedList<PlanPosteForTable>>(`${this.baseUrl}plan-postes/plan-poste-table-data`,filter);
    }

    deletePlanPosteTable(listIdPlanPoste: number[]): Observable<boolean> {
        return this._httpClient
            .post<boolean>(`${this.baseUrl}plan-postes/plan-poste-table-delete`,listIdPlanPoste);
    }

    savePlanPosteDetail(planPosteForDetail: PlanPosteForDetail): Observable<PlanPosteForDetail> {
        return this._httpClient
            .post<PlanPosteForDetail>(`${this.baseUrl}plan-postes/plan-poste-detail-save`,planPosteForDetail);
    }



    getPlanPosteForDetail(idPlanPoste: number, idPlan: number, idPoste: number): Observable<PlanPosteForDetail> {
        return this._httpClient
            .get<PlanPosteForDetail>(`${this.baseUrl}plan-postes/${idPlanPoste}/plans/${idPlan}/postes/${idPoste}/plan-poste-detail`);
    }

    getForDetailFilter(idUserGroup: number, filter: PlanPosteForDetail): Observable<FilterPlanPosteDetail> {
        return this._httpClient
            .post<FilterPlanPosteDetail>(`${this.baseUrl}plan-postes/user-groups/${idUserGroup}/plan-poste-detail-filter`, filter);
    }

    getPlanPosteReferenceList(planPosteReferenceFilter: PlanPosteReferenceFilter): Observable<SelectGroup[]> {
        return this._httpClient
            .get<SelectGroup[]>(`${this.baseUrl}plan-poste-references/user-groups/${planPosteReferenceFilter.idUserGroup}/reference-table/${planPosteReferenceFilter.idReferenceTable}/postes/${planPosteReferenceFilter.idPoste}/plan-poste-reference-list`);
    }

    getPlanPosteFrequencies(planPosteFrequencyFilter: PlanPosteFrequencyFilter): Observable<PlanPosteFrequencyForDetail[]> {
        return this._httpClient
            .get<PlanPosteFrequencyForDetail[]>(`${this.baseUrl}plan-poste-frequencies/plan-postes/${planPosteFrequencyFilter.idPlanPoste}/is-annual-estimation/${planPosteFrequencyFilter.isAnnualEstimation}`);
    }

}
