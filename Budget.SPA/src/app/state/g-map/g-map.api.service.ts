import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GMAP_KEY } from 'app/core/config/gmap-api-key.model';
import { Geocode, GMapAddress, GMapType } from 'app/model/g-map.model.';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class GMapApiService {
baseUrl = environment.apiUrl;

    constructor(
        private _httpClient: HttpClient
    ) { }

    getGeoById(cityName: string): Observable<Geocode> {
        return this._httpClient.get<Geocode>(`https://maps.googleapis.com/maps/api/geocode/json?address=${cityName}&key=${GMAP_KEY}`);
    }

    getById(id: number): Observable<GMapAddress> {
        return this._httpClient.get<GMapAddress>(`${this.baseUrl}GMapAddresses/${id}/GMapAddress`);
    }

    changeGmapTypes(gMapTypes: GMapType[], language: string): Observable<GMapType[]> {
        return this._httpClient.post<GMapType[]>(`${this.baseUrl}GMapAddresses/language/${language}/change-gmap-type`, gMapTypes);
    }

    save(gMapAddress: GMapAddress): Observable<GMapAddress> {
        return this._httpClient.post<GMapAddress>(`${this.baseUrl}GMapAddresses/save`, gMapAddress);
    }

}
