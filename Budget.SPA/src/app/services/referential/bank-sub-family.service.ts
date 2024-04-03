import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Select } from '@corporate/model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';


@Injectable()
export class BankSubFamilyService {
baseUrl = environment.apiUrl;

    constructor(
        private http: HttpClient
    ) { }

    getSelectList(idBankFamily: number): Observable<Select[]> {
        return this.http
            .get<Select[]>(this.baseUrl + `referential/bank-sub-families/bank-families/${idBankFamily}/select-list`);
    }

}
