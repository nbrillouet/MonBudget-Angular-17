import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { UserForDetail } from 'app/model/referential/user/user.model';
import { ProfileService } from 'app/services/referential/user/profile/profile.service';
import { Subject } from 'rxjs';

@Component({
    selector       : 'profile-about-me-read',
    templateUrl    : './profile-about-me-read.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileAboutMeReadComponent implements OnInit, OnDestroy
{
    property: UserForDetail;

    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor(
        public _profileService: ProfileService
    ) {
        this.property = this._profileService.form.model as UserForDetail;
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
     ngOnInit(): void
     {

     }


    /**
     * On destroy
     */
    ngOnDestroy(): void
    {

    }

    public getValue(property: any): any {
        return this._profileService.form.getValue(property);
    }

}
