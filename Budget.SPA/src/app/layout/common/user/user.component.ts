import { NgClass, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Router } from '@angular/router';
import { EnumUserStatus } from 'app/model/enum/enum-user-status.enum';
import { UserForLogged, UserPreference } from 'app/model/referential/user/user.model';
import { HelperService } from 'app/services/helper.service';
import { UserLoggedService } from 'app/services/referential/user/user-logged/user-logged.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
    selector       : 'user',
    templateUrl    : './user.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    exportAs       : 'user',
    standalone     : true,
    imports        : [MatButtonModule, MatMenuModule, NgIf, MatIconModule, NgClass, MatDividerModule],
})
export class UserComponent implements OnInit, OnDestroy
{
    @Input() showAvatar: boolean = true;
    enumUserStatus= EnumUserStatus;
    userForLogged: UserForLogged;

    private _unsubscribeAll: Subject<any> = new Subject<any>();

    /**
     * Constructor
     */
    constructor(
        private _changeDetectorRef: ChangeDetectorRef,
        private _router: Router,
        private _helperService: HelperService,
        public _userLoggedService: UserLoggedService
    )
    {
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        this._userLoggedService.userLoggedState$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((x) => {
                if(x?.loader['datas']?.loaded) {
                    this.userForLogged = x.datas;
                    // Mark for check
                    this._changeDetectorRef.markForCheck();
                }
            });

    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Update the user status
     *
     * @param status
     */
    updateUserStatus(status: string): void
    {
        const userPreference = this._helperService.getDeepClone(this._userLoggedService.userForLogged.userPreference);
        userPreference.status = EnumUserStatus[status];
        this._userLoggedService.updateUserPreference(this._userLoggedService.userForLogged.id, userPreference);
    }

    /**
     * Sign out
     */
    signOut(): void
    {
        this._router.navigate(['/sign-out']);
    }

    profileOnClick(): void {
        this._router.navigate(['/pages/profile']);
    }
}
