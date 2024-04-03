import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Select } from '@corporate/model';
import { EnumSelectType } from 'app/model/enum/enum-select-type.enum';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class OperationMethodService {
baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) { }

    getSelectList(enumSelectType: EnumSelectType): Observable<Select[]> {
        return this._httpClient
            .get<Select[]>(this.baseUrl + `referential/operation-methods/select-type/${enumSelectType as number}/select-list`);
    }
}
