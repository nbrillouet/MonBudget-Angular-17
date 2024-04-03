import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterForDetail, SelectCode } from '@corporate/model';
import { EnumSelectType } from 'app/model/enum/enum-select-type.enum';
import { FilterOtfDetail, FilterOtfTableSelected, FilterOtfTableSelection } from 'app/model/filters/operation-type-family.filter';
import { OtfForDetail } from 'app/model/referential/operation-type-family.model';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class OtfApiService {
    baseUrl = environment.apiUrl;

        constructor(
            private _httpClient: HttpClient,
            private _userLoggedService: UserLoggedService
        ) {

         }

        getSelectCodeList(idOperationMethod: number, enumSelectType: EnumSelectType): Observable<SelectCode[]> {
            return this._httpClient
                .get<SelectCode[]>(this.baseUrl + `referential/operation-type-family/operation-method/${idOperationMethod}/select-type/${enumSelectType as number}/select-list`);
        }

        getOtfTable(filter: FilterOtfTableSelected): Observable<any> {
          return this._httpClient
            .post<any>(`${this.baseUrl}referential/operation-type-family/operation-type-family-table`, filter);
        }

        getOtfTableFilter(filter: FilterOtfTableSelected): Observable<FilterOtfTableSelection> {
          return this._httpClient
                .post<FilterOtfTableSelection>(`${this.baseUrl}referential/operation-type-family/operation-type-family-table-filter`, filter);
        }

        getForDetailFilter(filter: OtfForDetail): Observable<FilterOtfDetail> {
            return this._httpClient
                .post<FilterOtfDetail>(`${this.baseUrl}referential/operation-type-family/operation-type-family-detail-filter`,filter);
        }

        getForDetail(filter: FilterForDetail): Observable<OtfForDetail> {
            return this._httpClient
                .get<OtfForDetail>(`${this.baseUrl}referential/operation-type-family/${filter.id}/user/${this._userLoggedService.userForInfo.id}/operation-type-family-detail`);
        }

        save(otfDetail: OtfForDetail): Observable<OtfForDetail> {
          return this._httpClient
                .post<OtfForDetail>(`${this.baseUrl}referential/operation-type-family/operation-type-family-save`,otfDetail);
        }

        deleteOtfTable(listIdOtf: number[]): Observable<boolean> {
            return this._httpClient
                .post<boolean>(`${this.baseUrl}referential/operation-type-family/operation-type-family-table-delete`,listIdOtf);
        }

}
