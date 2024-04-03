import { HttpErrorResponse, HttpEvent, HttpHandlerFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from 'app/core/auth/auth.service';
import { AuthUtils } from 'app/core/auth/auth.utils';
import { ToastrService } from 'ngx-toastr';
import { catchError, Observable, throwError } from 'rxjs';

/**
 * Intercept
 *
 * @param req
 * @param next
 */
export const authInterceptor = (req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> =>
{
    const authService = inject(AuthService);
    const _toastrService = inject(ToastrService);

    // Clone the request object
    let newReq = req.clone();

    // Request
    //
    // If the access token didn't expire, add the Authorization header.
    // We won't add the Authorization header if the access token expired.
    // This will force the server to return a "401 Unauthorized" response
    // for the protected API routes which our response interceptor will
    // catch and delete the access token from the local storage while logging
    // the user out from the app.

    //exclusion d adresse exterieur pour l'authorisation
    const excludeHttp = 'maps.googleapis.com';
    if ( authService.user.token && !AuthUtils.isTokenExpired(authService.user.token) )
    {
        if(req.url.search(excludeHttp)===-1) {
            newReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + authService.user.token),
            });
        }
    }

    // Response
    return next(newReq).pipe(
        catchError((error) =>
        {
            _toastrService.error('Hello world!', 'Toastr fun!');
            // Catch "401 Unauthorized" responses
            if ( error instanceof HttpErrorResponse && error.status === 401 )
            {
                // Sign out
                authService.signOut();

                // Reload the app
                location.reload();
            }

            return throwError(error);
        }),
    );
};
