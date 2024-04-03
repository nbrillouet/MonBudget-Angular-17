import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataInfo } from '@corporate/model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { UserForAuth } from 'app/model/referential/user/user.model';
import { LoaderState } from 'app/state/_base/loader-state';
import { AccountActivation, AccountPasswordRecovery, ChangePassword, Login, Logout, Register } from './auth.action';
import { AuthApiService } from './auth.api.service';
import { ToastrService } from 'ngx-toastr';

export class AuthStateModel extends DataInfo<UserForAuth> {
    constructor() {
        super();
    }
}

const detailInfo = new AuthStateModel();
@State<AuthStateModel>({
    name: 'userAuth',
    defaults : detailInfo
})

@Injectable()
export class AuthState extends LoaderState {
    constructor(
        private _authApiService: AuthApiService,
        private _notificationsService: ToastrService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    )
    {
        super();
    }

    @Selector() static get(state: AuthState): any { return state;  }

    @Action(Login)
    login(context: StateContext<AuthStateModel>, action: Login): void {

        this.loading(context,'login');

        this._authApiService.login({ username: action.payload.username, password: action.payload.password })
            .subscribe((result)=> {

                context.patchState({
                    datas: result
                });
                //TODO redirection?
                // const redirectURL = '/signed-in-redirect';
                // // // Navigate to the redirect url
                // this._router.navigateByUrl(redirectURL);

                this.loaded(context,'login');
        });
    }

    @Action(AccountPasswordRecovery)
    accountPasswordRecovery(context: StateContext<AuthStateModel>, action: AccountPasswordRecovery): void {
        this.loading(context,'accountPasswordRecovery');

        this._authApiService.accountPasswordRecovery(action.payload.email).subscribe(()=>{
            this._notificationsService.success('Réinitialisation mot de passe','Un email a été envoyé');
            this.loaded(context,'accountPasswordRecovery');
        });
    }

    @Action(AccountActivation)
    accountActivation(context: StateContext<AuthStateModel>, action: AccountActivation): void {
        this.loading(context,'accountActivation');

        this._authApiService.accountActivation(action.payload.validationCode).subscribe(()=>{
            this._notificationsService.success('Activation compte','Votre compte est activé!');
            this._router.navigate(['/pages/auth/login']);

            this.loaded(context,'accountActivation');
        });
    }

    @Action(ChangePassword)
    changePassword(context: StateContext<AuthStateModel>, action: ChangePassword): void {
        this.loading(context,'changePassword');

        this._authApiService.changePassword(action.payload.userForPasswordChange).subscribe(()=>{
            this._notificationsService.success('Modification mot de passe','votre mot de passe est modifié!');
            this._router.navigate(['/pages/auth/login']);

            this.loaded(context,'changePassword');
        });
    }

    @Action(Register)
    register(context: StateContext<AuthStateModel>, action: Register): void {
        this.loading(context,'register');

        this._authApiService.register(action.payload.userForRegister).subscribe(()=>{
            this._router.navigate(['/pages/auth/mail-confirm']);

            this.loaded(context,'register');
        });
    }

}
