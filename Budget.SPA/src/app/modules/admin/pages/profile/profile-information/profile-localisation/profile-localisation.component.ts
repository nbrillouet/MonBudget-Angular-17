import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { GMapAddressFilterData } from 'app/model/g-map.model.';
import { UserForDetail } from 'app/model/referential/user/user.model';
import { HelperService } from 'app/services/helper.service';
import { ProfileService } from 'app/services/referential/user/profile/profile.service';
import { Subject } from 'rxjs';

@Component({
    selector       : 'profile-localisation',
    templateUrl    : './profile-localisation.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProfileLocalisationComponent implements OnInit, OnDestroy
{
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    property: UserForDetail = this._profileService.form.model;
    center: google.maps.LatLngLiteral;
    position: any;
    animation: any;
    userForDetail: UserForDetail;

    constructor(
        public _profileService: ProfileService,
        public _helperService: HelperService

    ) {
        // super();
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

        // this.marker.position = { lat: this.getValue(this.property.gMapAddress.lat), lng: this.getValue(this.property.gMapAddress.lng)}
        // this.marker.animation = google.maps.Animation.BOUNCE ;

        // navigator.geolocation.getCurrentPosition((position) => {
        //     this.center = {
        //       lat: position.coords.latitude,
        //       lng: position.coords.longitude,
        //     };
        //   });

        this._profileService.state$.subscribe((x) => {
            if(x?.loader['datas']?.loaded) {

                this.userForDetail = x.model;
                // console.log('this.userForDetail', this.userForDetail);
                this.position = { lat: this.getValue(this.property.gMapAddress.lat), lng: this.getValue(this.property.gMapAddress.lng)}
                this.animation = google.maps.Animation.BOUNCE ;
            }
            // if (x?.loader['datas']?.loaded && !this._helperService.areEquals(this.x,x)) {
            //     this.x=x;
            // }
        });
     }


    /**
     * On destroy
     */
    ngOnDestroy(): void
    {

    }

    getGMapAddressFilterData(): GMapAddressFilterData {
        // const operationDetail = this._asifDetailService.form.getValue(x=>x.operationDetail) as OperationDetail;
        const gMapAddressFilterData = {datas: this.userForDetail.gMapAddress, filter: {operationPositionSearch: '', operationPlaceSearch:'' } } as GMapAddressFilterData;
        return gMapAddressFilterData;
    }

    onChangeGMapAddress(gMapAddressFilterData: GMapAddressFilterData): void {

        // const operationDetail = this._asifDetailService.form.getValue(x=>x.operationDetail) as OperationDetail;
        // operationDetail.gMapAddress = gMapAddressFilterData.datas;
        // operationDetail.operationLabel = gMapAddressFilterData.filter.operationPositionSearch;
        // operationDetail.placeLabel = gMapAddressFilterData.filter.operationPlaceSearch;

        // this._asifDetailService.changeAsifOperationDetail(operationDetail);
    }

    public getValue(property: any): any {
        return this._profileService.form.getValue(property);
    }
}
