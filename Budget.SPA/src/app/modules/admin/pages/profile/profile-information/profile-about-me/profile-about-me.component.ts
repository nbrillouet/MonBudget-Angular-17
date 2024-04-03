import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { EnumUserStatus } from 'app/model/enum/enum-user-status.enum';
import { UserForDetail } from 'app/model/referential/user/user.model';
import { HelperService } from 'app/services/helper.service';
import { ProfileService } from 'app/services/referential/user/profile/profile.service';
import { Subject } from 'rxjs';


@Component({
    selector       : 'profile-about-me',
    templateUrl    : './profile-about-me.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileAboutMeComponent implements OnInit, OnDestroy
{
    property: UserForDetail = this._profileService.form.model;
    enumStatus: typeof EnumUserStatus = EnumUserStatus;
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor(

        public _profileService: ProfileService,
        public _helperService: HelperService

    ) {
        // this.property = this._profileService.form.model as UserForDetail;
        // super();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
     ngOnInit(): void
     {
        this._profileService.state$.subscribe((x)=>{

        });
        // this._profileService.userDetailState$
        // .pipe(takeUntil(this._unsubscribeAll),distinctUntilChanged())
        // .subscribe((x) => {
        //     if (x?.loader['datas']?.loaded && !this._helperService.areEquals(this.x,x)) {
        //         this.x=x;
        //     }
        // });
     }


    /**
     * On destroy
     */
    ngOnDestroy(): void
    {

    }

    private getValue(property: string): any {
        return this._profileService.form.getValue(property);
    }

}
