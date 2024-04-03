import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterForDetail } from '@corporate/model';
import { AsifForDetail, AsifForTable } from 'app/model/account-statement-import/account-statement-import-file.model';
import { AsForDetail } from 'app/model/account-statement/account-statement-detail.model';
import { FilterAsifDetail, FilterAsifTableSelected, FilterAsifTableSelection } from 'app/model/filters/account-statement-import-file.filter';
import { environment } from 'environments/environment';
import { PagedList } from '@corporate/mat-table-filter';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'any' })
export class AsifApiService {
baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) {
        // this.user$.subscribe((user:UserForDetail) => {
        //     this.currentUser = user;
        //     this.userForGroup = this.currentUser!=null ? <IUserForGroup> {id:this.currentUser.id,idUserGroup:this.currentUser.idUserGroup} : null;
        // });
    }

    getAsifTable(filter: FilterAsifTableSelected): Observable<PagedList<AsifForTable>> {
        return this._httpClient
            .post<PagedList<AsifForTable>>(`${this.baseUrl}account-statement-import-files/filter`,filter);
    }

    getAsifTableFilter(filter: FilterAsifTableSelected): Observable<FilterAsifTableSelection> {
        // filter.user=this.userForGroup;
        return this._httpClient
            .post<FilterAsifTableSelection>(`${this.baseUrl}account-statement-import-files/table-filter`,filter);
    }

    getDetailFilter(filter: AsifForDetail): Observable<FilterAsifDetail> {
        // filter.user = this.userForGroup;
        return this._httpClient
            .post<FilterAsifDetail>(`${this.baseUrl}account-statement-import-files/asif-detail-filter`,filter);
    }

    getForDetail(filter: FilterForDetail): Observable<AsifForDetail> {
        return this._httpClient
            .get<AsifForDetail>(`${this.baseUrl}account-statement-import-files/${filter.id}/asif-detail`);
    }

    getById(id: number): Observable<AsifForDetail> {
        return this._httpClient
            .get<AsifForDetail>(this.baseUrl + `account-statement-import-files/${id}/detail`);
    }

    isSaveableInAccountStatement(idImport: number): Observable<boolean> {
        return this._httpClient
            .get<boolean>(`${this.baseUrl}account-statement-import-files/imports/${idImport}/isSaveableInAccountStatement`);
    }

    saveInAccountStatement(idImport: number): Observable<boolean> {
        return this._httpClient
            .get<boolean>(`${this.baseUrl}account-statement-import-files/imports/${idImport}/saveInAccountStatement`);
    }

    saveAsifDetail(asDetail: AsForDetail): Observable<boolean> {
        return this._httpClient
            .post<boolean>(`${this.baseUrl}account-statement-import-files/save-asif-detail`,asDetail);
    }

}
