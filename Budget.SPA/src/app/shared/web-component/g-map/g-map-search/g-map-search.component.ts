import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
// import { ActivatedRoute } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
// import { NotificationsService } from 'angular2-notifications';
import { EnumOperationMethod } from 'app/model/enum/enum-operation-model.model';
import { GMapAddress, GMapAddressFilterData, GMapType } from 'app/model/g-map.model.';
import { GMapSearchService } from './g-map-search.service';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { HelperService } from 'app/services/helper.service';

@Component({
    selector: 'g-map-search',
    templateUrl: './g-map-search.component.html',
    animations : fuseAnimations
  })
  export class GMapSearchComponent implements OnInit, OnChanges {
    @Input() gMapAddressFilterData: GMapAddressFilterData;
    @Input() xformat: string;
    @Output() changeGMapAddress = new EventEmitter<GMapAddressFilterData>();

    property: GMapAddressFilterData = null;
    readonly separatorKeysCodes: number[] = [ENTER, COMMA];
    // filter: GMapSearchInfo = null;
    // gMapSearchForm: FormGroup;
    gMapAddress: GMapAddress;
    position: any;


    // center: google.maps.LatLngLiteral = {
    //     lat: 24,
    //     lng: 12
    // };
    // zoom = 15;

    constructor(
        // private _activatedRoute: ActivatedRoute,
        //   private gMapService: GMapService,
        //   private formBuilder: FormBuilder,
        // private notificationService: NotificationsService,
        public _gMapSearchService: GMapSearchService,
        private _helperService: HelperService
    ) {
        this.property = this._gMapSearchService.form.model as GMapAddressFilterData;
        // this.filter = this._gMapSearchService.gMapForm. as GMapSearchModel;
        this._gMapSearchService.stateDetail$.subscribe((x) =>{
            console.log('x',x);
        });
    }

    ngOnInit(): void {
        this._gMapSearchService.load(this.gMapAddressFilterData);

        this._gMapSearchService.stateDetail$.subscribe((x)=>{
            if(x.loader['datas'].loaded){
                this.changeGMapAddress.emit(x.model);

                this.gMapAddress = x.model.datas;
                this.position =  {lat: this.gMapAddress.lat, lng: this.gMapAddress.lng};
            }
        });
    }

    ngOnChanges(changes: SimpleChanges): void {

        // if(changes.gMapAddressFilterData.currentValue!==changes.gMapAddressFilterData.previousValue) {
        //     this._gMapSearchService.load(changes.gMapAddressFilterData.currentValue);
        // }



    //   let gMapSearchInfo = <IGMapSearchInfo>changes.gMapSearchInfo.currentValue;
    //   this.gMapSearchInfo = gMapSearchInfo;

    //   //charger le gmapAddress
    //   this.gMapService
    //     .getById(this.gMapSearchInfo.idGMapAddress)
    //     .subscribe(resp=> {
    //       this.gMapAddress = resp;
    //       this.createForm();
    //       this.addressVisible = this.gMapAddress.id!=1 && this.gMapAddress.id!=3;
    //       this.searchVisible = this.gMapAddress.id == 1;
    //       this.isFormLoaded = true;
    //      });

    }

    searchGoogleMap(): void {
        // this.property.operationPositionSearch
        // this.property.operationPlaceSearch
        // let operationPositionSearch: string = this.gMapSearchForm.value.operationPositionSearch;
        // let operationPlaceSearch: string = this.gMapSearchForm.value.operationPlaceSearch;

        const keyword=`${this._gMapSearchService.form.getValue(x=>x.filter.operationPositionSearch)} ${this._gMapSearchService.form.getValue(x=>x.filter.operationPlaceSearch)}`;
        this._gMapSearchService.search(keyword);

        // this.changeLocation(keyword);
    }

    //   cancelSearch(){
    //     this.searchVisible=!this.searchVisible;
    //     this.addressVisible=!this.addressVisible;
    //   }

    changeLocation(keyword: string): void {
        // this.gMapService.GetGeoById(keyword)
        //     .subscribe(data=> {
        // this.geoLocalisation = <IGeocode>data;

        // this.gMapAddress = this.parseGeolocalisation();
        // if(this.gMapAddress!=null) {


        //     this.gMapSearchForm.controls['formattedAddress'].setValue(this.gMapAddress.formattedAddress);
        //     this.gMapSearchForm.controls['country'].setValue(this.gMapAddress.gMapCountry.label);
        //     this.gMapSearchForm.controls['locality'].setValue(this.gMapAddress.gMapLocality.label);
        //     this.gMapSearchForm.controls['neighborhood'].setValue(this.gMapAddress.gMapNeighborhood.label);
        //     this.gMapSearchForm.controls['administrativeAreaLevel1'].setValue(this.gMapAddress.gMapAdministrativeAreaLevel1.label);
        //     this.gMapSearchForm.controls['administrativeAreaLevel2'].setValue(this.gMapAddress.gMapAdministrativeAreaLevel2.label);
        //     this.gMapSearchForm.controls['streetNumber'].setValue(this.gMapAddress.gMapStreetNumber.label);
        //     this.gMapSearchForm.controls['route'].setValue(this.gMapAddress.gMapRoute.label);
        //     this.gMapSearchForm.controls['postalCode'].setValue(this.gMapAddress.gMapPostalCode.label);
        //     this.gMapSearchForm.controls['subLocalityLevel1'].setValue(this.gMapAddress.gMapSublocalityLevel1.label);
        //     this.gMapSearchForm.controls['subLocalityLevel2'].setValue(this.gMapAddress.gMapSublocalityLevel2.label);

        //     this.gMapService
        //     .saveGMapAddress(this.gMapAddress)
        //     .subscribe(resp=>{
        //         this.gMapAddress= resp;
        //         this.showSearch(false);
        //         this.changeGMapAddress.emit(this.gMapAddress);
        //     })

        // }
        // else
        //     this.notificationService.error('Echec de la localisation', 'veuillez préciser votre recherche');
        // });
    }

    isUnknownData(data: number): boolean {
        return data === EnumOperationMethod.inconnu;
    }

    addGMapType(event: MatChipInputEvent): void {
        const input = event.input;
        const value = event.value;

        // Add type
        if ((value || '').trim()) {
            const types = this._helperService.getDeepClone(this._gMapSearchService.form.getValue(x=>x.datas.gMapTypes)) as GMapType[];
            types.push({id:0,code:value.trim().toUpperCase(),label:null});

            this._gMapSearchService.form.setValue(x=>x.datas.gMapTypes, types);
        }

        // Reset the input value
        if (input) {
          input.value = '';
        }
      }

    public getProperty(property: any): string {
        return this._gMapSearchService.form.getProperty(property);
    }

    public getValue(property: any): any {
        if(typeof property === 'object') {
            property = (Object.values(property)[0] as string).split('.')[0];
        }

        return this._gMapSearchService.form.getValue(property);
    }

    // createForm() {
    //   this.gMapSearchForm = this.formBuilder.group({
    //     //operationPlace: [dataOperationPlace,[Validators.required, ValidateIsUnknown]],

    //     operationPositionSearch: [this.gMapSearchInfo.operationPositionSearch,[Validators.required]],
    //     operationPlaceSearch: [this.gMapSearchInfo.operationPlaceSearch,[Validators.required]],

    //     formattedAddress : [this.gMapAddress.formattedAddress,[Validators.required]],
    //     country: [this.gMapAddress.gMapCountry.label,[Validators.required]],
    //     locality: [this.gMapAddress.gMapLocality.label],
    //     neighborhood: [this.gMapAddress.gMapNeighborhood.label],
    //     administrativeAreaLevel1: [this.gMapAddress.gMapAdministrativeAreaLevel1.label],
    //     administrativeAreaLevel2: [this.gMapAddress.gMapAdministrativeAreaLevel2.label],
    //     streetNumber: [this.gMapAddress.gMapStreetNumber.label],
    //     route: [this.gMapAddress.gMapRoute.label],
    //     postalCode: [this.gMapAddress.gMapPostalCode.label],
    //     subLocalityLevel1: [this.gMapAddress.gMapSublocalityLevel1.label],
    //     subLocalityLevel2: [this.gMapAddress.gMapSublocalityLevel2.label]
    //   });
    // }



    cancelSearch(): void {
    //   this.searchVisible=!this.searchVisible;
    //   this.addressVisible=!this.addressVisible;
    }


    parseGeolocalisation(): void {
    //   if(this.geoLocalisation.status=='OK')
    //   {
    //     let result= this.geoLocalisation.results[0];

    //     var index = result.types.indexOf('point_of_interest', 0);
    //     if (index > -1) {
    //       result.types.splice(index, 1);
    //     }
    //     let gMaptypes = new Array<IGMapType>();
    //     let idx: number =0;
    //     for(let gmapType of result.types)
    //     {
    //       gMaptypes.push({id: idx,keyword:gmapType.trim().toUpperCase(),label: null})
    //       idx++;
    //     }

    //     let gMapAddress = <GMapAddress> {
    //       id : 0,
    //       formattedAddress: result.formatted_address,
    //       lat: result.geometry.location.lat,
    //       lng: result.geometry.location.lng,
    //       gMapAdministrativeAreaLevel1: <ISelect> { id:0, label: this.getInAddressComponents(result,'administrative_area_level_1') },
    //       gMapAdministrativeAreaLevel2: <ISelect> { id:0, label: this.getInAddressComponents(result,'administrative_area_level_2') },
    //       gMapCountry: <ISelect> { id:0, label: this.getInAddressComponents(result,'country') },
    //       gMapLocality: <ISelect> { id:0, label: this.getInAddressComponents(result,'locality') },
    //       gMapNeighborhood: <ISelect> { id:0, label: this.getInAddressComponents(result,'neighborhood') },
    //       gMapPostalCode: <ISelect> { id:0, label: this.getInAddressComponents(result,'postal_code')},
    //       gMapRoute: <ISelect> { id:0, label: this.getInAddressComponents(result,'route') } ,
    //       gMapStreetNumber: <ISelect> { id:0, label: this.getInAddressComponents(result,'street_number') },
    //       gMapSublocalityLevel1: <ISelect> { id:0, label: this.getInAddressComponents(result,'sublocality_level_1') },
    //       gMapSublocalityLevel2: <ISelect> { id:0, label: this.getInAddressComponents(result,'sublocality_level_2') },
    //       gMapTypes: <IGMapType[]> gMaptypes
    //     }

    //     return gMapAddress;
    //   }
    }

    getInAddressComponents(result: any, keyword: string): void {
    //   let str: string = 'INCONNU';
    //   for (let address_component of result.address_components)
    //   {
    //     for(let type of address_component.types)
    //     {
    //       if(type===keyword)
    //       {
    //         str = address_component.short_name;
    //         return str;
    //       }
    //     }
    //   }
    //   return str;
    }

    unknownData(formControlName:string): void {
    //   return this.gMapSearchForm.get(formControlName).value=='INCONNU';
    }

    remove(type): void {
        // const index = this.gMapAddress.gMapTypes.indexOf(type);

        // if ( index >= 0 )
        // {
        //   this.gMapAddress.gMapTypes.splice(index, 1);
        // }
    }

    // add(event: MatChipInputEvent): void {
    //   const input = event.input;
    //   const value = event.value;

    //   // Add our fruit
    //   if ((value || '').trim()) {
    //     this.gMapAddress.gMapTypes.push({id:0,keyword:value.trim().toUpperCase(),label:null});
    //   }

    //   // Reset the input value
    //   if (input) {
    //     input.value = '';
    //   }
    // }

      showSearch(value: boolean): void {
        // this.searchVisible=value;
        // this.addressVisible=!value;
      }

  }
