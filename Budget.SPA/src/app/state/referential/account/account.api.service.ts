import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterForDetail } from '@corporate/model';
import { FilterAccountDetail, FilterAccountTableSelected, FilterAccountTableSelection } from 'app/model/filters/account.filter';
import { AccountForDetail } from 'app/model/referential/account.model';
import { BankFamilyForList } from 'app/model/referential/bank-family.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class AccountApiService {

    baseUrl = environment.apiUrl;
    // userAuth: UserForAuth = JSON.parse(localStorage.getItem('userInfo'));
    // userForGroup: UserForGroup = {id:this.userAuth.id,idUserGroup:this.userAuth.idUserGroup};

    constructor(
        private _httpClient: HttpClient
    ) {

     }

    getForList(idUser: number): Observable<BankFamilyForList[]> {
        return this._httpClient
            .get<BankFamilyForList[]>(`${this.baseUrl}referential/accounts/user/${idUser}/account-list-bank-family`);
    }

    getForDetail(filter: FilterForDetail): Observable<AccountForDetail> {
        return this._httpClient
            .get<AccountForDetail>(`${this.baseUrl}referential/accounts/${filter.id}/account-detail`);
    }

    getForDetailFilter(filter: AccountForDetail): Observable<FilterAccountDetail> {
        return this._httpClient
            .post<FilterAccountDetail>(`${this.baseUrl}referential/accounts/account-detail-filter`, filter);
    }

    getForTable(filter: FilterAccountTableSelected): Observable<any> {
        return this._httpClient
            .post<any>(`${this.baseUrl}referential/accounts/account-table`, filter);
    }

    getForTableFilter(filter: FilterAccountTableSelected): Observable<FilterAccountTableSelection>  {
        // filter.user=this.userForGroup;
        return this._httpClient
            .post<FilterAccountTableSelection>(`${this.baseUrl}referential/accounts/account-table-filter`,filter);
    }

    save(accountDetail: AccountForDetail): Observable<any> {
        // accountDetail.user =  this.userForGroup;

        return this._httpClient
              .post(`${this.baseUrl}referential/accounts/account-save`,accountDetail);
    }

    askAccountOwner(accountDetail: AccountForDetail): Observable<boolean> {
        // accountDetail.user =  this.userForGroup;

        return this._httpClient
              .post<boolean>(`${this.baseUrl}referential/accounts/ask-account-owner`,accountDetail);
    }


    deleteList(idAccountTable: number[]): Observable<boolean> {
        return this._httpClient
            .post<boolean>(`${this.baseUrl}referential/accounts/delete-account-list`,idAccountTable);
    }

}
