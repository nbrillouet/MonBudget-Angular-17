import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserForAuth, UserForPasswordChange, UserForRegister } from 'app/model/referential/user/user.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class AuthApiService
{
    private baseUrl = environment.apiUrl;

    /**
     * Constructor
     */
    constructor(
        private _httpClient: HttpClient
    ) { }

    login(credentials: { username: string; password: string }): Observable<UserForAuth> {
        return this._httpClient
            .post<UserForAuth>(`${this.baseUrl}auth/login`, { username:credentials.username, password:credentials.password });
    }

    register(userForRegister: UserForRegister): Observable<any>
    {
        return this._httpClient
            .post(this.baseUrl + 'auth/register', userForRegister);
    }

    accountActivation(code: string): any {
        return this._httpClient
            .get<any>(`${this.baseUrl}auth/account-activation/${code}`);
    }

    accountPasswordRecovery(mail: string): any {
        return this._httpClient
            .get<any>(`${this.baseUrl}auth/account-password-recovery/${mail}`);
    }

    changePassword(user: UserForPasswordChange): any {
        return this._httpClient
            .post<any>(`${this.baseUrl}auth/change-password`,user);
    }

    // logout(): void {
    //     // remove user from local storage to log user out
    //     this._store.dispatch(new ClearNavigation());
    //     this._store.dispatch(new ClearUserDetail());
    //     localStorage.clear();

    //     this._notificationsService.info('logged out success','Vous êtes maintenant déconnecté');
    //     this._router.navigate(['/pages/auth/login']);
    // }

    /**
     * Unlock session
     *
     * @param credentials
     */
    unlockSession(credentials: { username: string; password: string }): Observable<any>
    {
        return this._httpClient.post('api/auth/unlock-session', credentials);
    }

}
