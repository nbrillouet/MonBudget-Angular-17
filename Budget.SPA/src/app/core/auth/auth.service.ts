import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DataInfo } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { AuthUtils } from 'app/core/auth/auth.utils';
import { UserService } from 'app/core/user/user.service';
import { UserForAuth } from 'app/model/referential/user/user.model';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { Login } from 'app/state/user/auth/auth.action';
import { AuthState } from 'app/state/user/auth/auth.state';
import { catchError, Observable, of, switchMap, throwError } from 'rxjs';

@Injectable({providedIn: 'root'})
export class AuthService
{
    private _authenticated: boolean = false;
    @Select(AuthState.get) public authState$: Observable<DataInfo<UserForAuth>>;

    /**
     * Constructor
     */
    constructor(
        private _httpClient: HttpClient,
        private _userService: UserService,
        private _store: Store,
        private _userLoggedService: UserLoggedService,
    )
    {
        this.authState$.subscribe((x)=>{
            if(x?.loader['login']?.loaded) {
                // this.accessToken = x.datas.token;
                this.user = x.datas;
                //chargement du user
                this._userLoggedService.load({ idUser: x.datas.id });
             }
        });
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Accessors
    // -----------------------------------------------------------------------------------------------------

    /**
     * Setter & getter for access token
     */
    // set accessToken(token: string)
    // {
    //     localStorage.setItem('accessToken', token);
    // }

    // get accessToken(): string
    // {
    //     return localStorage.getItem('accessToken') ?? '';
    // }
    /**
     * Setter & getter for access token
     */
    set user(userForAuth: UserForAuth)
    {
        localStorage.setItem('user', JSON.stringify(userForAuth));
    }

    get user(): UserForAuth
    {
        return JSON.parse(localStorage.getItem('user')) ?? '';
    }
    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Forgot password
     *
     * @param email
     */
    forgotPassword(email: string): Observable<any>
    {
        return this._httpClient.post('api/auth/forgot-password', email);
    }

    /**
     * Reset password
     *
     * @param password
     */
    resetPassword(password: string): Observable<any>
    {
        return this._httpClient.post('api/auth/reset-password', password);
    }

    /**
     * Sign in
     *
     * @param credentials
     */
    signIn(credentials: { username: string; password: string }): Observable<any>
    {
        // Throw error, if the user is already logged in
        if ( this._authenticated )
        {
            return throwError('User is already logged in.');
        }

        this._store.dispatch(new Login(credentials));
        // return this._httpClient.post('api/auth/sign-in', credentials).pipe(
        //     switchMap((response: any) =>
        //     {
        //         // Store the access token in the local storage
        //         this.accessToken = response.accessToken;

        //         // Set the authenticated flag to true
        //         this._authenticated = true;

        //         // Store the user on the user service
        //         this._userService.user = response.user;

        //         // Return a new observable with the response
        //         return of(response);
        //     }),
        // );
    }

    /**
     * Sign in using the access token
     */
    signInUsingToken(): Observable<any>
    {

        // Sign in using the token
        return this._httpClient.post('api/auth/sign-in-with-token', {
            token: this.user.token,
        }).pipe(
            catchError(() =>

                // Return false
                of(false),
            ),
            switchMap((response: any) =>
            {
                // Replace the access token with the new one if it's available on
                // the response object.
                //
                // This is an added optional step for better security. Once you sign
                // in using the token, you should generate a new one on the server
                // side and attach it to the response object. Then the following
                // piece of code can replace the token with the refreshed one.
                if ( response.accessToken )
                {
                    this.user.token = response.accessToken;
                }

                // Set the authenticated flag to true
                this._authenticated = true;

                // Store the user on the user service
                this._userService.user = response.user;

                // Return true
                return of(true);
            }),
        );
    }

    /**
     * Sign out
     */
    signOut(): Observable<any>
    {
        // Remove the access token from the local storage
        localStorage.removeItem('user');

        // Set the authenticated flag to false
        this._authenticated = false;

        // Return the observable
        return of(true);
    }

    /**
     * Sign up
     *
     * @param user
     */
    signUp(user: { name: string; email: string; password: string; company: string }): Observable<any>
    {
        return this._httpClient.post('api/auth/sign-up', user);
    }

    /**
     * Unlock session
     *
     * @param credentials
     */
    unlockSession(credentials: { email: string; password: string }): Observable<any>
    {
        return this._httpClient.post('api/auth/unlock-session', credentials);
    }

    /**
     * Check the authentication status
     */
    check(): Observable<boolean>
    {
        // Check if the user is logged in
        if ( this._authenticated )
        {
            return of(true);
        }

        // Check the access token availability
        if ( !this.user && !this.user.token)
        {
            return of(false);
        }

        // Check the access token expire date
        if ( AuthUtils.isTokenExpired(this.user.token ))
        {
            return of(false);
        }

        // If the access token exists, and it didn't expire, sign in using it
        return of(true); // this.signInUsingToken();
    }
}
