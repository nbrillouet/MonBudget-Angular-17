import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SelectYear } from '@corporate/model';
import { AsForTable } from 'app/model/account-statement/account-statement-table.model';
import { FilterPlanNotAsTableGroupSelected, FilterPlanNotAsTableSelected, FilterPlanNotAsTableSelection } from 'app/model/filters/plan-not-as.filter';
import { FilterPlanTableSelected, FilterPlanTableSelection } from 'app/model/filters/plan.filter';
import { PlanForFollowUp } from 'app/model/plan/plan-follow-up/plan-follow-up.model';
import { PlanForDetail, PlanForTable } from 'app/model/plan/plan.model';
import { environment } from 'environments/environment';
import { PagedList } from '@corporate/mat-table-filter';
import { Observable } from 'rxjs';
import { PlanNotAsTable } from 'app/model/plan/plan-not-as/plan-not-as.model';
import { FilterPlanFollowUpSelected, FilterPlanFollowUpSelection } from 'app/model/filters/plan-follow-up.filter';
import { PlanFollowUpAmountRealFilter } from 'app/model/filters/plan-follow-up-amount-real.filter';

@Injectable()
export class PlanApiService {
// userAuth: UserForAuth = JSON.parse(localStorage.getItem('userInfo'));
// userForGroup: IUserForGroup = {id: this.userAuth.id,idUserGroup:this.userAuth.idUserGroup};
baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) {
        // this.user$.subscribe((user:UserForDetail) => {
        //     this.currentUser = user;
        //     this.userForGroup = this.currentUser!=null ? <IUserForGroup> {id:this.currentUser.id,idUserGroup:this.currentUser.idUserGroup} : null;
        // });
     }

    getPlanTableFilter(filter: FilterPlanTableSelected): Observable<FilterPlanTableSelection> {
        // filter.user=this.userForGroup;
        return this._httpClient
            .post<FilterPlanTableSelection>(`${this.baseUrl}plans/plan-table-filter`,filter);
    }

    getPlanTable(filter: FilterPlanTableSelected): Observable<PagedList<PlanForTable>> {
        // filter.user=this.userForGroup;
        return this._httpClient
            .post<PagedList<PlanForTable>>(`${this.baseUrl}plans/plan-table-data`,filter);
    }

    getForDetailById(idUser: number, idPlan: number): Observable<PlanForDetail> {
        return this._httpClient
            .get<PlanForDetail>(`${this.baseUrl}users/${idUser}/plans/${idPlan}/plan-detail`);
            // .map(response => <PlanDetail>response);
    }

    savePlanDetail(planForDetail: PlanForDetail): Observable<number> {
        return this._httpClient
            .post<number>(`${this.baseUrl}plans/plan-details/save`, planForDetail);

    }

    deletePlans(idList: number[]): Observable<string> {
        return this._httpClient
            .post<string>(`${this.baseUrl}plans/delete-plans`,idList);
    }

    getPlanNotAsTableFilter(filter: FilterPlanNotAsTableSelected): Observable<FilterPlanNotAsTableSelection> {
        // filter.user=this.userForGroup;
        return this._httpClient
            .post<FilterPlanNotAsTableSelection>(`${this.baseUrl}plan-not-as/plan-not-as-table-filter`,filter);
            // .map((response: FilterPlanNotAsTableSelection) => response);
    }

    getPlanNotAsTable(filter: FilterPlanNotAsTableGroupSelected): Observable<PagedList<PlanNotAsTable>> {
        return this._httpClient
            .post<PagedList<PlanNotAsTable>>(`${this.baseUrl}plan-not-as/plan-not-as-table-data`, filter);
    }



    getPlanFollowUp(filter: FilterPlanFollowUpSelected): Observable<PlanForFollowUp> {
        return this._httpClient
            .post<PlanForFollowUp>(`${this.baseUrl}plans/plan-follow-up/dashboard`,filter);
    }

    getPlanFollowUpFilter(filter: FilterPlanFollowUpSelected): Observable<FilterPlanFollowUpSelection> {
        return this._httpClient
            .post<FilterPlanFollowUpSelection>(`${this.baseUrl}plans/plan-follow-up/dashboard-filter`, filter);
    }

    getPlanFollowUpAmountReal(filter: PlanFollowUpAmountRealFilter): Observable<AsForTable[]> {
        return this._httpClient
        .post<AsForTable[]>(`${this.baseUrl}plans/plan-follow-up/amount-real`, filter);
    }

}
