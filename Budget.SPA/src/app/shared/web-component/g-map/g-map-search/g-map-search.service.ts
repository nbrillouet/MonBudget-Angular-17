import { Injectable } from '@angular/core';
import { CorpDataForm } from '@corporate/data';
import { ModelInfo, Select as SelectModel } from '@corporate/model';
import { Select, Store } from '@ngxs/store';
import { GMapAddress, GMapAddressFilterData, GMapType } from 'app/model/g-map.model.';
import { ChangeGMapDetail, LoadGMapDetail } from 'app/state/g-map/g-map.action';
import { GMapApiService } from 'app/state/g-map/g-map.api.service';
import { GMapDetailState } from 'app/state/g-map/g-map.state';
import { Observable } from 'rxjs';
import { GMapSearchFormBuilderOptions } from './g-map-search.form-builder-option';

@Injectable({ providedIn: 'root' })
export class GMapSearchService extends CorpDataForm<GMapAddressFilterData, GMapSearchFormBuilderOptions>
{
    @Select(GMapDetailState.get) stateDetail$: Observable<ModelInfo<GMapAddressFilterData>>;

    // gMapForm: CorpForm<GMapAddressFilterData, GMapSearchFormBuilderOptions>;
    isEmpty: boolean;
    /**
     * Constructor
     */
    constructor(
        private _store: Store,
        private _gMapApiService: GMapApiService
    ) {
        super(GMapAddressFilterData, GMapSearchFormBuilderOptions);
        // this.gMapForm = new CorpForm<GMapAddressFilterData, GMapSearchFormBuilderOptions>(GMapAddressFilterData, GMapSearchFormBuilderOptions);

        this.stateDetail$.subscribe((x)=>{
            if(x?.loader['datas']?.loaded) {
                this.isEmpty = !x.model?.datas?.formattedAddress;
            }
        });
    }

    load(gMapAddressFilterData: GMapAddressFilterData): void {
        this._store.dispatch(new LoadGMapDetail(gMapAddressFilterData));

        this.initTrigger();
    }

    search(keyword: string): void {
        this._gMapApiService.getGeoById(keyword).subscribe((x)=> {
        // this.geoLocalisation = <IGeocode>data;
            // const gMapAddress: any=null;
        // this.gMapAddress = this.parseGeolocalisation();
        //
        debugger;
        const gMapAddress = this.parseGeolocalisation(x) as GMapAddress;

        if(gMapAddress!==null) {
            this._store.dispatch(new ChangeGMapDetail({gMapAddress: gMapAddress, language: 'fr'}));
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
        }
        else {
            // this.notificationService.error('Echec de la localisation', 'veuillez préciser votre recherche');
        }

        });
    }

    parseGeolocalisation(googleInfo: any): GMapAddress {
          const result= googleInfo.results[0];

          const index = result.types.indexOf('point_of_interest', 0);
          if (index > -1) {
            result.types.splice(index, 1);
          }

          const gMaptypes = new Array<GMapType>();
          let idx: number =0;
          for(const gmapType of result.types)
          {
                gMaptypes.push({id: idx,code:gmapType.trim().toUpperCase(),label: null});
                idx++;
          }

          const gMapAddress = {
            id : 0,
            formattedAddress: result.formatted_address,
            lat: result.geometry.location.lat,
            lng: result.geometry.location.lng,
            gMapAdministrativeAreaLevel1: this.getInAddressComponents(result,'administrative_area_level_1'),
            gMapAdministrativeAreaLevel2: this.getInAddressComponents(result,'administrative_area_level_2'),
            gMapCountry: this.getInAddressComponents(result,'country'),
            gMapLocality:  this.getInAddressComponents(result,'locality'),
            gMapNeighborhood:this.getInAddressComponents(result,'neighborhood'),
            gMapPostalCode: this.getInAddressComponents(result,'postal_code'),
            gMapRoute: this.getInAddressComponents(result,'route') ,
            gMapStreetNumber: this.getInAddressComponents(result,'street_number'),
            gMapSublocalityLevel1: this.getInAddressComponents(result,'sublocality_level_1'),
            gMapSublocalityLevel2: this.getInAddressComponents(result,'sublocality_level_2'),
            gMapTypes: gMaptypes
          } as GMapAddress;

          return gMapAddress;
    }

    private getInAddressComponents(result: any, keyword: string): SelectModel {
        for (const addressComponent of result.address_components)
        {
          for(const type of addressComponent.types)
          {
              if(type===keyword){
                return {id:0, label: addressComponent.short_name};
              }
          }
        }
        return {id:1, label: 'INCONNU'};
      }


    // // -----------------------------------------------------------------------------------------------------
    // // @ Public methods
    // // -----------------------------------------------------------------------------------------------------
    // applyFilterSelected(selected: FilterAsifTableSelected): void {

    //     // this._store.dispatch(new LoadAsiFolderExplorer({idUser:5}));
    //     // this._store.dispatch(new LoadAsifTableFilterSelection(null));
    //     this._store.dispatch(new ChangeAsifTableFilterSelected(selected));
    // }

    // applyFilterSelection(selected: FilterAsifTableSelected): void {
    //     this._store.dispatch(new LoadAsifTableFilterSelection(selected));
    // }

    private initTrigger(): void {

    }

}
