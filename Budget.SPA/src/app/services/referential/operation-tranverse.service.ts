import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Select } from '@corporate/model';
import { EnumSelectType } from 'app/model/enum/enum-select-type.enum';
import { OperationTransverse } from 'app/model/referential/operation-transverse.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class OperationTransverseService {
baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) { }


    create(operationTransverse: OperationTransverse): Observable<OperationTransverse> {
        return this._httpClient
            .post<OperationTransverse>(`${this.baseUrl}referential/operation-transverses/create`,operationTransverse);
    }

    getSelectList(idUser: number, enumSelectType: EnumSelectType): Observable<Select[]> {
        return this._httpClient
            .get<Select[]>(`${this.baseUrl}referential/operation-transverses/user/${idUser}/select-type/${enumSelectType}/operation-transverse-select-list`);
    }
}
