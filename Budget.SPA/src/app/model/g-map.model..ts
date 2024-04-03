/* eslint-disable @typescript-eslint/naming-convention */
import { Select, SelectCode } from '@corporate/model';

export class SelectGMapAddress extends Select {
    gMapAddress: GMapAddress;
}

export class GMapAddress {
    id: number = null;
    formattedAddress: string = null;
    lat: number= null;
    lng: number= null;
    gMapAdministrativeAreaLevel1: Select= null;
    gMapAdministrativeAreaLevel2: Select= null;
    gMapCountry: Select= null;
    gMapLocality: Select= null;
    gMapNeighborhood: Select= null;
    gMapPostalCode: Select= null;
    gMapRoute: Select= null;
    gMapStreetNumber: Select= null;
    gMapSublocalityLevel1: Select= null;
    gMapSublocalityLevel2: Select= null;
    gMapTypes: GMapType[] = null;
}

export class GMapAddressFilterData {
    datas: GMapAddress = new GMapAddress();
    filter: GMapSearch = new GMapSearch();
}

export class GMapSearchModel extends GMapAddress {
    searchInfo: GMapSearchInfo = new GMapSearchInfo();
    // operationPositionSearch: string = null;
    // operationPlaceSearch: string = null;
}

export class GMapSearch {
    operationPositionSearch: string = null;
    operationPlaceSearch: string = null;
}

export class GMapSearchInfo {
    idGMapAddress: number = null;
    operationPositionSearch: string = null;
    operationPlaceSearch: string = null;
}

export class GMapType extends SelectCode {
}

export class Geocode {
    results: GeocodeResult[];
    status: string = null;
}

export class GeocodeResult {
    address_components: AddressComponent[] = [];
    formatted_address: string = null;
    geometry: Geometry = new Geometry();
    placeId: string = null;
    types: string[] = [];
}

export class AddressComponent {
    long_name: string = null;
    short_name: string = null;
    types: string[] = [];
}

export class Geometry {
    bounds: Bound[] = [];
    location: Coordinate = null;
    location_type: string = null;
    viewport: Bound = new Bound();

}

export class Bound {
    northeast: Coordinate = new Coordinate();
    southwest: Coordinate = new Coordinate();
}

export class Coordinate {
    lat: number = null;
    lng: number = null;
}
