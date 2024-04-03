import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { UserForDetail } from 'app/model/referential/user/user.model';
import { ProfileService } from 'app/services/referential/user/profile/profile.service';

import { Subject } from 'rxjs';

@Component({
    selector       : 'profile-about-me-edit',
    templateUrl    : './profile-about-me-edit.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileAboutMeEditComponent implements OnInit, OnDestroy
{
    property: UserForDetail = this._profileService.form.model;
    // saveInProgress: boolean;
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor(
        public _profileService: ProfileService
    ) {
        // this.property = this._profileService.form.model as UserForDetail;
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
     ngOnInit(): void
     {
        this._profileService.state$.subscribe((x)=> {
            // if(x.loader['datas-save']?.loading) {
            //     this.saveInProgress = true;
            //     this._profileService.profileForm.disableForm(true);
            // }
            if(x.loader['user-detail-save']?.loaded) {
                // this.saveInProgress = false;
                this._profileService.form.disableForm(false);
            }
        });
     }


    /**
     * On destroy
     */
    ngOnDestroy(): void
    {

    }

    public getProperty(property: any): any {
        return this._profileService.form.getProperty(property);
    }

    public save(): void {
        this._profileService.saveUserDetail();
    }

    public getValue(property: string): any {
        return this._profileService.form.getValue(property);
    }
}
