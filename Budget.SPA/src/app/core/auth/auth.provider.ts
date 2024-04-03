import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { ENVIRONMENT_INITIALIZER, EnvironmentProviders, importProvidersFrom, inject, Provider } from '@angular/core';
import { authInterceptor } from 'app/core/auth/auth.interceptor';
import { AuthService } from 'app/core/auth/auth.service';
import { UserLoggedModule } from 'app/services/referential/user/user-logged/user-logged.module';
import { AuthStoreModule } from 'app/state/user/auth/auth.store.module';

export const provideAuth = (): Array<Provider | EnvironmentProviders> =>
{
    return [
        provideHttpClient(withInterceptors([authInterceptor])),
        {
            provide : ENVIRONMENT_INITIALIZER,
            useValue: () => inject(AuthService),
            multi   : true,
        },
        importProvidersFrom(
            // NgxsModule.forFeature([AuthState]),
            AuthStoreModule,
            UserLoggedModule
        )
    ];
};
