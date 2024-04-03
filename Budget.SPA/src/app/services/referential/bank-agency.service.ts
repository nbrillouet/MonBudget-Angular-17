import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SelectGMapAddress } from 'app/model/g-map.model.';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class BankAgencyService {
baseUrl = environment.apiUrl;

    constructor(
        private http: HttpClient
    ) { }

    getSelectList(idBankSubFamily: number): Observable<SelectGMapAddress[]> {
        return this.http
            .get<SelectGMapAddress[]>(this.baseUrl + `referential/bank-agencies/bank-sub-families/${idBankSubFamily}/select-list`);

    }

}
