import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AsifGroupByAccounts } from 'app/model/account-statement-import/account-statement-import-file.model';
import { AsiForList, AsiTable } from 'app/model/account-statement-import/account-statement-import.model';
import { FilterAsiTableSelected, FilterAsiTableSelection } from 'app/model/filters/account-statement-import.filter';
import { UserForAuth } from 'app/model/referential/user/user.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class AsiApiService {
baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) {

    }

    getAsiForList(idUser: number): Observable<AsiForList> {
        return this._httpClient
            .get<AsiForList>(`${this.baseUrl}account-statement-import/list/user/${idUser}/asi-by-bank-agency`);
    }

    getAsiTableFilter(filter: FilterAsiTableSelected): Observable<FilterAsiTableSelection> {
        return this._httpClient
            .post<FilterAsiTableSelection>(`${this.baseUrl}account-statement-import/table-filter`, filter);
    }

    getAsiTable(filter: FilterAsiTableSelected): Observable<any> {
        return this._httpClient
            .post<any>(`${this.baseUrl}account-statement-import/filter`,filter);
    }

    getById(idImport: number): Observable<AsiTable> {
        return this._httpClient
            .get<AsiTable>(`${this.baseUrl}account-statement-import/${idImport}/asi-detail`);
    }

    deleteList(idAsiList: number[]): Observable<boolean> {
        return this._httpClient
            .post<boolean>(`${this.baseUrl}account-statement-import/delete-asi-list`,idAsiList);
    }

    uploadFile(user: UserForAuth, formData: FormData): Observable<AsifGroupByAccounts> {
        return this._httpClient
            .post<any>(`${this.baseUrl}account-statement-import/users/${user.id}/upload-file`, formData);
    }

}
