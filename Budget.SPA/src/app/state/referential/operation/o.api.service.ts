import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterForDetail, Select } from '@corporate/model';
import { EnumSelectType } from 'app/model/enum/enum-select-type.enum';
import { FilterODetail, FilterOTableSelected, FilterOTableSelection } from 'app/model/filters/operation.filter';
import { O, OForDetail } from 'app/model/referential/operation.model';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class OApiService {
baseUrl = environment.apiUrl;

constructor(
        private _httpClient: HttpClient,
        private _userLoggedService: UserLoggedService
    ) {

     }

    getSelectList(idOperationMethod: number, idOperationType: number, idUserGroup: number, enumSelectType: EnumSelectType): Observable<Select[]> {
        return this._httpClient
            .get<Select[]>(`${this.baseUrl}referential/operation/user-groups/${idUserGroup}/operation-methods/${idOperationMethod}/operation-types/${idOperationType}/select-type/${enumSelectType}/operations`);
    }

    getSelectListByOperationMethods(operationMethods: Select[]): Observable<Select[]> {
        return null;
        // return this._httpClient
        //     .post<Select[]>(`${this.baseUrl}referential/operations/user-groups/${this.userAuth.idUserGroup}/select-list`,operationMethods);
    }

    create(operation: O): Observable<Select> {
        // operation.idUserGroup = this.userAuth.idUserGroup;
        return this._httpClient
            .post<Select>(`${this.baseUrl}referential/operation/create`,operation);
    }


    /*---------------------------------------------------------------*/

    getOTable(filter: FilterOTableSelected): Observable<any> {
         return this._httpClient
            .post<any>(`${this.baseUrl}referential/operation/operation-table`,filter);
    }

    getOTableFilter(filter: FilterOTableSelected): Observable<FilterOTableSelection> {
        return this._httpClient
            .post<FilterOTableSelection>(`${this.baseUrl}referential/operation/operation-table-filter`,filter);
    }

    getDetailFilter(filter: OForDetail): Observable<FilterODetail> {
        return this._httpClient
            .post<FilterODetail>(`${this.baseUrl}referential/operation/operation-detail-filter`,filter);
    }

    getForDetail(filter: FilterForDetail): Observable<OForDetail> {
        return this._httpClient
            .get<OForDetail>(`${this.baseUrl}referential/operation/${filter.id}/user/${this._userLoggedService.userForInfo.id}/operation-detail`);
    }

    saveODetail(operationDetail: OForDetail): Observable<OForDetail> {
        return this._httpClient
            .post<OForDetail>(`${this.baseUrl}referential/operation/save`,operationDetail);
    }

    deleteOTable(listIdOtf: number[]): Observable<boolean> {
        return this._httpClient
            .post<boolean>(`${this.baseUrl}referential/operation/operation-table-delete`,listIdOtf);
    }
}
