import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterForDetail, Select } from '@corporate/model';
import { EnumSelectType } from 'app/model/enum/enum-select-type.enum';
import { FilterOtDetail, FilterOtTableSelected, FilterOtTableSelection } from 'app/model/filters/operation-type.filter';
import { OtForDetail } from 'app/model/referential/operation-type.model';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class OtApiService {

    baseUrl = environment.apiUrl;

    constructor(
            private _httpClient: HttpClient,
            private _userLoggedService: UserLoggedService
        ) {

        }

        getSelectList(idAccount: number, idMovement: number, idOperationTypeFamily: number, enumSelectType: EnumSelectType): Observable<Select[]> {

            return this._httpClient
                .get<Select[]>(`${this.baseUrl}referential/operation-type/account/${idAccount}/movement/${idMovement}/operation-type-families/${idOperationTypeFamily}/select-type/${enumSelectType as number}/select-list`);
        }


        getOtTable(filter: FilterOtTableSelected): Observable<any> {
          return this._httpClient
            .post<any>(`${this.baseUrl}referential/operation-type/operation-type-table`,filter);
        }

        getOtTableFilter(filter: FilterOtTableSelected): Observable<FilterOtTableSelection> {
          return this._httpClient
                .post<FilterOtTableSelection>(`${this.baseUrl}referential/operation-type/operation-type-table-filter`, filter);
        }

        getForDetail(filter: FilterForDetail): Observable<OtForDetail> {
          return this._httpClient
              .get<OtForDetail>(`${this.baseUrl}referential/operation-type/${filter.id}/users/${this._userLoggedService.userForInfo.idUserGroup}/detail`);
        }

        getForDetailFilter(filter: OtForDetail): Observable<FilterOtDetail> {
            return this._httpClient
                .post<FilterOtDetail>(`${this.baseUrl}referential/operation-type/operation-type-detail-filter`,filter);
        }

        getSelectListByOperationTypeFamily(operationTypeFamilies: Select[]): Observable<Select[]> {
            return null;
            // return this._httpClient
            //     .post<Select[]>(`${this.baseUrl}referential/operation-types/user-groups/${this._authService.user.idUserGroup}/select-list`,operationTypeFamilies);
        }

        saveOtDetail(otForDetail: OtForDetail): Observable<OtForDetail> {
          return this._httpClient
                .post<OtForDetail>(`${this.baseUrl}referential/operation-type/operation-type-save`,otForDetail);
        }

        deleteOtTable(listIdOt: number[]): Observable<boolean> {
            return this._httpClient
                .post<boolean>(`${this.baseUrl}referential/operation-type/operation-type-table-delete`, listIdOt);
        }

}
