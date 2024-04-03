import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { UserDetailService } from 'app/services/referential/user/user-detail/user-detail.service';

@Component({
    selector       : 'dashboard-alert',
    templateUrl    : './dashboard-alert.component.html',
    encapsulation  : ViewEncapsulation.None,
    animations : fuseAnimations
})
export class DashboardAlertComponent implements OnInit, OnDestroy
{
    constructor(
        public _userDetailService: UserDetailService

     )
    {

    }


    ngOnDestroy(): void
    {

    }

    ngOnInit(): void {

    }


}
