import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { HelperService } from 'app/services/helper.service';
import { ProfileService } from 'app/services/referential/user/profile/profile.service';
import { Subject } from 'rxjs';

@Component({
    selector       : 'profile-information',
    templateUrl    : './profile-information.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileInformationComponent implements OnInit, OnDestroy
{
    x: any;
    // lat: number = 51.678418;
    // lng: number = 7.809007;
    // public userForDetail: UserForDetail;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    // public toto: boolean = false;
private toto: any;

    constructor(
        // public _userDetailService: UserDetailService
        public _profileService: ProfileService,
        private _helperService: HelperService
    ) {
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
        // this._profileService.userDetailState$
        //     .pipe(takeUntil(this._unsubscribeAll),distinctUntilChanged())
        //     .subscribe((x) => {
        //         if (x?.loader['datas']?.loaded && !this._helperService.areEquals(this.x,x)) {
        //             this.x=x;
        //         }
        //     });

     }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
         // Unsubscribe from all subscriptions
         this._unsubscribeAll.next(void 0);
         this._unsubscribeAll.complete();

        //  // Dispose the overlays if they are still on the DOM
        //  if ( this._tagsPanelOverlayRef )
        //  {
        //      this._tagsPanelOverlayRef.dispose();
        //  }
    }


}
    // @Select(UserDetailState.get) detail$: Observable<DetailFormInfo<UserForDetail>>;
