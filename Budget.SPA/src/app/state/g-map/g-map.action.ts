import { GMapAddress, GMapAddressFilterData, GMapSearchInfo, GMapType } from 'app/model/g-map.model.';

export const GMAP_DETAIL_LOAD = 'gmap-detail-load';
export const GMAP_DETAIL_CHANGE = 'gmap-detail-change';
// export const GMAP_DETAIL_GMAP_TYPE_CHANGE = 'gmap-detail-gmap-type-change';

export class LoadGMapDetail {
    static readonly type = GMAP_DETAIL_LOAD;

    constructor(public payload: GMapAddressFilterData) { }
}

export class ChangeGMapDetail {
    static readonly type = GMAP_DETAIL_CHANGE;

    constructor(public payload: {gMapAddress: GMapAddress; language: string}) { }
}

// export class ChangeGMapDetailGMapType {
//     static readonly type = GMAP_DETAIL_GMAP_TYPE_CHANGE;

//     constructor(public payload: {gMapTypes: GMapType[]; language: string}) { }
// }
