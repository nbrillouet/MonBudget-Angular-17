import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterUserTableSelected } from 'app/model/filters/user.filter';
import { UserShortcut } from 'app/model/referential/user/user-shortcut.model';
import { UserForDetail, UserForLogged, UserPreference } from 'app/model/referential/user/user.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class UserApiService {
    baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) { }


    getUserTable(filter: FilterUserTableSelected): Observable<any> {
        return this._httpClient
            .post<any>(`${this.baseUrl}users/filter`,filter);
    }

    getUserTableFilter(filter: FilterUserTableSelected): Observable<FilterUserTableSelected> {
        return this._httpClient
            .post<FilterUserTableSelected>(`${this.baseUrl}users/table-filter`,filter);
    }

    getUserForDetail(id: number): Observable<UserForDetail> {
        return this._httpClient
            .get<UserForDetail>(`${this.baseUrl}users/${id}/user-detail`);
    }

    getUserForLogged(id: number): Observable<UserForLogged> {
        return this._httpClient
            .get<UserForLogged>(`${this.baseUrl}users/${id}/user-logged`);
    }

    saveUserForDetail(user: UserForDetail): any {
        return this._httpClient
            .post(`${this.baseUrl}users/save-user-for-detail`, user);
    }

    updateUser(id: number, user: UserForDetail): Observable<UserForDetail> {
        return this._httpClient
            .put<UserForDetail>(`${this.baseUrl}users/${id}/update`,user);
    }

    updateUserForLogged(userForLogged: UserForLogged): Observable<UserForLogged> {
        return this._httpClient
            .put<UserForLogged>(`${this.baseUrl}users/${userForLogged.id}/update-for-logged`,userForLogged);
    }

    // updateUserPreference(userPreference: UserPreference): Observable<UserPreference> {
    //     return this._httpClient
    //         .put<UserPreference>(`${this.baseUrl}user-preference/${userPreference.id}/update-user-preference`, userPreference);
    // }

    deleteShortcut(idUser: number, id: number): any {
        return this._httpClient
            .delete(`${this.baseUrl}users/${idUser}/shortcuts/${id}`);
    }

    addShortcut(idUser: number, shortcut: UserShortcut): any {
        return this._httpClient
            .post(`${this.baseUrl}users/${idUser}/shortcuts/`, shortcut);
    }

    changeAvatar(idUser: number, file: FormData): Observable<any> {
        return this._httpClient
            .post<any>(`${this.baseUrl}users/${idUser}/avatar`, file);
    }

    updateUserPreference(idUser: number, userPreference: UserPreference): Observable<UserPreference> {
        return this._httpClient
            .put<UserPreference>(`${this.baseUrl}users/${idUser}/user-preference-update`, userPreference);
    }
}
