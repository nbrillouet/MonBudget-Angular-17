import { Injectable, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { distinctUntilChanged } from 'rxjs/operators';
import { UserDetailService } from 'app/services/referential/user/user-detail/user-detail.service';


@Injectable({ providedIn: 'root' })
export class ProfileService extends UserDetailService
{
    // profileForm: CorpForm<UserForDetail, UserForDetailFormBuilderOptions>;
    // value: UserForDetail = new UserForDetail();

    constructor(
        public _store: Store
        // private _userDe

        // tailService: UserDetailService
        // // private _authService: AuthService,
    ) {
        super(_store);
        // this.profileForm = new CorpForm<UserForDetail,UserForDetailFormBuilderOptions>(UserForDetail, UserForDetailFormBuilderOptions);
    }


    // state$(): Observable<any> {
    //     return this._userDetailService.state$;
    // }

    // this._authService.user.id
    public load(idUser: number ): void {
        // this._userDetailService.load({idUser: idUser});
        super.load(idUser);

        // this.value = this.instanciate(this.value, null);

        this.initTrigger();
    }

    public saveUserDetail():  void{
        this.form.disableForm(true);
        this.save(this.form.formGroup.getRawValue());
    }

    // private setFakeValue() {
    //     const iterate = (profileFormValue) => {
    //         Object.keys(profileFormValue).forEach((key) => {



    //         if (typeof profileFormValue[key] === 'object') {
    //                 iterate(profileFormValue[key]);
    //             }
    //         });
    //     };
    // }
    // public changeAvatar(idUser: number, file: any): void {
    //     this._userDetailService.changeAvatar(idUser, file);
    // }

    // public changeTheme(theme: EnumTheme): void {
    //     this._userDetailService.changeTheme(theme);
    // }

    // getValue(item: string): any {
    //     // if(item) {


    //         // const keys = Object.keys(item);
    //         return this.profileForm.getValue(item);
    //     // }
    // }

    // getUserIdValue(): any {
    //     return this.profileForm.getValue(x=>x.id);
    // }

    // getBannerUrlValue(): any {
    //     return this.profileForm.getValue(x=>x.userPreference.bannerUrl);
    // }

    // getAvatarUrlValue(): any {
    //     return this.profileForm.getValue(x=>x.userPreference.avatarUrl);
    // }

    // getUsernameValue(): any {
    //     return this.profileForm.getValue(x=>x.userName);
    // }

    // getFirstNameValue(): any {
    //     return this.profileForm.getValue(x=>x.firstName);
    // }

    // getEmailValue(): any {
    //     return this.profileForm.getValue(x=>x.email);
    // }

    // getLastNameValue(): any {
    //     return this.profileForm.getValue(x=>x.lastName);
    // }

    // getRoleValue(): any {
    //     return this.profileForm.getValue(x=>x.role);
    // }

    // getDateOfBirthValue(): any{
    //     return this.profileForm.getValue(x=>x.dateOfBirth);
    // }

    // getAgeValue(): any {
    //     return this.profileForm.getValue(x=>x.age);
    // }

    // getDateCreatedValue(): any {
    //     return this.profileForm.getValue(x=>x.dateCreated);
    // }

    // getDateLastActiveValue(): any {
    //     return this.profileForm.getValue(x=>x.dateLastActive);
    // }

    // getStatusValue(): any {
    //     return this.profileForm.getValue(x=>x.userPreference.status);
    // }

    // getGmapAddressFormattedAddressValue(): any {
    //     return this.profileForm.getValue(x=>x.gMapAddress.formattedAddress);
    // }

    // getGmapAddressLatitudeValue(): any {
    //     return this.profileForm.getValue(x=>x.gMapAddress.lat);
    // }

    // getGmapAddressLongitudeValue(): any {
    //     return this.profileForm.getValue(x=>x.gMapAddress.lng);
    // }

    // getGmapAddressLocality(): any {
    //     return this.profileForm.getValue(x=>x.gMapAddress.gMapLocality);
    // }

    // getGmapAddressCountry(): any {
    //     return this.profileForm.getValue(x=>x.gMapAddress.gMapCountry);
    // }

    // getUserPreferenceSchemeValue(): any {
    //     return this.profileForm.getValue(x=>x.userPreference.scheme);
    // }

    // private instanciate(model, childName: string): any {
    //     Object.keys(model).forEach((x) => {
    //         if (model[x] != null && typeof model[x] === 'object') {
    //             const objChild = this.instanciate(model[x],x.toString());
    //             // model.addControl(x, formGroupChild);
    //         }
    //         else {
    //             model[x] = childName===null ? x.toString() : `${childName}.${x.toString()}`;
    //             // const formOption: FormOption = option ? option[x] : null;
    //             // const formControl: FormControl = new FormControl(formOption?.defaultValue==null ? null : formOption.defaultValue, formOption?.validators?.length>0 ?  formOption.validators : null);
    //             // formOption?.defaultDisabled ? formControl.disable({ onlySelf: true, emitEvent: false }) : null;

    //             // formGroup.addControl(x, formControl);
    //         }
    //     });
    //     return model;
    // }

    private initTrigger(): void {
        this.form.getControl(x=>x.age).valueChanges.pipe(distinctUntilChanged()).subscribe((value) => {

        });
    }
}
